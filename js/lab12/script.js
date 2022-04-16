function loadData() {
    const username = 'user';
    const password = 'test';

    const url = 'https://796b-46-20-75-201.eu.ngrok.io/games';
    return fetch(url, {
        headers: {
            Authorization: `Basic ${btoa(`${username}:${password}`)}`,
        },
    }).then(r => r.json());
}

const table = document.querySelector('table > tbody');
const rowTemplate = document
    .querySelector('template')
    .content.querySelector('tr');
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
        
        link.href = game.link;
        link.innerText = game.name;
        if (game.released) {
            price.innerText = game.price === 0 ? 'БЕСПЛАТНО' : game.price + '₽';
            priceDiscount.innerText =
                game.price === 0 ? '' : game.discountPrice + '₽';
            discount.innerText =
                game.discountPercent == 0 ? '' : game.discountPercent + '%';
        } else {
            price.innerText = game.releasedDate ?? 'Скоро в продаже';
            priceDiscount.innerText;
        }
    }
}

function filterAndSort() {
    console.log('---- Фильтры: ---');
    for (const field of filterFormFields) {
        console.log(field, form[field].value)
    }

    function rangeFilter(field, min, max) {
        return e => {
            const value = e[field];
            if (!min || !max) {
                return true;
            }
            if (!value === null
                || !e.released
                || min > value || value > max) {
                return false;
            }

            return true;
        }
    }

    return data
        .filter(e =>
            form.name.value
                ? new RegExp(form.name.value, 'i').test(e.name)
                : true
        )
        .filter(rangeFilter('price', form.priceMin.value, form.priceMax.value))
        .filter(rangeFilter('priceDiscount', form.priceDiscountMin.value, form.priceDiscountMax.value))
        .filter(rangeFilter('discount', form.discountMin.value, form.discountMax.value))
        .filter(e => {
            const inLibrary = form.inLibrary.value;
            if (inLibrary && inLibrary !== '') {
                return String(e.inLibrary) === inLibrary;
            }
            
            return true;
        })
        .sort((a, b) => {
            const sortField = form.sortBy.value;
            const order = form.orderBy.value;
            if (a[sortField] < b[sortField]) return -1 * order;
            if (a[sortField] > b[sortField]) return  1 * order;
            return 0;
        });
}

const filterFormFields = [
    "name",
    "priceMin",
    "priceMax",
    "priceDiscountMin",
    "priceDiscountMax",
    "discountMin",
    "discountMax",
    "inLibrary",
    "orderBy",
];

function saveFilterFormValues() {
    for (const field of filterFormFields) {
        localStorage[field] = form[field].value;
    }
}

function restoreFilterFormValues() {
    for (const field of filterFormFields) {
        form[field].value = localStorage[field];
    }
}

function onFilterFormChange(ev) {
    filteredData = filterAndSort();
    saveFilterFormValues();

    currentPage = 1;
    const page = getPage(filteredData);
    updateTable(page);
    changePageCountView();
}

function nextPage(ev) {
    if (currentPage < Math.ceil(filteredData.length / paginationStep.value)) {
        currentPage++;
        return;
    }
    ev.preventDefault();
}
function prevPage(ev) {
    if (1 < currentPage) {
        currentPage--;
        return;
    }
    ev.preventDefault();
}

function changePageCountView() {
    pagination.innerHTML = '';
    
    pagination.insertAdjacentHTML('beforeend', '<li class="page-item"><a id="prevPage" class="page-link" href="#"">Предыдущая</a></li>');
    const pageCount = Math.ceil(filteredData.length / paginationStep.value);
    console.log(pageCount)

    
    for (let i = 0; i < pageCount; i++) {
        pagination.insertAdjacentHTML(
            "beforeend",
            `<li class="page-item"><a class="page-link" href="#">${i + 1}</a></li>`
        );
    }

    pagination.insertAdjacentHTML('beforeend', '<li class="page-item"><a id="nextPage" class="page-link" href="#"">Следующая</a></li>');

}
/**
 * @param  {array} data
 */
function getPage(data) {
    const step = paginationStep.value;
    return data.slice((currentPage - 1) * step, currentPage * step);
}

/** @type {array} */ 
let data;

let filteredData;

const form = document.forms.filterForm;
let currentPage;
const paginationStep = document.getElementById('paginationStep');
const pagination = document.querySelector('.pagination');

(async () => {
    data = await loadData();
    restoreFilterFormValues();
    onFilterFormChange();
    
    form.addEventListener('change', onFilterFormChange);

    paginationStep.addEventListener('change', ev => {
        changePageCountView();
    })

    pagination.addEventListener('click', ev => {
        
        if (ev.target.id === "prevPage") {
            prevPage(ev);
        } else if (ev.target.id === "nextPage") {
            nextPage(ev);
        } else {
            currentPage = new Number(ev.target.innerText);
        console.log('dfdfd')

        }

        const page = getPage(filteredData);
        updateTable(page);

        console.log(currentPage)
    })

    changePageCountView();

})();
