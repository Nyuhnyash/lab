from typing import Callable, Iterable


def get_dict_fixed(f: Callable, seq: Iterable):
    dct = {}
    for x in seq:
        dct[x] = f(x)

    return dct


def get_dict(x, *params):
    return get_dict_fixed(x, params)


print(get_dict_fixed(lambda x: x**2, [1, 2, 3, 4, 5]))
print(get_dict(lambda x: x**2, 1, 2, 3, 4, 5))
