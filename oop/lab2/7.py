from math import cos, pi, sqrt


def solve(s: float):
    return s / cos(pi/12) ** 2 * sqrt(3)/4


for s in [1, 48e12, 0.037]:
    print(format(solve(s), '.5g'))
