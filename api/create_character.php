<?php

include "../utils/raceValidation.php";
include "../utils/prettyPrint.php";
include "../utils/combatClassValidation.php";
include "../utils/getClassStartingLocation.php";

//Auntification
$username = $_GET['username'];
$token = $_GET['token'];

//Character name
$character_name = $_GET['character_name'];

//Race
$race = $_GET['race'];

//Class
$class = $_GET['class'];

if (!$_GET) {
    exit();
}

if (!file_exists("../userData/" . $username . ".json")) {
    echo "Such username not available";
    exit();
}

$user = json_decode(file_get_contents("../userData/" . $username . ".json"), true);

if (in_array($character_name, $user["characters"])) {
    echo "Such character already exists on this user";
    exit;
}

if (file_exists("../charactersData/" . $character_name . ".json")) {
    echo "Such character already exists";
    exit();
}

if($token != $user["token"]) {
    echo "Wrong token have been provided";
    exit();
}

$user["characters"][$character_name] = time();

$character["name"] = $character_name;
$character["user"] = $username;
$character["race"] = $race;
$character["class"] = $class;

$character["creation_date"] = time();

$character["current_location"] = getClassStartingLocation($race);

$character["gold"] = 0;
$character["xp"] = 0;

$character["inventory"] = array();
$character["ammo_bag"] = array();

file_put_contents("../charactersData/" . $character_name . ".json", prettyPrint(json_encode($character)));
file_put_contents("../userData/" . $username . ".json", prettyPrint(json_encode($user)));

//header('HTTP/1.1 400 Bad requst', true, 400);
//exit;
?>