const Grammar = require("../common/grammar");


const input = require("./input.json")
const grammar = new Grammar(input);

// #1
const isRight = grammar.getClass().includes("right-linear");
console.log(`Grammar is ${isRight ? "" : "not "}right-linear`);

if (!isRight) return;

// #2
const stateMachine = grammar.toStateMachine();
console.log(stateMachine);

// #3
const isDetermined = stateMachine.deltas
        .map(delta => (delta.from + delta.value))
        .length
    === new Set(stateMachine.deltas.map(delta => (delta.from + delta.value))).size;
console.log(`Grammar is ${isDetermined ? "" : "not "}determined`);

