def solve(n: int):
    k = 0
    while n > k ** 2:
        k += 1
        n -= k ** 2
    return k, n


for n in [15, 30, 155, 5555]:
    print(solve(n))
