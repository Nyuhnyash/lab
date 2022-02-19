"use strict";
// #1
const greeting = 'Hello world';
console.log(greeting);

// #2
alert(greeting);

// #3
// 1) ошибка
// 2) undefined

// #4
const name = 'Имя';
const surname = 'Фамилия';

console.log(name + ' ' + surname);
console.log(`${name} ${surname}`);

// #5
console.log((prompt('Введите слово').length));

// #6
const K = 1.609344;
alert((K * prompt()).toFixed(2));

// #7
let value;
let double = typeof(typeof(value));
console.log(double);
// string

// #8
function printTest(value) {
    console.log(value == '10');
    console.log(Boolean(value / 10 - 2));
    console.log(value < 15);
    console.log(Boolean(value - 20));
    console.log(value !== 20);
}

printTest(10);
printTest(20);

// #9
console.log(Math.sign(prompt()) === 1);

// #10
[
    "" + 1 + 0,
    "" - 1 + 0,
    true + false,
    6 / "3",
    "2" * "3",
    4 + 5 + "px",
    "$" + 4 + 5,
    "4" - 2,
    "4px" - 2,
    7 / 0,
    "  -9  " + 5,
    "  -9  " - 5,
    null + 1,
    undefined + 1,
    (12 < 5) || !('one' === 'one') && (24 > 0),
    null && !(17 > 4) || ('text'.length === 4)
].forEach(function(value) {
    console.log(value, typeof(value))
})

