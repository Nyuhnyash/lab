from random import randint
from numpy import arctan


points: list[tuple[int, int]] = []
for i in range(10):
    point = randint(-100, 100), randint(-100, 100)
    points.append(point)

phi = lambda x, y: arctan(x / y)
sortedByPhi = sorted(points, key=lambda p: -phi(p[0], p[1]))
print(sortedByPhi)
