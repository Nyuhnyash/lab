<?php
require "../statUtil.php";

ini_set("display_errors", "1");
error_reporting(E_ALL);
//Устанавливаем тип содержимого
header('content-type: image/png');
//Определяем размер изображения: 300x300 пикселей
$image = imagecreatefromjpeg('template2.jpeg');
//Определяем цвет фона – темно-серый
$dark_grey = imagecolorallocate($image, 102, 102, 102);
$white = imagecolorallocate($image, 0, 0, 0);
//Указываем путь к шрифту
$font_path = '../font/consola.ttf';
//Пишем текст
$string = "Количество\nзаписавшихся\nстудентов:";

imagefttext($image, 20, -12, 150, 110, $white, $font_path, $string);
imagefttext($image, 100, -12, 160, 280, $white, $font_path, getStudentsCount());

imagejpeg($image);
imagedestroy($image);
