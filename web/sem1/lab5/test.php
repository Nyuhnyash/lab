Date: <?= "{$_GET['day']} {$_GET['month']}" ?>
<form>
    <button style="all: initial">
        <select name="day">
            <?php
            switch ($_GET['month']) {
                case 'Февраль': $daysCount = 28;break;
                default: $daysCount = 31;break;
            }
            foreach (range(1, $daysCount) as $m) {
                if ($m != $_GET['day']) echo "<option value='$m'>$m</option>";
                else echo "<option selected='selected' value='$m'>$m</option>";
            }?>
        </select>
    </button>

    <select name="month">
        <?php foreach (array('Январь', 'Февраль') as $m) {
            if ($m != $_GET['month']) echo "<option value='$m'><button>$m</button></option>";
            else echo "<option selected='selected' value='$m'><button>$m</button></option>";
        }
        ?>
    </select>
</form>