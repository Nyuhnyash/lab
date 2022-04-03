def is_superset(a: str, b: str):
    b_chars = list(b)
    for char in a:
        try:
            b_chars.remove(char)
        except ValueError:
            return False

    return True

print(is_superset('интерес', 'строение'))
print(is_superset('интерес', 'иностранец'))
