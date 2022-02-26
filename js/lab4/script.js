"use strict";

const randArray = (count = 5, upperBound = 10) =>
    Array.from(new Array(count), () => Math.floor(Math.random() * upperBound));

// #1
let array = randArray();
console.log(array);
let needle = Number(prompt('Искомый элемент'));
console.log(array.includes(needle) ? needle : 'Not found');

// #2
array = Array.from(new Array(5), () => Number(prompt('Введи число')));
console.log(array);

// #3
array = randArray();
console.log(array);
needle = Number(prompt('Искомый элемент'));
let needleIndex = array.indexOf(needle);
if (needleIndex !== -1) {
    array.splice(needleIndex, 1);
    console.log(array);
}

// #4
array = randArray();
const extra = prompt('Введите числа через запятую').split(',').map(Number);
console.log(array.concat(extra))

// #5
array = randArray();
console.log(array);
console.log(array.map(e => e % 2 === 0 ? e / 2 : e));

// #6
array = randArray();
console.log(array);
const upperBound = Number(prompt('Верхняя граница'))
console.log(array.filter(e => e < upperBound));

// #7
const olympics = randArray(3);
let [gold = 0, , bronze = 0] = olympics;
console.log(gold, bronze);
