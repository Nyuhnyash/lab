from random import randrange
from numpy import sign

nums = [randrange(-2, 12 + 1) for _ in range(20)]
nums.sort(key=sign)
print(nums)