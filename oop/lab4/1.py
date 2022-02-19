def anograms(word, line):
    for ent in line.split():
        if ''.join(sorted(ent)) == word:
            yield ent


# word = input()
# line = input()

word = 'лось'
line = 'привет соль как дела'

print(word, list(anograms(word, line)))