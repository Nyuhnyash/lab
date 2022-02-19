from cmath import cos


def f(a, b, c, x):
    return (a * x**3 + b) / (1 + cos(c * x))


for a, b, c, x in [(1+1j, 3.7, 2, -3+2j)]:
    print(format(f(a, b, c, x), '.3f'))
