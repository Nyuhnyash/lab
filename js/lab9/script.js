// #1
const inp = prompt("Формат: Имя Фамилия").split(' ');
try {
    if (inp.length != 2) {
        throw new Error("Invalid input");
    }
} catch (error) {
    alert(error.message);
}

// #2
const email = prompt("Email");
const isValid = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
    .test(email);
alert((isValid ? "Valid" : "Invalid") + " email");

// #3
if (localStorage.username) {
    alert(localStorage.username);
} else {
    localStorage.username = prompt("Name");
}

// #4
function printCookies() {
    document.cookie
        .split(';')
        .map(line => line.trim().split('='))
        .forEach(([name, value]) => console.log(name, value))
}

printCookies();
document.cookie = "token=test;max-age=10";
printCookies();

// #5
/**
 * @param  {Date} startDate
 * @param  {Date} endDate
 */
function printLessons(startDate, endDate) {
    const url = new URL('https://lk.samgtu.ru/api/common/distancelearning')
    url.searchParams.append('start', startDate.toISOString());
    url.searchParams.append('end', endDate.toISOString());
    fetch(url)
        .then(r => r.json())
        .then(lessons => {
            console.log(lessons.length);
            for (const lesson of lessons) {
                console.log(lesson.title, lesson.start);
            }
        });
}

printLessons(new Date('2022-01-01'), new Date('2022-03-31'));



