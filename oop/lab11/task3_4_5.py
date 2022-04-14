from __future__ import annotations
from itertools import combinations


class RectangleBase:
    def __init__(self, width, height):
        self.width = width
        self.height = height

    @property
    def square(self):
        return self.width * self.height
    
    def union(self, other: RectangleBase):
        rects = []
        if self.width == other.width:
            rects.append(RectangleBase(self.width, self.height + other.height))
        
        if self.height == other.height:
            rects.append(RectangleBase(self.width + other.width, self.height))

        if len(rects) == 0:
            return None

        return rects

    def __str__(self) -> str:
        return f"({self.width} {self.height})"


def union3(*r):

    for pair in combinations(r, 2):
        unions = RectangleBase.union(*pair)
        if not unions: continue

        last = set(r).difference(pair)
        for uni in unions:
            u = uni.union(*last)
            if u: 
                return u

    return None

if __name__ == '__main__':
    # Task 3
    r = RectangleBase(2, 5)
    print(r.square)

    # Task 4
    r = RectangleBase(3, 5)
    r2 = RectangleBase(2, 5)
    rects = r.union(r2)
    if rects is not None:
        for rect in rects:
            print(rect)

    # Task 5
    r1 = RectangleBase(1, 2)
    r2 = RectangleBase(3, 2)
    r3 = RectangleBase(4, 2)

    union = union3(r1, r2, r3)
    if union:
        print(*union)











