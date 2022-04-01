<?php
session_start();
?>
<meta charset="UTF-8">
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bulma@0.9.3/css/bulma.min.css">
<script src="https://www.google.com/recaptcha/api.js" async defer></script>
<style>
    form * { display: block; }
    input[type='checkbox'], button { display: inline-block; }
</style>

<?php
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

<form action="submit.php" method="post" enctype="multipart/form-data">
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


    <label>Email                     <input name="email" type="email"></label>
    <label>Телефон                   <input name="phone" type="text"></label>

    <label>Дополнительная информация <textarea name="details"></textarea></label>
    <label>Фото                      <input type="file" name="photo" accept="image/jpeg, image/png, image/gif"></label>

    <div class="g-recaptcha" data-sitekey="6Le6QiMfAAAAAOgK_a7GuJDuuGgL-IuYJGqanQ93"></div>
    <button type="submit">Отправить</button>
    <button type="reset">Отменить</button>
</form>

<div style="width: 300px">
<?php include "_login.php";
if (isset($_SESSION['login'])) {
    echo "Вход выполнен: ${_SESSION['login']}";
    echo '<br>';
    echo '<a href="_logout.php">Выйти</a>';
}

?>
</div>