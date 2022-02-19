from math import sqrt, pi as PI


def solve(s1: float, s2: float):
    return sqrt((s1 + s2) / PI)


for s1, s2 in [(108.25, 139.93)]:
    print(format(solve(s1, s2), '.3f'))
