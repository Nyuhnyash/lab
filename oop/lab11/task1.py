class Class:
    cal_count = 0

    def __init__(self):
        Class.cal_count += 1


o1 = Class()
print(Class.cal_count)

o2 = Class()
print(Class.cal_count)
