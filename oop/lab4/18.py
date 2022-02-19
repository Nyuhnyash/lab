from functools import cmp_to_key
from random import randrange


n = 10
# nums = [str(randrange(0, 1000)) for _ in range(n)]
nums = sorted(['11', '98', '9', '999'], )

def custom_sort(item1, item2):
    if len(item1) < len(item2):
            return -1
    elif item1 == item2:
        return 0
    if len(item1) > len(item2):
        return 1
        
    
cmp_to_key
print(nums)
print(' '.join(sorted(nums, key=cmp_to_key(custom_sort), reverse=True)))
print(' '.join(sorted(nums, reverse=True)))