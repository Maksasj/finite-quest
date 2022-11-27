<?php
header("Content-Type: application/json");

include_once "../utils/calculateCharacterStats.php";

include_once "../utils/calculateCharacterMaxHealth.php";
include_once "../utils/calculateMobMaxHealth.php";

include_once "../utils/calculateDroppedXp.php";
include_once "../utils/calculateDroppedGold.php";

include_once "../utils/prettyPrint.php";

$username = $_GET['username'];
$token = $_GET['token'];

$target = $_GET['target'];

$character_name = $_GET['character'];

if (!$_GET) {
    exit();
}

if (!file_exists("../userData/" . $username . ".json")) {
    echo "Such username not available";
    exit();
}

$user = json_decode(file_get_contents("../userData/" . $username . ".json"), true);

if($token != $user["token"]) {
    echo "Wrong token have been provided";
    exit();
}

if (!$user["characters"][$character_name]) {
    echo "Such character not exists not this username";
    exit();
}

$character = json_decode(file_get_contents("../charactersData/" . $character_name . ".json"), true);

if($character["inventory"]["bag"][$target] == null) {
    echo "Such item does not exists in bag";
    exit();
}

if($character["inventory"]["bag"][$target]["type"] != "equitable") {
    echo "Such item impossible to equipte";
    exit();
}

if($character["inventory"]["bag"][$target]["equipe"]["slot"] == "head") {

} else if($character["inventory"]["bag"][$target]["equipe"]["slot"] == "chest") {
    if($character["inventory"]["equipment"]["chest"]) {
        $equiped_item = $character["inventory"]["equipment"]["chest"];
        $equiped_item_id = key($character["inventory"]["equipment"]["chest"]);
        
        unset($character["inventory"]["equipment"]["chest"][$equiped_item_id]);

        if($character["inventory"]["bag"][$equiped_item_id] != null) {
            $character["inventory"]["bag"][$equiped_item_id]["count"]++;
        } else {
            $character["inventory"]["bag"][$$equiped_item_id] = $equiped_item[$equiped_item_id];
        }
    } else {
        $character["inventory"]["equipment"]["chest"][$target] = $character["inventory"]["bag"][$target];

        if($character["inventory"]["bag"][$target]["count"] > 1) {
            $character["inventory"]["bag"][$target]["count"]--;
        } else {
            unset($character["inventory"]["bag"][$target]);
        }
    }
} else if($character["inventory"]["bag"][$target]["equipe"]["slot"] == "legs") {
    if($character["inventory"]["equipment"]["legs"]) {
        $equiped_item = $character["inventory"]["equipment"]["legs"];
        $equiped_item_id = key($character["inventory"]["equipment"]["legs"]);
        
        unset($character["inventory"]["equipment"]["legs"][$equiped_item_id]);

        if($character["inventory"]["bag"][$equiped_item_id] != null) {
            $character["inventory"]["bag"][$equiped_item_id]["count"]++;
        } else {
            $character["inventory"]["bag"][$$equiped_item_id] = $equiped_item[$equiped_item_id];
        }
    } else {
        $character["inventory"]["equipment"]["legs"][$target] = $character["inventory"]["bag"][$target];

        if($character["inventory"]["bag"][$target]["count"] > 1) {
            $character["inventory"]["bag"][$target]["count"]--;
        } else {
            unset($character["inventory"]["bag"][$target]);
        }
    }
} else if($character["inventory"]["bag"][$target]["equipe"]["slot"] == "feet") {
    if($character["inventory"]["equipment"]["feet"]) {
        $equiped_item = $character["inventory"]["equipment"]["feet"];
        $equiped_item_id = key($character["inventory"]["equipment"]["feet"]);
        
        unset($character["inventory"]["equipment"]["feet"][$equiped_item_id]);

        if($character["inventory"]["bag"][$equiped_item_id] != null) {
            $character["inventory"]["bag"][$equiped_item_id]["count"]++;
        } else {
            $character["inventory"]["bag"][$$equiped_item_id] = $equiped_item[$equiped_item_id];
        }
    } else {
        $character["inventory"]["equipment"]["feet"][$target] = $character["inventory"]["bag"][$target];

        if($character["inventory"]["bag"][$target]["count"] > 1) {
            $character["inventory"]["bag"][$target]["count"]--;
        } else {
            unset($character["inventory"]["bag"][$target]);
        }
    }
} else if($character["inventory"]["bag"][$target]["equipe"]["slot"] == "main_hand") {
    if($character["inventory"]["equipment"]["main_hand"]) {
        $equiped_item = $character["inventory"]["equipment"]["main_hand"];
        $equiped_item_id = key($character["inventory"]["equipment"]["main_hand"]);
        
        unset($character["inventory"]["equipment"]["main_hand"][$equiped_item_id]);

        if($character["inventory"]["bag"][$equiped_item_id] != null) {
            $character["inventory"]["bag"][$equiped_item_id]["count"]++;
        } else {
            $character["inventory"]["bag"][$$equiped_item_id] = $equiped_item[$equiped_item_id];
        }
    } else {
        $character["inventory"]["equipment"]["main_hand"][$target] = $character["inventory"]["bag"][$target];

        if($character["inventory"]["bag"][$target]["count"] > 1) {
            $character["inventory"]["bag"][$target]["count"]--;
        } else {
            unset($character["inventory"]["bag"][$target]);
        }
    }
}

$character["timestamps"]["last_activity"] = time();
file_put_contents("../charactersData/" . $character_name . ".json", prettyPrint(json_encode($character, JSON_FORCE_OBJECT)));
?>