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

echo prettyPrint(json_encode($characterData, JSON_FORCE_OBJECT));
?>