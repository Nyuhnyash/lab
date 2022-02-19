<title>Задание 2</title>
<?php
const variants = ['🍉', '🍒', '🍐', '🍓', '🎃'];
foreach (range(1, 3) as $_)
    $spin[] = rand(1, count(variants)) - 1;
?>
<style>
    body {
        margin: 15vh;
        text-align: center;
        font-size: 7em;
        background-size: cover;
        background-image: url(<?= match (count(array_unique($spin))) {
            1 => 'https://i.gifer.com/origin/d5/d5fc616eee7fe45299b6f164734f53de.gif',
            2 => 'https://pixabay.com/get/g9fef1c4a1b146ce1184d3b3e973804b264daf356666f24c8f6f12965dfefd5cf24eb50a03b9fa28f881a4335f3944c8e2b57e3a736cfa106f892d4a20fd695f5ae69a70f956873705512561de70007c3_1920.jpg',
            default => 'https://pixabay.com/get/gb186106a216a5f478fcbc03157a6097bd4bb17c433e211b2e40508b7f282fcd98fbb11f00e05cec45bb018099e62ab9ed44eb476244d02e3b2d070efde2fc5f28f1f18d1d7d31fee3f4026296b8345cf_1920.jpg',
        }; ?>);
    }

    a, a:hover, a:focus, a:active {
        text-decoration: none;
        color: inherit;
    }
</style>

<div><?php foreach ($spin as $i) echo variants[$i]; ?></div>
<a href="">🔄</a>
