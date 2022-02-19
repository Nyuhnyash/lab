ALPHABET_LENGTH = 26


def enc(line, offset):
    def encLetter(ch: str):
        ch_l = ch.lower()
        code = ord(ch_l)
        if code not in range(ord('a'), ord('z') + 1):
            return ch_l

        code += offset
        if code > ord('z'):
            code -= ALPHABET_LENGTH - 1
        if code < ord('a'):
            code += ALPHABET_LENGTH - 1
        return chr(code) if ch.islower() else chr(code).upper()

    return ''.join(map(encLetter, line))


def dec(line, offset): return enc(line, -offset)


line = 'Samara_1586_Самара'
k = 10

encLine = enc(line, k)
print(encLine)
print(dec(encLine, k))
