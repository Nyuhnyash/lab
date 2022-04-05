class Rectangle:
    def __init__(self, width, height):
        self.width = width
        self.height = height

    @property
    def square(self):
        return self.width * self.height
    
    def union(self, other: 'Rectangle'):
        rects = []
        if self.width == other.width:
            rects.append(Rectangle(self.width, self.height + other.height))
        
        if self.height == other.height:
            rects.append(Rectangle(self.width + self.width, self.height))

        if len(rects) == 0:
            return None

        return rects

    def __str__(self) -> str:
        return f"{self.width} {self.height}"


r = Rectangle(3, 5)
r2 = Rectangle(2, 4)
rects = r.union(r2)
if rects is not None:
    for rect in rects:
        print(rect)
