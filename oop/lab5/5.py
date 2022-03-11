bd = [
    (1, 1000),
    (2, 1000),
    (1, -100),
    (2, -500),
    (2, 22),
]


data = dict()


while True:
    inpt = input()
    if inpt == 'q':
        break
    acc, action = inpt.split()
    
    acc = int(acc)
    action = int(action)
    if acc not in data:
        data[acc] = 0
    data[acc] += action


print(data)
    

    
    


