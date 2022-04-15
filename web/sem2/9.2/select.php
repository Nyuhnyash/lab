<form>
    <label>ФИО
        <input name="fio">
    </label>
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
    $conn = mysqli_connect("i54jns50s3z6gbjt.chr7pe7iynqr.eu-west-1.rds.amazonaws.com", "xluqi36zvo66mrf6", "y2y0j86qrkayi6vk", "xd6g6am3xoko3hza") or 
        die("Невозможно установить соединение: ". mysqli_error($conn));
    
    $fields = empty($field) ? "*" : "fio, $field";
    
    $sql = "select $fields from student";

    if ($field == 'course') {
        $course = $_GET['course'];
        $sql = $sql . " where course = $course";
    }

    if ($fio = $_GET['fio']) {
        $sql = $sql . " where fio like '%$fio%'";
    }



    $order_field = empty($field) ? "fio" : $field;
    $sql = $sql . " order by $order_field $order";
    
    $response = mysqli_query($conn, $sql);
    if (!$response) {
        var_dump(mysqli_error($conn));
        die;
    }
    while($rows = mysqli_fetch_array($response, MYSQLI_ASSOC)) {
        echo join(" ", $rows) . "<br>";
    }
    mysqli_close($conn);
}
