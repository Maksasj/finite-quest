<?php

function calculateCharacterStats($character) {
    $races = json_decode(file_get_contents("../api/general/race.json"), true);
    $classes = json_decode(file_get_contents("../api/general/class.json"), true);
    
    $race = $character["race"];
    $class = $character["class"];

    $result["stamina"]          = $races[$race]["base_stats"]["stamina"] +          $classes[$class]["base_stats"]["stamina"];
    $result["armour"]           = $races[$race]["base_stats"]["armour"] +           $classes[$class]["base_stats"]["armour"];

    $result["strength"]         = $races[$race]["base_stats"]["strength"] +         $classes[$class]["base_stats"]["strength"];
    $result["intelect"]         = $races[$race]["base_stats"]["intelect"] +         $classes[$class]["base_stats"]["intelect"];
    $result["critical_strike"]  = $races[$race]["base_stats"]["critical_strike"] +  $classes[$class]["base_stats"]["critical_strike"];
    $result["agility"]          = $races[$race]["base_stats"]["agility"] +          $classes[$class]["base_stats"]["agility"];

    foreach($character["inventory"]["equipment"] as $key => $value)  {
        foreach($value as $key => $value)  {
            $result["stamina"] += $value["base_stats"]["stamina"];
            $result["armour"] += $value["base_stats"]["armour"];

            $result["strength"] += $value["base_stats"]["strength"];
            $result["intelect"] += $value["base_stats"]["intelect"];
            $result["critical_strike"] += $value["base_stats"]["critical_strike"];
            $result["agility"] += $value["base_stats"]["agility"];
        }
    }

    return $result;
}

?>