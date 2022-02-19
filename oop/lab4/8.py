from random import random


# n = int(input())
# k = int(input())

n = 10
k = 3

a = [random() for _ in range(n)]
print(a)
b = a[-k:] + a[:n - k]
print(b)