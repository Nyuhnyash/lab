days_count = int(input('Число дней в году: '))
parties_count = int(input('Количество политических партий: '))
# work = set([i for i in range(1, days_count + 1) if i % 7 not in (0, 6)])
working_days = set(filter(lambda i: i % 7 not in (0, 6), range(1, days_count + 1)))
working_days_planned = len(working_days)
for i in range(parties_count):
    print(f'\t{i + 1}-я партия.')
    day_start = int(input('День начала забастовки: '))
    num_report = int(input('Периодичность (в днях): '))
    total_max = (days_count - day_start) // num_report
    working_days -= set(day_start + num_report * i for i in range(total_max + 1))

print(working_days_planned - len(working_days))
