def prods_gen(a, b):
    for i, j in zip(a, b):
        yield i * j


a = (1, 2, 3)
b = (4, 5, 6)
prods = list(prods_gen(a, b))
print(sum(prods))