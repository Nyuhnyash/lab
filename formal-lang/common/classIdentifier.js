const isNonterminal = require('./isNonterminal');


module.exports = function (grammar) {
    const keys = Object.keys(grammar);
    const values = Object.values(grammar).flat();

    // нет нетерминалов в исходной строке
    if ( ! keys.flatMap(r => [...r]).some(isNonterminal)) {
            return 'incorrect';
    }

    // укорачивающие грамматики
    for (const [key, values] of Object.entries(grammar)) {
        if (values.some(value =>
            value.length !== 0 // пропускаем пустую строку
            && key.length > value.length)
        )
            return 'unrestricted';
    }

    // контекстно-свободные грамматики

    if (keys.some(key => key.length !== 1)) {
        return values.every(variant => variant.length !== 0)
            ? 'context-sensitive'
            : 'unrestricted';
    }

    // линейная
    const isLinear = values.every(variant => {
        if (variant.length === 0) return true;
        const nonterminalCount = [...variant].filter(isNonterminal).length;
        return nonterminalCount <= 1;
    });
    if (isLinear) {
        return values
            .filter(variant => [...variant].some(isNonterminal))
            .every(variant => isNonterminal(variant.at(-1)))
            ? 'right-regular (right-linear)'
            : 'linear';
        }
    

    return 'context-free';
}
