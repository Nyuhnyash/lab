// #1
const randInt = () => Math.round(Math.random() * 10);
const a = randInt();
const b = randInt();

const input = prompt(`${a}x = ${b}; Чему равен x?`);
alert(a * input === b ? "Ok" : "Fail");

// #2
const now = new Date();
const tommorow = new Date();
tommorow.setHours(0,0,0,0);
tommorow.setDate(now.getDate() + 1);
console.log(tommorow - now);

// #3
const upperBound = 1e6;
let sum = 0;
console.time();
for (let i = 0; i < upperBound; i++) {
    sum += i * i;
}
console.timeEnd();


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