"use strict";
// #1
function calc(num, exp) {
    return num ** exp;
}

console.log(calc(2, 10));

// #2
const area = (width, height) =>
    width < 0 || height < 0 ? null : width * height;

console.log(area(5, 4));

// #3
function flood(from, to) {
    const sequence = Array.from(
        { length: to + 1 - from },
        (_, i) => from + i
    );
    setInterval(() => {
        console.log(sequence.join(" "));
    }, 1000);
}

flood(4, 8);

// #4
calc = {
    _a: 0,
    _b: 0,
    
    get a() {
        return this._a;
    },

    set a(value) {
        this._a = value;
    },

    get b() {
        return this._b;
    },

    set b(value) {
        this._b = value;
    },

    sum() {
        return this._a + this._b;
    },
    mul() {
        return this._a * this._b;
    },
};

calc.a = 5;
calc.b = 9;
console.log(calc.sum(), calc.mul());

// #5
class Car {
  /**
   * @param  {String} model
   * @param  {Number} year
   */
  constructor(model, year) {
    this.model = model;
    this.year = year;
  }
}
const cars = [
    new Car("Lada",  2005),
    new Car("UAZ",   1994),
    new Car("KAMAZ", 2009),
    new Car("Aurus", 2017),
    new Car("GAZ",   1972),
];

/**
 * @param {Car} car1
 * @param {Car} car2
 */
function compareByModelAsc(car1, car2) {
  return car1.model.localeCompare(car2.model)
}

/**
 * @param {Car} car1
 * @param {Car} car2
 */
 function compareByModelDesc(car1, car2) {
     return -compareByModelAsc(car1, car2);
 }

[
    compareByModelAsc,
    compareByModelDesc,
    (car1, car2) => car1.year - car2.year,
    (car1, car2) => -(car1.year - car2.year),
].forEach(compare => {
    cars.sort(compare);
    console.table([...cars]);
});
