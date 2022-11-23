<?php
header("Content-Type: application/json");
include "../utils/prettyPrint.php";

$response["realm_name"] = "Ursina";
$response["realm_status"] = "active";
$response["base_endpoint"] = "www.ursina.io/api";

echo prettyPrint(json_encode($response));
exit();
?>