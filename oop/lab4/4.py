from itertools import islice
from math import sqrt


start = float(input())


def get(e):
    sum = 0
    while True:
        yield e
        sum += e
        e = sqrt(sum)

print(list(islice(get(start), 20)))