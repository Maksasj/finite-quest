<?php
header("Content-Type: application/json");

include_once "../utils/prettyPrint.php";

$character = $_GET['character'];
$type = $_GET['type'];

if (!file_exists("../charactersData/" . $character . ".json")) {
    echo "Such username not available";
    exit();
}

$characterData = json_decode(file_get_contents("../charactersData/" . $character . ".json"), true);

if ($type == "bag") {
    echo prettyPrint(json_encode($characterData["inventory"]["bag"]));
    exit();
}

if ($type == "inventory") {
    echo prettyPrint(json_encode($characterData["inventory"]));
    exit();
}

if ($type == "equipment") {
    echo prettyPrint(json_encode($characterData["inventory"]["equipment"]));
    exit();
}

if ($type == "ammo_bag") {
    echo prettyPrint(json_encode($characterData["inventory"]["ammo_bag"]));
    exit();
}

?>