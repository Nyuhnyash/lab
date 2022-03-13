import math


def euclid(a, b, c):
    x = 0
    y = 0
    nod_ab = math.gcd(abs(a), abs(b))
    a //= nod_ab
    b //= nod_ab
    c //= nod_ab
    for k in range(abs(a)):
        if (c - b * k) % a == 0:
            y = k
            x = (c - b * y) // a
            break
    return x > 0 and y > 0


def cond(x): return x % 16 == 0 and euclid(15, 23, x)


res = set(filter(cond, range(1, 201)))
print(sorted(res))
