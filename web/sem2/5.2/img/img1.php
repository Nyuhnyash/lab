<?php
ini_set("display_errors", "1");
error_reporting(E_ALL);
//Устанавливаем тип содержимого
header('content-type: image/png');
//Определяем размер изображения: 300x300 пикселей
$image = imagecreatefromjpeg('template1.jpeg');
//Определяем цвет фона – темно-серый
$dark_grey = imagecolorallocate($image, 102, 102, 102);
$white = imagecolorallocate($image, 0, 0, 0);
//Указываем путь к шрифту
$font_path = '../font/consola.ttf';
//Пишем текст
$string = "До окончания\nзаписи осталось\n\n\n\nдней";
$time = date_diff(new DateTime(), new DateTime('2022-04-01'))->days;

imagettftext($image, 22, 9, 80, 150, $white, $font_path, $string);
imagettftext($image, 100, 9, 90, 295, $white, $font_path, $time);

imagejpeg($image);
imagedestroy($image);
