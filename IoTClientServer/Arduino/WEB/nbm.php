<?php
session_start();
if (!isset($_SESSION['nombreATrouver'])) {
    $_SESSION["nombreATrouver"] = rand(1, 1000);
}

if (isset($_GET["nombre"])) {
    $nombre_a_tester = $_GET["nombre"];
    $response = "";

    if ($nombre_a_tester == $_SESSION['nombreATrouver']) {
        $response = "=";
        session_destroy();
    } elseif ($nombre_a_tester > $_SESSION['nombreATrouver']) {
        $response = "+";
    } elseif ($nombre_a_tester < $_SESSION['nombreATrouver']) {
        $response = "-";
    }
    echo $response;
}
?>

