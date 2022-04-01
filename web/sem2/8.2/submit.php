<meta charset="UTF-8">
<?php
setlocale(LC_ALL, 'ru_RU', 'ru_RU.UTF-8', 'ru', 'russian');

$fields_ru = array(
    'languages' => 'Языки',
    'lastname' => 'Фамилия',
    'firstname' => 'Имя',
    'middlename' => 'Отчество',
    'birthdate' => 'Дата рождения',
    'course' => 'Курс',
    'email' => 'Email',
    'details' => 'Языковая подготовка',
    'phone' => 'Телефон',
);

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


$phone = '';
function validate($fields){
    $secret_key = "6Le6QiMfAAAAAPgSt8biMhMPJJX9gV0tzwwJT43p";
    $response = file_get_contents(
        'https://www.google.com/recaptcha/api/siteverify?secret='
        . $secret_key . '&response=' . $_POST['g-recaptcha-response']);

    if (!$response|| !json_decode($response)->success) {

        echo "<span style='color: red;'>Капча не пройдена</span>";
        die;
    }


    $errors = array();
    $re = array(
        'lastname' => '/^[А-ЯЁ][а-яё -]*$/u',
        'firstname' => '/^[А-ЯЁ][а-яё -]*$/u',
        'middlename' => '/^[А-ЯЁ][а-яё -]*$/u',
        'phone' => "/^(\+7|8)[0-9 -]{10}$/u",

    );

    foreach ($fields as $field) {
        if (empty($_POST[$field])) $errors[] = $field;
        else define($field, $_POST[$field]);
    }

    foreach ($re as $field => $pattern) {
        if (!preg_match($pattern, $_POST[$field])) {
            $errors[] = $field;
        }
    }

    if (!filter_var(email, FILTER_VALIDATE_EMAIL)) {
        $errors[] = 'email';
    }
    return empty($errors) ? true : array_unique($errors);
}

$validate = validate(array_slice(array_keys($fields_ru), 1));

if (is_array($validate)) {
    echo 'К сожалению, Вы не заполнили поля:</li>';
    echo '<ul>';
    foreach ($validate as $field) {
        echo "<li style='color: red;'>$fields_ru[$field]</li>";
    }

    echo '</ul>';
} else {
    if (isset($_FILES['photo'])) {
        $dirname = 'upload';
        if (!file_exists($dirname)) {
            mkdir($dirname);
        }
        $file_info = $_FILES['photo'];
        $filename = base64_encode(join(' ', [lastname, firstname, middlename]));
        $ext = pathinfo($file_info['name'], PATHINFO_EXTENSION);
        $path = join(DIRECTORY_SEPARATOR, [$dirname, $filename . '.' . $ext]);
        move_uploaded_file($file_info['tmp_name'],  $path);
    }

    $languages = $_POST['languages'];

    preg_match_all("/^(?:\+7|8)([0-9 -]{10})$/u", phone, $match);
    $phone = $match[1][0];
    $phone = sprintf('+7 %s %s-%s-%s',
        substr($phone, 0, 3),
        substr($phone, 3, 3),
        substr($phone, 6, 2),
        substr($phone, 8, 2)
    );

    $phone = isset($phone) ? $phone : 'Нет';

    $f = fopen('data.txt', 'a');
    fprintf($f, "%s %s %s;%s;%d;%s;%s;%s\n", lastname, firstname, middlename, birthdate, course, email, details, implode("|",$languages));

    echo 'Здраствуйте, ' . firstname . '!<br>
    Ваша заявка о прохождении языковых курсов получена.<br><br>
    <em>Регистрационные данные</em>
    <hr>
    <strong>Фамилия:</strong> ' . lastname . '<br>
    <strong>Имя:</strong> ' . firstname . '<br>
    <strong>Отчество:</strong> ' . middlename . '<br>
    <strong>Студент</strong> ' . course . ' курса<br>
    <strong>Дата рождения:</strong> ' . date_format_ru(date_create(birthdate)) . '<br>
    <strong>E-mail:</strong> ' . email . '<br>
    <strong>Телефон:</strong> ' . sprintf('%s', $phone) . '<br>
    <strong>Языковая подготовка:</strong> ' . str_replace("\r\n", '<br>', details) . '<br>
    <hr>';

    foreach ($languages as $lang) {
        $meeting_datetime = date_create($meeting_info[$lang][0]);
        $meeting_date = date_format_ru($meeting_datetime);
        $meeting_time_h = date_format($meeting_datetime, 'H');
        $meeting_time_min = date_format($meeting_datetime, 'i');
        $aud = $meeting_info[$lang][1];
        echo "<p>Организационное собрание на курсах испанского языка состоится <strong>$meeting_date</strong> года в </strong>$meeting_time_h<sup>$meeting_time_min</sup></strong> в аудитории $aud.</p>";
    }
}
?>
