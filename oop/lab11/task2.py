class Segment:
    def __init__(self, start: tuple[float, float], end: tuple[float, float]):
        self.start = start
        self.end = end

    def cross_point(self, other):
        """Source: https://stackoverflow.com/a/20677983/14633731"""

        xdiff = (self.start[0] - self.end[0], other.start[0] - other.end[0])
        ydiff = (self.start[1] - self.end[1], other.start[1] - other.end[1])

        def det(a, b):
            return a[0] * b[1] - a[1] * b[0]

        div = det(xdiff, ydiff)
        if div == 0:
            return None

        d = (det(self.start, self.end), det(other.start, other.end))
        x = det(d, xdiff) / div
        y = det(d, ydiff) / div
        return x, y

s1 = Segment((0, 0), (0, 2))
s2 = Segment((-1, 1), (1, 1))

print(s1.cross_point(s2))
