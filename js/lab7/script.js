// #1
const paragraphs = document.body.getElementsByTagName("p");
for (let p of paragraphs) {
    p.addEventListener("mousedown", ev => {
        alert(`Содержимое абзаца: ${p.innerText}`);
    });
}

// #2
const task2 = document.getElementById('task2');
const question = document.createElement("p");
question.innerText = "Cursor, what is your name?";
const cursors = [
    "default",
    "crosshair",
    "help",
    "move",
    "pointer",
    "text",
    "wait",
];

for (const cursorType of cursors) {
    const e = question.cloneNode(true);
    e.style.cursor = cursorType;
    task2.appendChild(e);
}

// #3
const image = document.body.getElementsByTagName('img')[0];
image.addEventListener('dblclick', ev => {
    const cur = ev.target;
    alert(`${cur.title}, ${cur.width} : ${cur.height}`);
});

// #4
const button = document.querySelector('input[type=button]');
const input = document.querySelector('input:not([type]),input[type=text]');
const list = document.getElementsByTagName('ol')[0];

function onButtonClick(ev) {
    if (!input.value) return;
    const li = document.createElement('li');
    li.innerText = input.value;
    input.value = '';
    list.appendChild(li);
}

button.addEventListener('click', onButtonClick);

// #5
const limit = 10 + 1;
function printTable(operation) {
    if (!(['+', '*'].includes(operation))) {
        throw Error();
    }
    document.write('<table>');
    for (let i = 1; i < limit; i++) {
        document.write('<tr>');
        for (let j = 1; j < limit; j++) {
            document.write(`<td>${eval(i+operation+j)}</td>`)
        }
        document.write('</tr>');
    }
    document.write('</table>');
}

printTable('+');
printTable('*');

function onMouse(ev) {
    if (ev.target.nodeName !== 'TD') return;
    console.log(ev.target)
    ev.target.style.backgroundColor = ev.type === 'mouseover' ? 'lightgreen' : null;
}

const tables = document.querySelectorAll('table');
for (const table of tables) {
    table.addEventListener('mouseover', onMouse);
    table.addEventListener('mouseout', ev => setTimeout(() => onMouse(ev), 80));
}
// tables.forEach(table => {
    // table.addEventListener('mouseover', onMouse);
    // table.addEventListener('mouseout', onMouse);
// });