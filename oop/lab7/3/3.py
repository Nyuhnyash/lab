import os


def remove_all_neigbors(full, i, j):
    if (i < 0 or j < 0):
            return
    try:
        if full[i][j] == '.':
            return
    except IndexError:
        return
    
    full[i][j] = '.'
    remove_all_neigbors(full, i,   j+1)
    remove_all_neigbors(full, i,   j-1)
    remove_all_neigbors(full, i+1, j  )
    remove_all_neigbors(full, i-1, j  )
    
    

filename = os.path.dirname(__file__) + '\\battlefield.txt'
with open(filename, mode='r', encoding='utf8') as f:
    full = []
    for line in f:
        ln = []
        full.append(ln)
        for char in line.replace('\n', ''):
            ln.append(char)

warship_count = 0
for i in range(len(full)):
    for j in range(len(full[0])):
        if full[i][j] == '*':
            remove_all_neigbors(full, i, j)
            warship_count += 1

print(warship_count)
