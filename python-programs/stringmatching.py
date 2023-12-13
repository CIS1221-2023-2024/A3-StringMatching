import time
start= time.time()

def bad_character_table(pattern):
    table = {}
    pattern_length = len(pattern)
    for i in range(pattern_length - 1):
        table[pattern[i]] = pattern_length - 1 - i
    return table

def good_suffix_table(pattern):
    pattern_length = len(pattern)

    suffix_table = [0] * pattern_length
    last_prefix_position = pattern_length

    for i in range(pattern_length - 1, -1, -1):
        if is_prefix(pattern, i + 1):
            last_prefix_position = i + 1
        suffix_table[pattern_length - 1 - i] = last_prefix_position - i + pattern_length - 1

    for i in range(pattern_length - 1):
        j = pattern_length - 1 - suffix_length(pattern, i)
        if j < i:
            suffix_table[j] = min(suffix_table[j], i - j + pattern_length - 1)

    return suffix_table

def is_prefix(pattern, p):
    pattern_length = len(pattern)
    suffix_length = pattern_length - p
    for i in range(suffix_length):

        if pattern[i] != pattern[p + i]:
            return False
    return True

def suffix_length(pattern, p):
    pattern_length = len(pattern)
    length = 0
    while p >= 0 and pattern[p] == pattern[pattern_length - 1 - length]:
        length += 1
        p -= 1
    return length

def boyer_moore(text, pattern):
    pattern_length = len(pattern)
    text_length = len(text)

    bad_char_table = bad_character_table(pattern)
    suffix_table = good_suffix_table(pattern)


    i = 0
    while i <= text_length - pattern_length:
        j = pattern_length - 1

        while j >= 0 and pattern[j] == text[i + j]:
            j -= 1

        if j < 0:
            print("Pattern found at index", i)
            i += suffix_table[0]
        else:
            bad_char_shift = bad_char_table.get(text[i + j], -1)
            good_suffix_shift = suffix_table[j]
            i += max(bad_char_shift, good_suffix_shift)
end= time.time()

if __name__ == "__main__":

    text= input('input a text ')
    pattern = input('input a Patter to be found withn the text ')

    if not text:
        print("You didn't input any text.")
    elif not pattern:
        print("You didn't input any pattern.")
    else:
        boyer_moore(text, pattern)


    print(end-start)