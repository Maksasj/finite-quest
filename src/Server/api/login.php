<?php
header("Content-Type: application/json");

$username = $_GET['username'];
$token = $_GET['token'];

if (!$_GET) {
    echo "Failed";
    exit();
}

if (!file_exists("../userData/" . $username . ".json")) {
    echo "Failed";
    exit();
}

$user = json_decode(file_get_contents("../userData/" . $username . ".json"), true);

if($token != $user["token"]) {
    echo "Failed";
    exit();
}

echo "Success";
exit();

?>