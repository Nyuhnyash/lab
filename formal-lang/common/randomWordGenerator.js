module.exports = function randomWord(grammar, word = 'S') {
    let nextWord = '';
    for (const symbol of word) {
        const variants = grammar[symbol];
        nextWord += variants
            ? variants[Math.random() * variants.length | 0]
            : symbol;
    }

    return word === nextWord ? nextWord : randomWord(grammar, nextWord);
};
