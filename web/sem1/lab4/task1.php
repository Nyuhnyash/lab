<title>Задание 1</title>
<style>
    html { background-color: lightgreen; }
    .tbl {
        display: grid;
        grid-template: repeat(10, auto) / repeat(10, auto);
    }

    .tbl > * {
        border-width: 1px;
        border-style: solid;
        border-color: black;
        padding: 10px;
    }

    .tbl-special {
        font-style: italic;
    }
</style>
<?php

class Table {
    private string $operator;
    private string $special_color;

    public function __construct($operator) {
        $this->operator = $operator;
        $this->special_color = $operator == '+' ? 'coral' : 'yellow';
    }

    private function print_cell($text = '', $special = false) {
        echo "<div" . ($special
            ? " class='tbl-special' style='background-color: $this->special_color;'" : '')
             . ">$text</div>";
    }

    public function print() {
        echo '<div class="tbl">';
        $this->print_cell('', special: true);
        foreach (range(1, 9) as $i)
            $this->print_cell($i, special: true);
        foreach (range(1, 9) as $i) {
            $this->print_cell($i, special: true);
            foreach (range(1, 9) as $j) {
                eval("\$res = $i $this->operator $j;");
                $this->print_cell("$i $this->operator $j = <strong>$res</strong>");
            }
        }
        echo '</div>';
    }
}


?>
<?php $addition_toggle = $_GET['addition_table'] ?? 0 ?>
<a href="?addition_table=<?= !$addition_toggle ?>">Таблица сложения</a>
<?php if ($addition_toggle) (new Table('+'))->print_table(); ?>
<br>
<?php $multiply_toggle = $_GET['multiply_table'] ?? 0 ?>
<a href="?multiply_table=<?= !$multiply_toggle ?>">Таблица умножения</a>
<?php if ($multiply_toggle) (new Table('*'))->print_table(); ?>
