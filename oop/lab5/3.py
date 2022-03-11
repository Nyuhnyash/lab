main = {
    'Калиев':   5,
    'Курясев':  2,
}
second = {
    'Курясев':  3,
    'Петрушин': 5,
}

пересдавшие = list()
неявившиеся_на_основной_экзамен_но_пришедшие_на_пересдачу = list()
for lastname in set([*main.keys(), *second.keys()]):
    m = main.get(lastname)
    s = second.get(lastname)

    if m and m == 2 and s:
        пересдавшие.append(lastname)
    if not m and s:
        неявившиеся_на_основной_экзамен_но_пришедшие_на_пересдачу.append(lastname)

print(пересдавшие, неявившиеся_на_основной_экзамен_но_пришедшие_на_пересдачу)
