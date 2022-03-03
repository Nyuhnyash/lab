<style xmlns="http://www.w3.org/1999/html">
    table, td, th {
        border-style: solid;
        border-width: 1px;
        border-collapse: collapse;
        padding: 10px;
        text-align: center;
    }

    #total { font-weight: bold; }

    #top { background-color: lightsalmon; }
</style>

<?php
include 'statUtil.php'

?>

<table>
    <thead>
    <tr>
        <th rowspan="2">Язык</th>
        <th colspan="5" scope="colgroup">Курс</th>
        <th rowspan="2">Всего</th>
    </tr>
    <tr>
        <th>I</th>
        <th>II</th>
        <th>III</th>
        <th>IV</th>
        <th>V</th>
    </tr>
    </thead>
    <tbody>
    <?php
    $data = getDataFromFile();
    list($byLang, $byCourse) = getSums($data);
    $topLang = array_search(max($byLang), $byLang);

    foreach ($data as $lang => $courses):?>
        <tr
            <?php if ($lang == $topLang): ?>id="top"<?php endif; ?>
        >
            <td><?= $lang ?></td>
            <?php foreach ($courses as $amount): ?>
                <td><?= $amount ?></td>
            <?php endforeach; ?>
            <td id="total"> <?= $byLang[$lang] ?></td>
        </tr>
    <?php endforeach; ?>
    <tr>
        <th>Всего</th>
        <?php foreach ($byCourse as $sum): ?>
            <td id="total"><?= $sum ?></td>
        <?php endforeach; ?>
        <td id="total"><?= array_sum($byCourse) ?></td>
    </tr>
    </tbody>
</table>

<img src="chart.php" width="100%">

<button onclick="window.location.href = window.referrer || 'search.php'">Назад</button>