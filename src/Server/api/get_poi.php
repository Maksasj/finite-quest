<?php

header("Content-Type: application/json");

include_once "../utils/prettyPrint.php";
include_once "../utils/calculateCharacterStats.php";

$character = $_GET['character'];

if (!file_exists("../charactersData/" . $character . ".json")) {
    echo "Such username not available";
    exit();
}

$characterData = json_decode(file_get_contents("../charactersData/" . $character . ".json"), true);

$current_location = $characterData["current_location"];

$locations = json_decode(file_get_contents("general/locations.json"), true);

$response["mobs"] = array();
$response["gathering"] = array();
$response["connections"] = array();

foreach($locations[$current_location]["mobs"] as $key => $poi_data) {
    $mob = json_decode(file_get_contents("general/mobs/" . $poi_data . ".json"), true);

    $response["mobs"][$poi_data] = "[E] ". $mob["name"] . " " . $mob["lvl"] . "Lvl";
}

foreach($locations[$current_location]["connections"] as $key => $poi_data) {
    $response["connections"][$poi_data] = "[L] ". $locations[$poi_data]["name"];
}

foreach($locations[$current_location]["gathering"] as $key => $poi_data) {
    $response["gathering"][$key] = "[G] ". $poi_data["name"];
}

echo prettyPrint(json_encode($response, JSON_FORCE_OBJECT));

?>