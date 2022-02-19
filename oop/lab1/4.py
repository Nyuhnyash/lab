def solve(gnome_count: int, apple_weight: float):
    for _ in range(gnome_count):
        apple_weight -= apple_weight / 100 + 1
    return apple_weight


print(solve(100, 200))
