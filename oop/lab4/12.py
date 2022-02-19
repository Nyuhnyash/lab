from numpy import transpose


n, m = int(input()), int(input())

array = list()
num = 1
for i in range(n):
    array.append([])
    for j in range(m):
        array[i].append(num)
        num += 1

print(transpose(array))
