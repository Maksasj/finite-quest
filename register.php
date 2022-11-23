<?php

include "utils/prettyPrint.php"

$username = $_POST['username'];
$password_hash = "";

if (file_exists("user_data/" . $username . ".json")) {
    echo "Such username not available";
    exit();
}

if (strlen($_POST['password']) > 6) {
    $password_hash = hash('sha256', $_POST['password']);
} else {
    echo "Password should be longer than 6 symbols";
    exit();
}

$token_hash = hash('sha256', $password_hash . $username);
$token_hash = hash('sha256', $token_hash); //And again ;)

$user["username"] = $username;
$user["token"] = $token_hash;
$user["register_date"] = time();
$user["characters"] = array();

file_put_contents("userData/" . $username . ".json", prettyPrint(json_encode($user)));

echo "Succesffully created user: " . $username;
?>