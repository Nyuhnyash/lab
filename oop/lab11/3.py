class Rectangle:
    def __init__(self, width, height):
        self.width = width
        self.height = height

    @property
    def square(self):
        return self.width * self.height


r = Rectangle(2, 5)
print(r.square)
