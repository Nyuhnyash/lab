<?php

if (isset($_POST['login'])
    && isset($_POST['password'])
) {
    $_SESSION['login'] = $_POST['login'];
    $_SESSION['password'] = $_POST['password'];
    die;
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
