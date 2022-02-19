<title>Задание 1</title>
<?php
const dow = ['понедельника', 'вторника', 'среды', 'четверга', 'пятницы', 'субботы', 'воскресенья'];

function goodWeekDay($weekdayNum): string
{
    switch ($weekdayNum)
    {
        case 3:
            $good = 'Доброй';
            break;
        case 5:
        case 6:
            $good = 'Добрый';
            break;
        default:
            $good = 'Доброго';
    }

    return $good . " " . dow[$weekdayNum - 1];
}

const seasons = ['зимы', 'весны', 'лета', 'осени'];

function getSeasonNum($month): int
{
    switch ($month)
    {
        case 3:
        case 4:
        case 5:
            return 1;
        case 6;
        case 7;
        case 8;
            return 2;
        case 9;
        case 10;
        case 11;
            return 3;
        default:
            return 0;
    }
}

function getSeasonDay($month, $day): string
{
    $seasonDayOffset = 0;

    switch ($month)
    {
        case 2: $seasonDayOffset += 31;
        case 1: $seasonDayOffset += 31;
            break;
        case 5: $seasonDayOffset += 30;
        case 4: $seasonDayOffset += 31;
            break;
        case 8: $seasonDayOffset += 31;
        case 7: $seasonDayOffset += 30;
            break;
        case 11: $seasonDayOffset += 31;
        case 10: $seasonDayOffset += 30;
            break;
    }
    return sprintf('%s день %s',
        $seasonDayOffset + $day,
        seasons[getSeasonNum($month)]
    );
}
?>

<p>
    <?php printf("%s!<br> Сегодня %s день с начала %s года, %s.",
        goodWeekDay(date('N')),
        date('z') + 1,
        date('Y'),
        getSeasonDay(date('m'), date('j'))
    )?>
</p>