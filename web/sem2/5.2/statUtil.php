<?php
function getInitDataArray() {
    foreach (array('Французский', 'Испанский', 'Итальянский', 'Португальский', 'Китайский') as $lang) {
        foreach (range(1, 5) as $course) {
            $data[$lang][$course] = 0;
        }
    }
    return $data;
}

function getDataFromFile($filename = 'data.txt') {
    $data = getInitDataArray();
    foreach (file($filename) as $line) {
        list(, , $course, , , $langRaw) = explode(';', $line);
        foreach (explode('|', $langRaw) as $lang) {
            $data[trim($lang)][$course]++;
        }
    }
    return $data;
}

function getSums($data = null) {
    if (is_null($data)) {
        $data = getDataFromFile();
    }
    foreach ($data as $lang => $i) {
        $byLang[$lang] = array_sum($i);
        foreach ($i as $j => $c) {
            $byCourse[$j] += $c;
        }
    }
    return array($byLang, $byCourse);
}