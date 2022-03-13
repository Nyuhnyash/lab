n = int(input())
total = set(range(1, n + 1))
while True:
    inp = input().upper()
    if inp == 'HELP':
        break

    guess = set(map(int, inp.split(' ')))
    verdict = input().upper()
    if verdict == 'YES':
        total &= guess
    elif verdict == 'NO':
        total -= guess

print(sorted(total))
