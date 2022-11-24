<?php

include_once "calculateMobStats.php";

function calculateMobMaxHealth($mob) {
    $stats = calculateMobStats($mob);

    return $stats["stamina"] * 10;
}

?>