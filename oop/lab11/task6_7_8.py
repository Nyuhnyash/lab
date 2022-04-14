from task3_4_5 import RectangleBase


class Rectangle(RectangleBase):
    def __init__(self, width, height, position: tuple[float, float]):
        super().__init__(width, height)
        self.position = position
    

    def contains(self, point: tuple[float, float]):
        return self.position[0] <= point[0] <= self.position[0] + self.width \
            and self.position[1] <= point[1] <= self.position[1] + self.height


r = Rectangle(10, 10, (1, 1))
print(r.contains((2, 2)))

