<!DOCTYPE html>
<!--
Dit is opdracht 8 door Thijs Rijkers
-->
<html>
    <head>
        <meta charset="UTF-8">
        <title></title>
    </head>
    <body>
        <?php
        $datum = 14062016;
        $jaar = $datum %10000;
        $maand = $datum /10000 %100;
        $dag = $datum /1000000 %100;
        echo"Dit is een random datum boyz $dag-$maand-$jaar<br>";

        ?>
    </body>
</html>

