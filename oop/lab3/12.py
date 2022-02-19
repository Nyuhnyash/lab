from msvcrt import getwch


ALPHABET = list(chr(code) for code in range(ord('A'), ord('Z') + 1))

print('Введите строку на латинице S: ', end='')
string_buffer = list()
ch = None
while(ch != '\r'):
    ch = getwch().upper()
    if ch in ALPHABET:
        print(ch, end='')
        string_buffer += ch

    if ch == '\x08' and 0 < len(string_buffer):
        print('\x08 \x08', end='')
        string_buffer.pop()
else:
    print()


print('R:', ''.join([chr(ord('A') + ord('Z') - ord(ch))
      for ch in string_buffer]))
