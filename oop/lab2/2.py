from math import exp, log, sin, sqrt


def f(a, b, c, x):
    return (sqrt(exp(a*x) + x**2)*log(x**2+b*x+10)) / (sin(c*x) + 4.2)


for a, b, c, x in [(5.7, 6.4, 3.1, 2.8)]:
    print(format(f(a, b, c, x), '.2f'))
