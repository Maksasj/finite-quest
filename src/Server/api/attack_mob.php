<?php
header("Content-Type: application/json");

include_once "../utils/calculateCharacterStats.php";

include_once "../utils/calculateCharacterMaxHealth.php";
include_once "../utils/calculateMobMaxHealth.php";

include_once "../utils/calculateDroppedXp.php";
include_once "../utils/calculateDroppedGold.php";

include_once "../utils/prettyPrint.php";

$username = $_GET['username'];
$token = $_GET['token'];

$character_name = $_GET['character'];

$mob_name = $_GET['mob'];

if (!$_GET) {
    exit();
}

if (!file_exists("../userData/" . $username . ".json")) {
    echo "Such username not available";
    exit();
}

$user = json_decode(file_get_contents("../userData/" . $username . ".json"), true);

if($token != $user["token"]) {
    echo "Wrong token have been provided";
    exit();
}

if (!$user["characters"][$character_name]) {
    echo "Such character not exists not this username";
    exit;
}

$character = json_decode(file_get_contents("../charactersData/" . $character_name . ".json"), true);

if ($character["timestamps"]["activity_cooldown"] > time()) {
    echo "Combat in process";
    exit;
}

$locations = json_decode(file_get_contents("general/locations.json"), true);

//Check if such mob exist on this location
if(!in_array($mob_name, $locations[$character["current_location"]]["mobs"])) {
    echo "Such mob is not exist on this location";
    exit;
}

function calculatePlayerDamage($character) {
    return 2;
}

function calculateMobDamage($character) {
    return 2;
}

$delta_time = 0;
$mob = json_decode(file_get_contents("general/mobs/" . $mob_name . ".json"), true);

$character_stats = calculateCharacterStats($character);

//Lets start battle
$success = false;
$logs["logs"] = array();
$character_health = calculateCharacterMaxHealth($character);
$mob_health = calculateMobMaxHealth($mob);

for($i = 0; true; $i++) {
    $character_dealed_damage = calculatePlayerDamage($character); 
    $mob_health -= $character_dealed_damage;
    $delta_time++;
    
    if($mob_health < 0) {
        $log_tmp["damage_dealer"] = $character["name"];
        $log_tmp["damage"] = $character_dealed_damage;
        $log_tmp["status"] = "final";

        array_push($logs["logs"], $log_tmp);

        $success = true;

        break;
    }

    $log_tmp["damage_dealer"] = $character["name"];
    $log_tmp["damage"] = $character_dealed_damage;
    $log_tmp["status"] = "in_process";

    array_push($logs["logs"], $log_tmp);

    $mob_dealed_damage = calculateMobDamage($mob); 
    $character_health -= $mob_dealed_damage;
    $delta_time++;
    
    if($character_health < 0) {
        $log_tmp["damage_dealer"] = $mob["name"];
        $log_tmp["damage"] = $mob_dealed_damage;
        $log_tmp["status"] = "final";

        array_push($logs["logs"], $log_tmp);

        break;
    }

    $log_tmp["damage_dealer"] = $mob["name"];
    $log_tmp["damage"] = $mob_dealed_damage;
    $log_tmp["status"] = "in_process";

    array_push($logs["logs"], $log_tmp);
}

if($success == true) {
    $xp = calculateDroppedXp($mob);
    $gold = calculateDroppedGold($mob);

    $logs["result"]["result"] = "success";
    $logs["result"]["received"]["xp"] = $xp;
    $logs["result"]["received"]["gold"] = $gold;
    $logs["result"]["received"]["items"] = array();

    $character["gold"] += $gold;
    $character["xp"] += $xp;
        
    //Roll item drops
    foreach($mob["drops"] as $key => $item_data) {
        $item[$key] = $item_data;

        $chance = rand(0, 100) / 100.0;

        if($chance < $item[$key]["drop"]["chance"]) {
            $min = $item[$key]["drop"]["count"]["min"];
            $max = $item[$key]["drop"]["count"]["max"];

            $item_count = rand($min, $max);
            
            if($item_count == 0) continue;

            if(array_key_exists($key, $character["inventory"]["bag"])) {
                //Item exist in invetory

                $character["inventory"]["bag"][$key]["count"] += $item_count;
            } else {
                //Item does not exist in invetory

                $character["inventory"]["bag"][$key] = $item_data;
                $character["inventory"]["bag"][$key]["count"] = $item_count;
            }
        }

        unset($item);
    }

} else {
    $logs["result"]["result"] = "fail";

    $logs["result"]["received"]["xp"] = 0;
    $logs["result"]["received"]["gold"] = 0;
    $logs["result"]["received"]["items"] = array();
}

$logs["result"]["start_time"] = time();
$logs["result"]["finish_time"] = time() + $delta_time;

$character["timestamps"]["last_combat"] = time();
$character["timestamps"]["last_activity"] = time();
$character["timestamps"]["activity_cooldown"] = time() + $delta_time;

file_put_contents("../charactersData/" . $character_name . ".json", prettyPrint(json_encode($character)));

echo prettyPrint(json_encode($logs));
?>