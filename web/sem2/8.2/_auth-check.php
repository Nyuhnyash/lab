<?php session_start();
error_reporting(E_ERROR);
if (empty($_SESSION['login'])
    || empty($_SESSION['password'])
) {
    http_response_code(401);
    echo "Не авторизован";
    die;
} ?>