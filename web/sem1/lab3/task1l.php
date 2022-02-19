<html>
<head>
    <meta charset="utf-8">
    <title>Тестовый пример</title>
</head>
<body>
<p>
    <?php
    $date = date("N");
    switch ($date) {
        case 1:
            echo "Доброго понедельника! ";
            break;
        case 2:
            echo "Доброго вторника! ";
            break;
        case 3:
            echo "Доброй среды! ";
            break;
        case 4:
            echo "Доброго четверга! ";
            break;
        case 5:
            echo "Доброй пятницы! ";
            break;
        case 6:
            echo "Доброй субботы! ";
            break;
        case 7:
            echo "Доброго воскресенья! ";
            break;
    }
    $day = date("z") + 1;
    echo 'Сегодня ' . $day . ' ';
    echo 'день с начала ' . date("Y") . ' года';
    $dayCurrent = date('z');
    $monthCurrent = date('n');
    $dDif = '';
    $listDate = array("3,4,5" => date('z', strtotime(date('Y-03-01'))),
        "6,7,8" => date('z', strtotime(date('Y-06-01'))),
        "9,10,11" => date('z', strtotime(date('Y-09-01'))),
        "1,2,12" => date('z', strtotime(date('Y-12-01'))),
    );
    $daysInYear = date('L') ? 366 : 365;
    foreach ($listDate as $key => $item) {
        if (!str_contains($key, $monthCurrent)) {
            continue;
        }
        if (str_contains($key, "1,2,12")) {
            $dDif = (int)($dayCurrent) + $daysInYear - $item + 1;
        } else
            $dDif = $dayCurrent - $item + 1;
    }

    echo ', ' . $dDif . ' день осени';
    ?>
</p>
</body>
</html>
