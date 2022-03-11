
f = dict()
for n in range(1, 40 + 1):
    if n in [1, 2]:
        f[n] = 1
        continue
    f[n] = f[n - 1] + f[n - 2]

print(f)
