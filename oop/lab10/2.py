from itertools import islice
from random import random


def rand(n):
    u = 0
    a = random()
    b = random()
    while True:
        yield u
        u = (a * u + b) % n
r = list(islice(rand(10), 10))
print(r)