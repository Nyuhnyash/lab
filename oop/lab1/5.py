def solve(x0: float):
    x = x0
    k = 0
    while x < 0:
        k += 1
        x = 1 + x / k
    return k


print(solve(-100))
