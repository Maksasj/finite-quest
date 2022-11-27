<?php
//header("Content-Type: application/json");

include_once "../utils/calculateCharacterStats.php";

include_once "../utils/calculateCharacterMaxHealth.php";
include_once "../utils/calculateMobMaxHealth.php";

include_once "../utils/calculateDroppedXp.php";
include_once "../utils/calculateDroppedGold.php";

include_once "../utils/prettyPrint.php";

$username = $_GET['username'];
$token = $_GET['token'];

$character_name = $_GET['character'];

$target = $_GET['target'];

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

$delta_time = 30;

if ($character["timestamps"]["activity_cooldown"] > time()) {
    echo "Traveling in process";
    exit();
}

$character = json_decode(file_get_contents("../charactersData/" . $character_name . ".json"), true);
$locations = json_decode(file_get_contents("general/locations.json"), true);

$current_location = $locations[$character["current_location"]];

if(!in_array($target, $current_location["connections"])) {
    echo "Such place is not connected to current location";
    exit();
}

$character["current_location"] = $target;
$character["timestamps"]["last_activity"] = time();
$character["timestamps"]["activity_cooldown"] = time() + $delta_time;

file_put_contents("../charactersData/" . $character_name . ".json", prettyPrint(json_encode($character)));

$logs["result"]["start_time"] = time();
$logs["result"]["finish_time"] = time() + $delta_time;

echo prettyPrint(json_encode($logs));
?>