"use strict";
// #1
const age = prompt('Введите возраст:')
if (age < 18) {
    alert('Access Denied')
}

// #2
const age2 = prompt('Введите возраст:')
if (age2 < 18) {
    alert('Too young')
} else if (age2 > 75) {
    alert('Too old')
} else {
    alert('Access granted')
}

// #3
let gender_p = prompt('Введите пол:');
const gender = gender_p === 'F' 
    ? 'female' 
    : gender_p === 'M' ? 'male' : undefined;
console.log(gender);

// #4
const num = Number(prompt('Enter a number'));
switch (num) {
    case 0:
        alert(0);
        break;
    case 1:
        alert(1);
        break;
    case 2:
    case 3:
        alert('2, 3');
        break;
}

// #5
let n = 0;
let sum = 0;
while (n++ < 100) {
    sum += n;
}
console.log(sum);

// #6
const expression = '254 * 7 + (124 - 16) / 9';
const res = eval(expression); // 1790
let p;
do {
    p = prompt(expression + ' = ?');
} while (Number(p) !== res);
console.log('Success');

// #7
let prod = 1;
for(let n = prompt('Enter a number:'); n > 1; n--) {
    prod *= n;
}
console.log(prod);

// #8
let sum8 = 0;
while(true) {
    const input = prompt('Enter the next number:');
    if (input === '=') {
        console.log(sum8);
        break;
    }
    sum8 += Number(input);
}
