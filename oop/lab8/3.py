from math import sqrt


def only_squares(array: list[int]):
    for num in array:
        if sqrt(num).is_integer():
            yield num


numbers = [1, 2, 3, 4, 5, 6]
print(list(only_squares(numbers)))
