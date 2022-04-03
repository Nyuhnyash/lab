from typing import Sequence


def func_fixed(x: float, coefficients: Sequence[int]):
    res = coefficients[0]
    for k in coefficients[1:]:
        res += x * k
        x *= x

    return res


def func(x, *params):
    return func_fixed(x, params)


print(func_fixed(1, [1, 2, 3]))
print(func(1, 1, 2, 3))
