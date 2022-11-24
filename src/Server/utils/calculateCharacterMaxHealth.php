<?php

include_once "calculateCharacterStats.php";

function calculateCharacterMaxHealth($character) {
    $stats = calculateCharacterStats($character);

    return $stats["stamina"] * 10;
}

?>