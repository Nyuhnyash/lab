// #1
function loadData() {
  const url = "https://473b6556e55372.lhrtunnel.link/games";
  return fetch(url, {
    headers: {
      Authorization: `Basic ${btoa("user:test")}`,
    },
  }).then((r) => r.json());
}

// #4
function updateTable(data) {
  const table = document.getElementsByTagName("tbody")[0];
  console.log(table);
  for (const e of data) {
    const game = e.gameBase;
    const row = document.createElement("tr");
    const image = document.createElement("td");
    const img = document.createElement("img");
    img.src = game.image;
    img.width = 150;
    image.appendChild(img);

    const name = document.createElement("td");
    const a = document.createElement("a");
    const link = new URL(game.link);

    a.href = "https://store.epicgames.com/ru/p" + link.pathname;
    a.innerText = game.name;
    name.appendChild(a);

    const price = document.createElement("td");
    price.innerText = game.price === 0 ? "БЕСПЛАТНО" : game.price + '₽';

    const discountPrice = document.createElement("td");
    discountPrice.innerText = game.discountPrice === 0 
    ? "БЕСПЛАТНО" 
    : game.discountPrice + '₽';

    row.appendChild(image);
    row.appendChild(name);
    row.appendChild(price);
    row.appendChild(discountPrice);
    table.appendChild(row);
  }
}

(async () => {
  const data = await loadData();
  updateTable(data);
})();
