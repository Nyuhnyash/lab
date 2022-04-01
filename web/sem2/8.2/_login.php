<?php

if (isset($_POST['login'])
    && isset($_POST['password'])
) {
    $path = "password.txt";
    $file = file($path);
    foreach($file as $line) {
        if (str_starts_with($line, $_POST['login'] . ' ')) {
            if (!str_ends_with($line, $_POST['password'] . "\n"))
            {
                goto m;
            }
        }
    }

    if (!in_array($_POST['login'] . ' ' . $_POST['password'] . "\n", $file))
    {
        $f = fopen($path, "a");
        fprintf($f, "%s %s\n", $_POST['login'], $_POST['password']);
    }

    $_SESSION['login'] = $_POST['login'];
    $_SESSION['password'] = $_POST['password'];
}
m:
if (isset($_SESSION['login'])
    && isset($_SESSION['password'])
){
    return;
}

?>
<form action="" method="post">
    <div class="field">
        <label class="label" for="login">ФИО</label>
        <div class="control">
            <input class="input" id="login" name="login" placeholder="Иванов Иван Иванович">
        </div>
    </div>
    <div class="field">
        <label class="label" for="password">Пароль</label>
        <div class="control">
            <input class="input" id="password" name="password" type="password">
        </div>
    </div>
    <input class="button is-link" type="submit" value="Войти">
</form>
