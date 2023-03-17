const isNonterminal = require('./isNonterminal');


module.exports = function (grammar) {
    const keys = Object.keys(grammar);
    const values = Object.values(grammar).flat();

    // нет нетерминалов в исходной строке
    if ( ! keys.flatMap(r => [...r]).some(isNonterminal)) {
            return "incorrect";
    }

    // укорачивающие грамматики
    for (const [key, values] of Object.entries(grammar)) {
        if (values.some(value =>
            value.length !== 0 // пропускаем пустую строку
            && key.length > value.length)
        )
            return "unrestricted";
    }

    // контекстно-свободные грамматики

    if (keys.some(key => key.length !== 1)) {
        return values.every(variant => variant.length !== 0)
            ? 'context-sensitive'
            : 'unrestricted';
    }

    // линейная
    if (values.every(variant => variant.length === 0
        || [...variant].some(isNonterminal))) {

        return values.every(variant => variant.length === 0
            || isNonterminal(variant.at(-1)))
            ? 'right-regular (right-linear)'
            : 'linear';
    }

    return "context-free";
}
