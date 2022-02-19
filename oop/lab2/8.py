from math import sqrt
# S = ab
# P = 2a + 2b
# P = 2 (S / b) + 2b
# Pb = 2S + 2b^2
# 2b^2 - Pb + 2S = 0


def is_rectangle(s, p):
    d = p**2 - 4 * 2 * 2 * s
    if d < 0:
        return False

    b = (p + sqrt(d)) / (2 * 2)
    a = s / b
    return a, b


print(is_rectangle(2, 2))
