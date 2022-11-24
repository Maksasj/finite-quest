<?php

function getClassStartingLocation($race) {
    echo $race;

    $races = json_decode(file_get_contents("../api/general/race.json"), true);

    return $races[$race]["start_location"];
}

?>