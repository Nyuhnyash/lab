from math import exp, sin


def f(x):
    return (x + sin(2*x)) / (x*exp(-x))


for x in [-10, 22]:
    print(format(f(x), '.4g'))
