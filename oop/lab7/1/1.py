from enum import Enum
from sys import stderr


class Vertical(Enum):
    A = 1
    B = 2
    C = 3
    D = 4
    E = 5
    F = 6
    G = 7
    H = 8

class Horizontal(Enum):
    One   = 1
    Two   = 2
    Three = 3
    Four  = 4
    Five  = 5
    Six   = 6
    Seven = 7
    Eight = 8

class Position:
    def __init__(self, string) -> None:
        v, h = string[0], string[1]
        self.vertical = Vertical[v.upper()]
        self.horizontal = Horizontal(int(h))

    def __str__(self) -> str:
        return f"{self.vertical.name}{self.horizontal.value}"

    def move(self, cmd: str, count: int):
        try:
            match cmd:
                case 'ВНИЗ':
                    self.horizontal = Horizontal(self.horizontal.value - count)
                case 'ВВЕРХ':
                    self.horizontal = Horizontal(self.horizontal.value + count)
                case 'ВПРАВО':
                    self.vertical = Vertical(self.vertical.value + count)
                case 'ВЛЕВО':
                    self.vertical = Vertical(self.vertical.value - count)
        except ValueError:
            print('Невозможных ход', file=stderr)
            match cmd:
                case 'ВНИЗ':
                    self.horizontal = Horizontal.One
                case 'ВВЕРХ':
                    self.horizontal = Horizontal.Eight
                case 'ВПРАВО':
                    self.vertical = Vertical.H
                case 'ВЛЕВО':
                    self.vertical = Vertical.A



with open('ant.txt', mode='r', encoding='utf8') as f:
    position = Position(f.readline())
    print(position)
    for line in f:
        cmd, count = line.split(' ')
        position.move(cmd, int(count))
    
print(position)
