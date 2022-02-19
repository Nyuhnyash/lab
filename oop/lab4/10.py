from random import randrange


array = [randrange(0, 100 + 1) for _ in range(30)]
passed = list(filter(lambda x: x >= 20, array))

print(min(passed) if passed else 0)