<?php
$aRetourner = "";
if (isset($_GET["nbLettres"])) {
    $aCompter = $_GET["nbLettres"];
    $str = str_replace(" ", "", $aCompter);
    $nbLettres = strlen($aCompter);
    $aRetourner = "Il y a " . $nbLettres . " Lettres !";
}

if (isset($_POST["nbMots"])) {
    $aCouper = $_POST["nbMots"];
    $nbMots = count(explode(' ', trim($aCouper)));
    $aRetourner  = "Il y a " . $nbMots . " Mots !";
}
?>
<html>
<body>
<form method ="GET" action="index.php">
    <label for="nbLettres">Nombre de lettres : <?php echo $aRetourner ?></label>
    <input type ="text" name="nbLettres"/>
    <input type="submit"/>
</form>

<form method ="POST" action="index.php">
    <label for="nbMots">Nombre de mots : <?php echo $aRetourner ?></label>
    <input type ="text" name="nbMots"/>
    <input type="submit"/>
</form>

</body>
</html>

