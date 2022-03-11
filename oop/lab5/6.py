class Book:
    def __init__(self, author: str, name: str, year: int, sellsCount: int, **kwargs) -> None:
        self.author = author
        self.name = name
        self.year = year
        self.sellsCount = sellsCount


data = [
    Book('Гоголь', 'Мёртвые души', 1800, 3),
    Book('Гоголь', 'Вечера на хуторе близь Диканьке', 2022, 1),
    Book('Пушкин', 'Евгений Онегин', 1967, 1),
]

d = dict()
for rec in data:
    if rec.author not in d: d[rec.author] = 0
    d[rec.author] += rec.sellsCount

for c in sorted(d): print(c, d[c], sep=': ')


