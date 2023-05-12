const isNonterminal = require('./isNonterminal');

module.exports = function(grammar) {
    const keys = Object.keys(grammar);
    const values = Object.values(grammar).flat();
    const entries = Object.entries(grammar);

    const fsm = {};

    fsm.start = ['S'];
    fsm.ends = entries.filter(([k,v]) => v.includes("")).map(([k,_])=> k);

    fsm.nonterminals = keys;
    fsm.terminals = [...new Set(values
        .flatMap(g => [...g])
        .filter(x => !isNonterminal(x))
    )];

    fsm.deltas = [];

    for (const [key, values] of entries) {
        for (const value of values) {
        fsm.deltas.push({from: key, value: value[0], to: value[1]})

        }
    }


    return fsm;

}