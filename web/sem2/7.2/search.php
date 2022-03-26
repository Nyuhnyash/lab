<?php include "_auth-check.php" ?>
<meta charset="UTF-8">
<style>
    form * { display: block; }
    input[type='radio'], button { display: inline-block; }
    a { display: block}
</style>

<?php
$meeting_info = array(
    'Французский'   => array('2009-10-27 10:00', 433),
    'Испанский'     => array('2009-10-27 10:00', 431),
    'Итальянский'   => array('2009-10-29 10:00', 430),
    'Португальский' => array('2009-10-28 12:00', 434),
    'Китайский'     => array('2009-11-01 10:00', 432)
);

function date_format_ru($datetime) {
    return str_replace(
        array('Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'),
        array('января', 'февраля', 'марта', 'апреля', 'мая', 'июня', 'июля', 'августа', 'сентября', 'октября', 'ноября', 'декабря'),
        date_format($datetime, 'j M Y')
    ) . ' года';
}

function langCheckbox($lang) { return
    "<label>
        <input name='language' type='radio' value='$lang'>
        $lang
    </label>";
}
?>

<?php if (empty($_GET['language'])): ?>

<h2>Данные о студентах, записавшихся на языковые курсы</h2>
<form>
    Выберите язык
    <?php foreach (array('Французский', 'Испанский', 'Итальянский', 'Португальский', 'Китайский')
        as $lang) echo langCheckbox($lang) ?>

    <button type="submit">Найти</button>
</form>

<?php endif; ?>

<?php if ($searchedLang = $_GET['language']) {
    $lines = file('data.txt');
    asort($lines);
    echo "<p><strong>$searchedLang</strong> язык. Список слушателей:</p><hr><ol>";
    foreach($lines as $line) {
        list($name, $birthdate, $course, $email, $details, $lang_str) = explode(';', $line);
        if (strpos($lang_str, $searchedLang) !== false) {
            echo '<li>', implode('<br>', array(
                "$name\nСтудент $course курса\n",
                "<strong>Дата рождения:</strong> $birthdate",
                "<strong>E-mail:</strong> <a href='mailto:$email'>$email</a>",
                "<strong>Языковая подготовка:</strong> $details"
            )), '</li>'; 
            $found = True;
        }
    }
    if (!$found) {
        echo '<p style="color:red">Слушателей нет</p>';  
    }
} ?>
</ol><hr>

<?php $meeting_datetime = date_create($meeting_info[$searchedLang][0]);
        $meeting_date = date_format_ru($meeting_datetime);
        $meeting_time_h = date_format($meeting_datetime, 'H');
        $meeting_time_min = date_format($meeting_datetime, 'i');
        $aud = $meeting_info[$searchedLang][1];
        echo "<p>Организационное собрание для курсах языка - $searchedLang состоится <strong>$meeting_date</strong> года в </strong>$meeting_time_h<sup>$meeting_time_min</sup></strong> в аудитории $aud.</p>";
?>

<a href="statistics.php">Вывести статистику</a>
<hr>
<a href="show.php?q=peter">Пётры</a>
<a href="show.php?q=2">Имена начинающихся с гласной и оканчивающихся на согласную букву</a>
<a href="show.php?q=3">Отчества длиной от 7 до 10 букв</a>
<a href="show.php?q=gmail">Адреса электронной почты, зарегистрированные на сервере «gmail.com»</a>
<a href="show.php?q=email-providers">Почтовые серверы</a>

<a href="_logout.php">Выйти</a>