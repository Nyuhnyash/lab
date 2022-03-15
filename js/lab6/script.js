// #1
const calendar = document.querySelector('#calendar');
const cont = document.querySelectorAll('.fc-event-container');
const buttons = document.querySelectorAll('#calendar button[type=button]');
const types = document.querySelectorAll('.lgnd > .lgnd > div:last-child');
types.forEach(e => {
    console.log(e.innerText);
});

// #2
const last = document.getElementsByClassName('last')[0];
last.style.color = 'red';


// #3
const titleText = prompt('Enter header text:');
if (titleText) {
    const header = document.getElementsByTagName('h3')[0];
    header.innerText = titleText;
    header.style.fontStyle = 'italic';
}
// #4
let msgText = prompt('Enter message:');
const msg = document.getElementsByClassName('message')[0];
if (msgText) {
    const p = document.createElement('p');
    p.innerText = msgText;
    msg.appendChild(p);

    setTimeout(() => (p.hidden = true), 2000);
}

// #5
msgText = prompt('Enter message:');
if (msgText) {
    const p = document.createElement('p');
    p.innerText = msgText;
    msg.appendChild(p);
    setTimeout(() => p.remove(), 2000);
}

// #6
const limit = 10 + 1;
function printTable(operation) {
    if (!(['+', '*'].includes(operation))) {
        throw Error();
    }
    document.write('<table>');
    for (let i = 1; i < limit; i++) {
        document.write('<tr>');
        for (let j = 1; j < limit; j++) {
            document.write(`<td>${i} ${operation} ${j} = ${eval(i+operation+j)}</td>`)
        }
        document.write('</tr>');
    }
    document.write('</table>');
}



printTable('+')
printTable('*')
const tables =document.getElementsByTagName('table');
for (const table of tables) {
    table.style.fontFamily = 'Courier New';
}
