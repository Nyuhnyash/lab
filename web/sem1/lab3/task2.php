<title>Задание 2</title>
<?php
foreach(range(1, 9) as $_)
    $array[] = rand(0, 9);

echo 'Массив: ' . join(', ', $array);

const searchedValue = 4;
$found = array_search(searchedValue, $array)
?>
<div style="color: <?= $found ? 'green' : 'red' ?>"><?= $found ? 'Есть' : 'Нет' ?>!</div>