const Grammar = require("../common/grammar");


(async () => {
    const input = require("./input.json");
    // const grammar = new Grammar(input);

    const grammar = await Grammar.parseFromReadStream(process.stdin);
    console.log(grammar.data)
    // #1
    console.log("Chomsky grammar class:", grammar.getClass());

    // #2
    for (let i = 1; i <= 10; i++) {
        console.log(i, '-', grammar.generateRandomWord());
    }
})();
