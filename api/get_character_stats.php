<?php
header("Content-Type: application/json");

include "../utils/prettyPrint.php";
include "../utils/calculateCharacterStats.php";

$character = $_GET['character'];

if (!file_exists("../charactersData/" . $character . ".json")) {
    echo "Such username not available";
    exit();
}

$characterData = json_decode(file_get_contents("../charactersData/" . $character . ".json"), true);

$out = calculateCharacterStats($characterData);

echo prettyPrint(json_encode($out));
?>