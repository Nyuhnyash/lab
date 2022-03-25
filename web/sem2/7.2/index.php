<meta charset="UTF-8">
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bulma@0.9.3/css/bulma.min.css">

<style>
    form * { display: block; }
    input[type='checkbox'], button { display: inline-block; }
</style>

<?php
session_start();
if (isset($_SESSION['login'])) {
    echo "Вход выполнен: ${_SESSION['login']}";
}

function courseRadio($course) { return
    "<label>
        <input name='course' type='radio' value='$course'>
        $course курс
    </label>";
}

function langCheckbox($lang) { return
    "<label>
        <input name='languages[]' type='checkbox' value='$lang'>
        $lang
    </label>";
}

?>

<h2>Форма записи на языковой курс</h2>

<form action="submit.php">
    <label>Фамилия       <input name="lastname"></label>
    <label>Имя           <input name="firstname"></label>
    <label>Отчество      <input name="middlename"></label>
    <label>Дата рождения <input name="birthdate" type="date" min="1900-01-01" max="<?= date('Y-m-d') ?>"></label>

    Курс
    <div id="courseRadio">
        <?php foreach (range(1, 5) as $lang) echo courseRadio($lang) ?>
    </div>

    Язык
    <?php foreach (array('Французский', 'Испанский', 'Итальянский', 'Португальский', 'Китайский')
        as $lang) echo langCheckbox($lang) ?>


    <label>Email  <input name="email" type="email"></label>
    <label>Телефон<input name="phone" type="text"></label>

    <label>
        <textarea name="details"></textarea>
    </label>

    <button type="submit">Отправить</button>
    <button type="reset">Отменить</button>
</form>

<div style="width: 300px">
<?php include "_login.php";?>
</div>