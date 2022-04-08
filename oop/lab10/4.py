from math import sqrt


def pow_fun(n):
    return lambda x: x ** n


sqr = pow_fun(2)
cube = pow_fun(3)

x = 1
while True:
    y = 2 * cube(x) + 17
    if sqrt(y).is_integer():
        break
    x += 1

print(x)
