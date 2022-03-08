<?php
require '../../vendor/autoload.php';
require '../statUtil.php';

use CpChart\Data;
use CpChart\Image;


$statData = getDataFromFile();
$data = new Data();
foreach ($statData as $lang => $values) {
    $data->addPoints($values, $lang);
}

$data->setAxisName(0, "Students");
$data->addPoints(['I', 'II', 'III', 'IV', 'V'], "Labels");
$data->setAbscissa("Labels");
//$data->setXAxisDisplay(AXIS_FORMAT_METRIC, []);
/* Create the 1st chart */
$image = new Image(450, 230, $data);
$image->setFontProperties(["FontName" => "../font/consola.ttf", "FontSize" => 10]);

$image->setGraphArea(60, 60, 450, 190);

$image->drawScale(["DrawSubTicks" => true]);
$image->setShadow(true, ["X" => 1, "Y" => 1, "R" => 0, "G" => 0, "B" => 0, "Alpha" => 10]);
$image->drawLineChart();
$image->setShadow(false);
$image->drawLegend(340, 10);
$image->autoOutput("example.drawLineChart.png");