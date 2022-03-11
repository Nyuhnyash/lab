# line = input()


line = 'amsterdam'
letters = dict()
for c in line:
    if c not in letters:
        letters[c] = 0
    letters[c] += 1

for c in sorted(letters): print(c, letters[c], sep=': ')
