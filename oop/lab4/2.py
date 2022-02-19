def polyndroms(line):
    for ent in line.split():
        if ent[:(len(ent) // 2) :-1] == ent[:(len(ent) // 2)]:
            yield ent


# word = input()
# line = input()

line = 'привет aboba как дела'

print(list(polyndroms(line)))