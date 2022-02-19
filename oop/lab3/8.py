from msvcrt import getwch


print('Введите набор цифр: ', end='')
buffer = list()
ch = None
while(ch != '\r'):
    ch = getwch()
    if ch.isdecimal():
        print(ch, end='')
        buffer += ch

    if ch == '\x08' and 0 < len(buffer):
        print('\x08 \x08', end='')
        buffer.pop()
else:
    print()

numbersCounts = dict.fromkeys(range(10), 0)
for num in buffer:
    numbersCounts[int(num)] += 1

print(numbersCounts)
