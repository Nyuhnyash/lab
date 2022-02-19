word = input('Слово: ')
k = int(input('k: '))

assert k < len(word), 'k должно быть меньше длины слова'

print(word[k:] + word[:k])
