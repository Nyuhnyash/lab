<title>Задание 2</title>
<?php
$variants = array('🍉', '🍒', '🍐', '🍓', '🎃');
$spin = array();
foreach (range(1, 3) as $_)
    $spin[] = rand(1, count($variants)) - 1;


switch (count(array_unique($spin))) {
    case 1: $bg_image_source = 'https://i.imgur.com/0AFgHrV.gif'; break;
    case 2: $bg_image_source = 'https://i.imgur.com/HAhIwJh.jpg'; break;
    default:$bg_image_source = 'https://i.imgur.com/krIIwYJ.jpg'; break;
}
?>
<style>
    body {
        margin: 15vh;
        text-align: center;
        font-size: 7em;
        background-size: cover;
        background-image: url(<?= $bg_image_source ?>);
    }

    a, a:hover, a:focus, a:active {
        text-decoration: none;
        color: inherit;
    }
</style>

<div><?php foreach ($spin as $i) echo $variants[$i]; ?></div>
<a href="">🔄</a>
