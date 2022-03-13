# s1 = input()
# s2 = input()
# s3 = input()

s1 = 'строка'
s2 = 'столбец'
s3 = 'число'

print('\ta)')
intersection_by_three = set(s1).intersection(s2).intersection(s3)
print(intersection_by_three)

print('\tb)')
everything = set(s1).union(s2).union(s3)
print(everything)

print('\tc)')
def c(string: str, *params):
    return set(string).difference(params[0]).difference(params[1])

print(c(s1, s2, s3))
print(c(s2, s1, s3))
print(c(s3, s2, s1))

print('\td)')
print(everything.difference(intersection_by_three))
