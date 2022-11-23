<?php

include "../utils/calculateCharacterStats.php";
include "../utils/prettyPrint.php";

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

$locations = json_decode(file_get_contents("general/locations.json"), true);

//Check if such mob exist on this location
if(!in_array($mob_name, $locations[$character["current_location"]]["mobs"])) {
    echo "Such mob is not exist on this location";
    exit;
}

$mob = json_decode(file_get_contents("general/mobs/" . $mob_name . ".json"), true);

$character_stats = calculateCharacterStats($character);

//Мега костыль но да
if($character_stats["strength"] > $mob["base_stats"]["strength"]) {
    echo "Success";

    $character["gold"] += 1; //calculateDroppedGold($mob);
    $character["xp"] += 1; //calculateDroppedXp($mob);

    file_put_contents("../charactersData/" . $character_name . ".json", prettyPrint(json_encode($character)));
} else {
    echo "Fail";
}

echo $character_stats["stamina"];

?>