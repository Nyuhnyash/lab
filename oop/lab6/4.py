# inp = input()
inp = '1 2 3 4 1 2 3'
numbers = list(map(int, inp.split()))
numbers_unique = set()
for number in numbers:
    print('YES' if number in numbers_unique else 'NO')
    numbers_unique.add(number)
