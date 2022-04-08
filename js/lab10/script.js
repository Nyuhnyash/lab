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
function updateTable(data) {
    for (const game of data) {
        const row = rowTemplate.cloneNode(true);
        table.appendChild(row);

        const img = row.querySelector('.game-img');
        const link = row.querySelector('.game-link');
        const price = row.querySelector('.game-price');
        const priceDiscount = row.querySelector('.game-price-discount');
        const discount = row.querySelector('.game-discount');
        
        img.src = game.image;
        link.href = game.link;
        link.innerText = game.name;
        price.innerText = game.price === 0 ? 'БЕСПЛАТНО' : game.price + '₽';
        priceDiscount.innerText = game.discountPrice === 0 ? 'БЕСПЛАТНО' : game.discountPrice + '₽';
        discount.innerText = game.discountPercent + '%';
    }
}

(async () => {
    const data = await loadData();
    updateTable(data);
})();
