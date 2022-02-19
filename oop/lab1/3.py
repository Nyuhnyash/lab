def solve(l1: float, l2: float):
    if (l1 / l2) >= 3:
        return l1 / 3
    elif (l1 / l2) >= 2:
        return l2
    else:
        return l1 / 2


for l1, l2 in [(12, 2.5), (12, 5), (12, 7)]:
    print(solve(l1, l2))

print(solve(float(input()), float(input())))
