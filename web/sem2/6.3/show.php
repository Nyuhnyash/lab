<?php
$filename = 'data.txt';

switch ($_GET['q']) {
    case 'peter':
        foreach (file($filename) as $line) {
            list($fullname, , , , , ) = explode(';', $line);
            if (preg_match('/Петр/u', $fullname))
                echo $fullname . '<br';
        }
        break;
    case '2':
        foreach (file($filename) as $line) {
            list($fullname, , , , , ) = explode(';', $line);
            $name = explode(' ', $fullname)[1];

            if (preg_match('/^[аеёиоуэюяАЕЁИОУЭЮЯ]{1}[а-я]*[^аеёиоуэюяьъ]$/u', $name))
                echo $name . '<br';
        }
        break;
    case '3':
        foreach (file($filename) as $line) {
            list($fullname, , , , , ) = explode(';', $line);
            $patronymic = explode(' ', $fullname)[2];
            if (preg_match('/^.{7,10}$/u', $patronymic))
                echo $patronymic . '<br';
        }
        break;
    case 'gmail':
        foreach (file($filename) as $line) {
            $email = explode(';', $line)[3];
            if (preg_match('/^.+@gmail.com$/u', $email))
                echo $email . '<br';
        }
        break;
    case 'email-providers':
        foreach (file($filename) as $line) {
            $email = explode(';', $line)[3];
//            if (preg_match('/^.+@(.+)$/u', $email))
                echo $email . '<br';
        }
        break;
}

