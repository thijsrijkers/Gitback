<?php
//TODO: Implement no error reporting on final build
// Report all errors except E_NOTICE
//error_reporting(E_ALL ^ E_NOTICE);

/*define("DB_HOST", "johnny.heliohost.org");
define("DB_USER", "hpmold");
define("DB_PASS", "pizza12");
define("DB_NAME", "hpmold_ing");*/

define("DB_HOST", "localhost");
define("DB_USER", "HPdb");
define("DB_PASS", "moulding1500");
define("DB_NAME", "hpmoulding");

/*define("DB_HOST", "sql207.byethost14.com");
define("DB_USER", "b14_21791031");
define("DB_PASS", "pizza12");
define("DB_NAME", "b14_21791031_hpmoulding");*/

require("includes/classes/database.php");
require("includes/classes/session.php");
require("includes/classes/core.php");
require("includes/classes/url.php");

$db = new Database;
$core = new Core;
$session = new Session;
$url = new Url;

$page = $url->getPage();
$subPage = $url->getSubPage();
$get = $url->getGET();
$error = "";

function loggedIn()
{
    global $db;
    global $core;
    global $error;

    if (isset($_SESSION["id"]) && isset($_SESSION["name"])) {
        $db->query("SELECT id FROM users WHERE id = :id AND name = :name");
        $db->bind(":id", $_SESSION["id"]);
        $db->bind(":name", $_SESSION["name"]);
        $row = $db->resultset();

        if (empty(array_filter($row))) {
            //Wrong session data, possibly malicious
            session_unset();
            session_destroy();
            echo "Something went wrong with your session data, press f5 to try again.";
            die();
        } else {
            return true;
        }
    } elseif (isset($_POST["login-submit"])) {
        if ($core->processLogin()) {
            return true;
        } else {
            $error = "Something went wrong, please try again.";
        }
    }
    return false;
}

if ($page == "logout") {
    session_destroy();
    session_unset();
    header("Location: /");
    exit();
}

if (loggedIn()) {
    switch ($page) {
        case("dashUpdater"):
            require("includes/pages/dashUpdater.php");
            die();
            break;
        case("dump") :
            require("includes/pages/dump.php");
            die();
            break;
    }
    ?>

    <!DOCTYPE html>
    <html lang="nl">
    <head>
        <meta charset="UTF-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1, user-scalable=no">
        <link rel="shortcut icon" type="image/png" href="includes/img/icon.png"/>

        <title>Admin Area</title>

        <link href="../includes/css/bootstrap.css" rel="stylesheet" type="text/css">
        <link href="../includes/css/style.css" rel="stylesheet" type="text/css">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
        <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js"></script>
        <script src="includes/js/bootstrap.js" type="text/javascript"></script>
        <script src="includes/js/dashUpdater.js" type="text/javascript"></script>

        <link rel="stylesheet"
              href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/themes/smoothness/jquery-ui.css">

        <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
        <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
        <![endif]-->
    </head>
    <body>
    <div class="container-fluid">
    <?php
    require("includes/header.php");
    ?>
    <div class="row" id="mainRow">
    <div class="col-lg-2" id="body-menu-container">
        <?php require("includes/menu.php"); ?>
    </div>
    <div class="col-lg-10">
        <?php
        switch ($page) {
        case "current_order":
            require("includes/pages/current_order.php");
            break;
        case "machines":
            require("includes/pages/machines.php");
            break;
        case "orders":
            require("includes/pages/orders.php");
            break;
        case "errors":
            require("includes/pages/errors.php");
            break;
        case "startOrder":
            require("includes/pages/startOrder.php");
        break;
        case "sessionChange":
            require("includes/pages/sessionChange.php");
        break;
        case "administratie":
        if ($subPage != "dump") {
        ?>
        <div class='pageContent'> <?php
            }
            require("includes/pages/admin.php");
            exit();
            break;
            case "molds":
                require("includes/pages/molds.php");
                break;
            default:
                require("includes/pages/machines.php");
                break;
            }
            ?>
        </div>
    </div>
    <?php
} else {
    if (!empty(array_filter($get) && !empty($get["name"]))) {
        if ($get["name"] == "api") {
            $db->query("SELECT api FROM machines WHERE api = :api");
            $db->bind(":api", $get["param"]);
            $machines = $db->resultset();
            if (array_filter($machines)) {
                ?>
                <!DOCTYPE html>
                <html lang="nl">
                <head>
                    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
                    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js"></script>
                    <script src="includes/js/bootstrap.js" type="text/javascript"></script>
                    <script src="includes/js/dashUpdater.js" type="text/javascript"></script>
                    <meta charset="UTF-8">
                    <meta http-equiv="X-UA-Compatible" content="IE=edge">
                    <meta name="viewport"
                          content="width=device-width, initial-scale=1.0, maximum-scale=1, user-scalable=no">
                    <link rel="shortcut icon" type="image/png" href="includes/img/icon.png"/>

                    <title>Machine</title>

                    <link href="includes/css/bootstrap.css" rel="stylesheet" type="text/css">
                    <link href="includes/css/style.css" rel="stylesheet" type="text/css">

                    <link rel="stylesheet"
                          href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/themes/smoothness/jquery-ui.css">

                    <!--[if lt IE 9]>
                    <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
                    <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
                    <![endif]-->
                </head>
                <?php require("includes/machine.php");
            } else {
                $core->error404();
                exit();
            }
        }
    } else {
        ?>
        <!DOCTYPE html>
        <html lang="nl">
        <head>
            <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
            <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js"></script>
            <script src="includes/js/bootstrap.js" type="text/javascript"></script>
            <script src="includes/js/dashUpdater.js" type="text/javascript"></script>
            <meta charset="UTF-8">
            <meta http-equiv="X-UA-Compatible" content="IE=edge">
            <meta name="viewport"
                  content="width=device-width, initial-scale=1.0, maximum-scale=1, user-scalable=no">
            <link rel="shortcut icon" type="image/png" href="includes/img/icon.png"/>

            <title>Admin Area</title>

            <link href="includes/css/bootstrap.css" rel="stylesheet" type="text/css">
            <link href="includes/css/style.css" rel="stylesheet" type="text/css">

            <link rel="stylesheet"
                  href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/themes/smoothness/jquery-ui.css">

            <!--[if lt IE 9]>
            <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
            <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
            <![endif]-->
        </head>
        <div class="container-fluid">
        <div class="row">
        <div class="col-lg-2" id="body-menu-container"></div>
        <div class="col-lg-10">
        <?php require("includes/login.php"); ?>
        <div id="login-error"><?php echo $error;
    } ?>
    </div>
    </div>
    </div>
</div>
    </body>
    </html>
<?php } ?>
