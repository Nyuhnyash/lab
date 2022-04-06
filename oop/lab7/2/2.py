import re


with open('jack.txt', mode='r', encoding='utf8') as f:
    full = f.read()

dic = {}
words = re.split(' |\n', full.replace(',', '').replace('.', ''))
for word in map(str.lower, words):
    try:
        dic[word] += 1
    except KeyError:
        dic[word] = 1

print(dic)