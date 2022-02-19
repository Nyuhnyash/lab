from msvcrt import getwch


def alphabet():
    for i in range(ord('а'), ord('я') + 1):
        yield chr(i)
    yield 'ё'
    return


ALPHABET = list(alphabet())

print('Введите слово на русском: ', end='')
string_buffer = list()
ch = None
while(ch != '\r'):
    ch = getwch().lower()
    if ch in ALPHABET:
        print(ch, end='')
        string_buffer += ch

    if ch == '\x08' and 0 < len(string_buffer):
        print('\x08 \x08', end='')
        string_buffer.pop()
else:
    print()

for i in range(len(string_buffer)):
    print(''.join(string_buffer[i::]))
