// #1
function loadData() {
    const username = 'user';
    const password = 'test';

    const url = 'https://0711-46-20-75-201.eu.ngrok.io/games';
    return fetch(url, {
        headers: {
            Authorization: `Basic ${btoa(`${username}:${password}`)}`,
        },
    }).then(r => r.json());
}

// #4
const table = document.querySelector('table > tbody');
const rowTemplate = document.querySelector('template').content.querySelector('tr');
function updateTable(rows) {
    table.innerHTML = '';
    for (const game of rows) {
        const row = rowTemplate.cloneNode(true);
        table.appendChild(row);

        const img = row.querySelector('.game-img');
        const link = row.querySelector('.game-link');
        const price = row.querySelector('.game-price');
        const priceDiscount = row.querySelector('.game-price-discount');
        const discount = row.querySelector('.game-discount');
        
        if (!game.image) {
            img.remove();
        } else {
            img.src = game.image + '&w=150&h=1';
        }
        // const e = document.createElement('div');
        // e.innerText = game.released;
        // info.appendChild(e);
        link.href = game.link;
        link.innerText = game.name;
        if (game.released) {
            price.innerText = game.price === 0 ? 'БЕСПЛАТНО' : game.price + '₽';
                priceDiscount.innerText = game.price === 0  ? '' : game.discountPrice + '₽';
            discount.innerText = game.discountPercent == 0 ? '' : game.discountPercent + '%';
        } else {
            price.innerText = game.releasedDate ?? 'Скоро в продаже';
            priceDiscount.innerText
        }
    }
}

function filterAndSort() {
    console.log('---- Фильтры: ---')
    console.log(form.name.name, form.name.value);
    console.log(form.priceMin.name, form.priceMin.value);
    console.log(form.priceMax.name, form.priceMax.value);
    console.log(form.priceDiscountMin.name, form.priceDiscountMin.value);
    console.log(form.priceDiscountMax.name, form.priceDiscountMax.value);
    console.log(form.inLibrary[0].name, form.inLibrary.value);
    console.log(form.sortBy.name, form.sortBy.value);

    return data.filter(e => {
        if (!form.title.value) {
            return true;
        }

        return new RegExp(form.title.value, 'i').test(e.name)
    })
    .sort((a, b) => {
        const sortField = form.sortBy.value;
        if (a[sortField] < b[sortField]) return -1;
        if (a[sortField] > b[sortField]) return 1;
        return 0
    });
}

const form = document.forms.filterForm;

let data;
(async () => {
    data = await loadData();
    
    updateTable(data);
    form.addEventListener('change', ev => {
        const filteredData = filterAndSort();
        updateTable(filteredData);
    })

})();
