<?php
header("Content-Type: application/json");
include_once "../utils/prettyPrint.php";

$username = $_GET["username"];

if (!$_GET) {
    exit();
}

if (!file_exists("../userData/" . $username . ".json")) {
    echo "Failed";
    exit();
}

$user = json_decode(file_get_contents("../userData/" . $username . ".json"), true);

echo prettyPrint(json_encode($user["characters"]));
?>