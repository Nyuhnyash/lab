"use strict";
// #1
const auto = {
    model: 'Tesla Model S',
    color: 'red',
    year: 2015,
};

const fieldName = prompt('Get field by name').toLowerCase();
console.log(auto[fieldName] ?? 'Not found');

// #2
const [key, value] = prompt('key:value').split(':');
if (value === 'null') {
    delete auto[key];
} else {
    auto[key] = value;
}
console.log(auto);

// #3
const storeGood = {
    number: 1,
    place: 1,
    weight: 2,
};

const shopGood = Object.assign({price: null}, storeGood);
shopGood.number++;
console.log({storeGood, shopGood});

// #4
const person = {
    name: 'Sam',
    years: 25,
};

const {name = null, years = null, height = null} = person;
console.log(name, years, height);

// #5
String.prototype.reverse = function () {
    return this.split('').reverse().join('');
};

console.log('abcdef'.reverse());