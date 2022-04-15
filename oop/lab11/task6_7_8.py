from __future__ import annotations
from task2 import Segment
from task3_4_5 import RectangleBase


class Rectangle(RectangleBase):
    def __init__(self, width, height, position: tuple[float, float]):
        super().__init__(width, height)
        self.position = position

    def contains(self, point: tuple[float, float]):
        return self.position[0] <= point[0] <= self.position[0] + self.width \
            and self.position[1] <= point[1] <= self.position[1] + self.height

    def overlap(self, rect: Rectangle):
        # a = self.position
        # b = (self.position[0], self.position[1] + self.height)
        # c = (self.position[0] + self.width, self.position[1] + self.height)
        # d = (self.position[0] + self.width, self.position[1])

        # ab = Segment(a, b)
        # bc = Segment(b, c)
        # cd = Segment(c, d)
        # da = Segment(d, a)

        # e = other.position
        # f = (other.position[0], other.position[1] + other.height)
        # g = (other.position[0] + other.width, other.position[1] + other.height)
        # h = (other.position[0] + other.width, other.position[1])

        # ef = Segment(e, f)
        # fg = Segment(f, g)
        # gh = Segment(g, h)
        # he = Segment(h, e)

        # ab_fg = ab.cross_point(fg)
        # ab_he = ab.cross_point(he)
        # cd_fg = cd.cross_point(fg)
        # cd_he = cd.cross_point(he)

        # bc_ef = bc.cross_point(ef)
        # bc_gh = bc.cross_point(gh)

        # da_ef = da.cross_point(ef)
        # da_gh = da.cross_point(gh)

        # print(ab_fg, ab_he, cd_fg, cd_he, bc_ef, bc_gh, da_ef, da_gh, sep='\n')
        x_left_1, y_down_1, x_right_1, y_up_1, x_left_2, y_down_2, x_right_2, y_up_2 = \
            self.position[0], self.position[1], self.position[0] + self.width, self.position[1] + self.height, self.position[0], self.position[1], self.position[0] + rect.width, self.position[1] + rect.height
        left_min = min(x_left_1, x_left_2)
        down_min = min(y_down_1, y_down_2)
        right_max = max(x_right_1, x_right_2)
        up_max = max(y_up_1, y_up_2)
        rectList = []
        for i in range(left_min, right_max):
            for j in range(down_min, up_max):
                if self.contains((i, j)) & rect.contains((i, j)):
                    rectList.append((i, j))
        rectList.sort()
        if not rectList:
            return None
        else:
            x = rectList[0][0]
            y = rectList[0][1]
            width = rectList[-1][0] - rectList[0][0]
            height = rectList[-1][1] - rectList[0][1]
            return Rectangle(width, height, (x, y))


if __name__ == '__main__':
    r = Rectangle(10, 10, (1, 1))
    print(r.contains((2, 2)))

    # Task 8
    r1 = Rectangle(5, 5, (1, 1))
    r2 = Rectangle(10, 10, (2, 2))
    over = r1.overlap(r2)
    print(over)
