from math import *

def apply(f, start, end, step):
    x = start
    while x <= end:
        print(format(eval(f), '10.2f'))
        x += step

apply('x**2 + sin(x)', 0, 100, 10)

f = input('Function: ')
start = float(input('From: '))
end = float(input('To: '))
step = float(input('Step: '))

apply(f, start, end, step)