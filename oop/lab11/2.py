from typing import Tuple


class Segment:
    def __init__(self, start: Tuple[float, float], end: Tuple[float, float]):
        self.start = start
        self.end = end

    def is_crossed(self, other):
        
        return None


s1 = Segment((0, 0), (0, 2))
s2 = Segment((-1, 1), (1, 1))

s1.is_crossed(s2)
