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

$response["mobs"] = $locations[$current_location]["mobs"];
$response["gathering"] = array();
$response["connections"] = $locations[$current_location]["connections"];

echo prettyPrint(json_encode($response));

?>