from typing import Callable


def sum_func(function: Callable[[float], float], *numbers: float) -> float:
    return sum(map(function, numbers))


def f(x): return x ** 2


print(sum_func(f, 1, 2, 3))
