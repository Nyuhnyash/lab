from enum import Enum
import os
from random import randint

class CargoType(Enum):
    Sand = 0
    Gravel = 1
    Rubble = 2

class Journal:
    def __init__(self, filename) -> None:
        self.filename = filename
    
    def fill(self, count = 20):
        with open(self.filename, 'w') as f:
            for i in range(count):
                weight = randint(0, 100)
                print(
                    CargoType(randint(0, 2)).name,
                    weight,
                    weight + randint(1, 20),
                    file=f
                )
    
    def read(self):
        res = {
            CargoType.Sand:   0,
            CargoType.Gravel: 0,
            CargoType.Rubble: 0,
        }
        with open(self.filename, 'r') as f:
            for record in f:
                type, before, after = record.split(' ')
                res[CargoType[type]] += int(after) - int(before)
            
            return res


j = Journal(os.path.dirname(__file__) + '\\journal.txt')
j.fill()
print(j.read())

