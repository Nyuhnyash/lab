from math import exp, cos, sqrt


def f(a, b, x):
    if x > 0:
        return cos(b*x) / (1 + x**2)
    else:
        return sqrt(exp(a*x))

res = 0
x = -5
while x <= 5 + 0.001:
    res += f(1.6, -1.2, x)
    x += 0.4
print(format(res, '.3f'))
