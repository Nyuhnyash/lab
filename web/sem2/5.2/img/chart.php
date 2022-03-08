<?php
require '../vendor/autoload.php';
require "statUtil.php";

use CpChart\Chart\Pie;
use CpChart\Data;
use CpChart\Image;


list($byLang,) = getSums();

// Source: https://github.com/szymach/c-pchart/blob/master/resources/doc/3d_pie.md

/* Create and populate the Data object */
$data = new Data();
$data->addPoints($byLang, "ScoreA");
$data->setSerieDescription("ScoreA", "Application A");

/* Define the absissa serie */
$data->addPoints(array_keys($byLang), "Labels");
$data->setAbscissa("Labels");

/* Create the Image object */
$image = new Image(2000, 1000, $data, true);

$image->setFontProperties(["FontName" => "verdana.ttf", "FontSize" => 40, "R" => 80, "G" => 80, "B" => 80]);

$pieChart = new Pie($image, $data);
$image->setShadow(true, ["X" => 3, "Y" => 3, "R" => 0, "G" => 0, "B" => 0, "Alpha" => 10]);

/* Draw a splitted pie chart */
$pieChart->draw3DPie(700, 500, [
    "Radius" => 450,
    "SliceHeight" => 100,
    "DataGapAngle" => 10,
    "DataGapRadius" => 6,
    "Border" => true,
    "WriteValues" => true,
    "ValuePosition" => PIE_VALUE_OUTSIDE,
    "ValuePadding" => 160,
    "ValueR" => 0,
    "ValueG" => 0,
    "ValueB" => 0,
]);

/* Write the legend */
$image->setShadow(true, ["X" => 1, "Y" => 1, "R" => 0, "G" => 0, "B" => 0, "Alpha" => 20]);

$pieChart->drawPieLegend(1500, 30, [
    "Style" => LEGEND_NOBORDER,
    "Mode" => LEGEND_VERTICAL,
    "BoxSize" => 30,
    "Surrounding" => 20,
]);

/* Render the picture (choose the best way) */
$image->autoOutput("example.draw3DPie.png");