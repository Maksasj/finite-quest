<?php

include_once "calculateCharacterStats.php";

function calculateCharacterProgression($character) {

    $response["xp"] = $character["xp"]; 
    $response["lvl"] = $character["lvl"];



    return $stats["stamina"] * 10;
}

?>