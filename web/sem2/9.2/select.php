<form>
    <select name="field">
        <option value=""></option>
        <option value="birthdate">День рождения</option>
        <option value="course">Курс</option>
    </select>
    <select name="order">
        <option value="asc">По возрастанию</option>
        <option value="desc">По убыванию</option>
    </select>
    <input name="course" type="range" min="1" max="5">
    <input type="submit">
</form>

<?php
if (!is_null($_GET['field'])) {
    $field = $_GET['field'];
    $order = $_GET['order'];
    $conn = mysql_connect("localhost", "root", "") or 
        die("Невозможно установить соединение: ". mysql_error());
    
    mysql_select_db('task9', $conn);
    $fields = empty($field) ? "*" : "fio, $field";
    
    $sql = "select $fields from students";

    if ($field == 'course') {
        $course = $_GET['course'];
        $sql = $sql . " where course = $course";
    }

    $order_field = empty($field) ? "fio" : $field;
    $sql = $sql . " order by $order_field $order";
    
    $response = mysql_query($sql, $conn);
    if (!$response) {
        var_dump(mysql_error());
        die;
    }
    while($row = mysql_fetch_array($response, MYSQL_ASSOC)) {
        print_r($row);
    }
    mysql_close($conn);
}
