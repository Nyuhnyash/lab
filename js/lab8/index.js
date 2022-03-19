// #1

// #2

// #3

// #4
const [day, month, year] = prompt('DD MM YYYY').split(' ');
const date = new Date(year, month - 1, day);
console.log(date);

// #5
/**
 @param  {Date} date
 @returns {String} dd.mm.yyyy hh:mm
 */
function formatDate(date) {
    return new Intl.DateTimeFormat('ru', {
        day: '2-digit',
        month: '2-digit',
        year: 'numeric',
        hour: '2-digit',
        minute: '2-digit',
    })
        .format(date)
        .replace(',', '');
}