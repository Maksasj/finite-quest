<?php

function calculateDroppedGold($mob) {
    $chance = rand(0, 100) / 100.0;

    if($chance < $mob["gold_reward"]["chance"]) {
        $min = $mob["gold_reward"]["count"]["min"];
        $max = $mob["gold_reward"]["count"]["max"];

        return rand($min, $max);
    }

    return 0;
}

?>