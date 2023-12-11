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