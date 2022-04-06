from typing import Any, Callable


def multi_func(fun: Callable[[Any], Any], x, n: int):
    if n == 1:
        return fun(x)

    return multi_func(fun, fun(x), n - 1)

f = lambda x: x * 2
print(multi_func(f, 'Hi', 3))
print(f(f(f('Hi'))))
