nums = [0, 0, 0, 1, 1]

letters = dict()
for c in nums:
    if c not in letters:
        letters[c] = 0
    letters[c] += 1

vals = list(letters.values())
def main():
    if 5 in vals: return 'poker'
    if 4 in vals: return 'four of a kind'
    if 3 in vals:
        if 2 in vals: return 'full house'

        return 'three of a kind'
    if 2 in vals: 
        vals.remove(2)
        if 2 in vals:
            return 'two pairs'
        return 'one pair'
    return 'all different'



print(main())