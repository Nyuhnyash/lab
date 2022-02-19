counts = dict.fromkeys(('0', '1'), 0)

n = int(input('N: '))
for i in range(1, n + 1):
    for ch in format(i, 'b'):
        counts[ch] += 1

print(f"Количество нулей: {counts['0']}",
      f"Количество единиц: {counts['1']}",
      sep='\t')
