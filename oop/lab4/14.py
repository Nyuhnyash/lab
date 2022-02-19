# a = [[1, 3], [1, 7], [0, 3], [3, 7], [2, 5]]

# longest = None
# maxcount = 0
# for otrezok in a:
#     count = 0
#     longest = otrezok
#     l1, l2 = longest
#     print(l1, l2)
#     for otrezok2 in a:
#         c, d = otrezok2
#         if l1 <= c < l2:
#             l1 = c
        
#         if l1 <= d < l2:
#             l2 = d
#         if l1 <= c and l2 >= d:
#             count += 1
#     if count > maxcount:
#         maxcount = count
#         res = l1, l2
    
# print(res)

# a = [[1, 4], [1, 7], [4, 6], [4, 4], [2, 5]]


def inSegment(sigment, value) -> bool:
    return sigment[0] <= value[0] <= value[1] <= sigment[1]


a = [[1, 3], [1, 7], [0, 3], [3, 7], [2, 5]]

l1, l2 = a[0]

for c, d in a:
    if l1 <= c < l2:
        l1 = c
    
    if l1 <= d < l2:
        l2 = d

f = filter(lambda x: inSegment(x, (l1, l2)), a)
print((l1, l2), len(list(f)))