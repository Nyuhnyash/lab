const Grammar = require("../common/grammar");


const input = require("./input.json");
const grammar = new Grammar(input);

// #1
console.log("Chomsky grammar class:", grammar.getClass());

// #2
for (let i = 1; i <= 10; i++) {
    console.log(i, '-', grammar.generateRandomWord());
}
