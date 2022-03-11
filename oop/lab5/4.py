class SparceMatrix:
    def __init__(self, matrix: list[list]) -> None:
        data = dict()
        shape = (len(matrix), len(matrix[0]))
        print(shape)
        for i in range(shape[0]):
            for j in range(shape[1]):
                if matrix[i][j] != 0:
                    data[(i, j)] = matrix[i][j]

        self.shape = shape
        self._data = data

    def __getitem__(self, key):
        return self._data.get(key, 0)

    def __add__(self, other):
        if self.shape != other.shape:
            raise ValueError('Нельзя складывать матрицы разной размерности.')

        data = [[] for _ in range(self.shape[0])]
        for i in range(self.shape[0]):
            for j in range(self.shape[1]):
                data[i].append(self[(i, j)] + other[(i, j)])

        return SparceMatrix(data)

    def to_array(self) -> list[list]:

        array = list()
        for i in range(self.shape[0]):
            array.append(list())
            for j in range(self.shape[1]):
                array[i].append(self[(i, j)])
        return array

    def __str__(self) -> str:
        return self.to_array().__str__()


m1 = SparceMatrix([
    [1, 2, 0,  3],
    [0, 0, 4,  0],
    [4, 0, 0, -1],
    [0, 1, 0, 11]
])

m2 = SparceMatrix([
    [1, 2, 0,  3],
    [0, 0, 4,  0],
    [4, 0, 0, -1],
    [0, 1, 6, 0]
])

print(m1 + m2)
