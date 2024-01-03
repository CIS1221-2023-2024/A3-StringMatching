import timeit

# This Function to create a bad character table for Boyer-Moore
def bad_character_table(pattern):
    # Empty dictionary to store the character positions
    table = {}
    # To get the length of the pattern
    pattern_length = len(pattern)
    # Loop through the pattern characters, except for the last one
    for i in range(pattern_length):
        # To calculate the "bad character" shift for the current character to store it in the table
        table[pattern[i]] = pattern_length - i - 1
        # NOTE!! (The shift value is the difference between the pattern length and the current position in the pattern)
    return table


# This Function to check if a substring is a prefix of the pattern
def is_prefix(pattern, p):
    # The purpose is to know how long a part of a word is
    # by finding the difference between the total length of the word (pattern_length) and a starting position (p)
    pattern_length = len(pattern)
    suffix_length = pattern_length - p
    for i in range(suffix_length):
        # It checks if the character at a position i in the pattern (the whole word)
        # is different from the character at the position p + i in the substring
        # If there's any difference, it indicates that the substring is not identical to the beginning of the pattern
        if pattern[i] != pattern[p + i]:
            # It stops the loop and returns False. This indicates that the substring is not a prefix of the pattern
            return False
    return True


# This Function to compute the length of the common suffix
def suffix_length(pattern, p):
    pattern_length = len(pattern)
    # Set length variable to 0 to keep track of the length of the matching suffix
    length = 0
    # The loop has two conditions:
    # p is greater than or equal to 0, ensuring we don't go out of bounds
    # The character at position p in the pattern matches the character at a corresponding position in the pattern's reverse order
    while p >= 0 and pattern[p] == pattern[pattern_length - 1 - length]:
        length += 1
        p -= 1
    return length


# This Function to create a good suffix table for Boyer-Moore
def good_suffix_table(pattern):
    pattern_length = len(pattern)
    # It's initialized as a list of zeros to store the suffix table values
    suffix_table = [0] * pattern_length
    last_prefix_position = pattern_length

    """                                     Calculate suffix table based on pattern prefixes
               The loop iterates backward through the pattern, starting from the second-to-last character.
        It checks if the substring is a prefix using the is_prefix function and updates last_prefix_position accordingly.
            Th e shift value is calculated and stored in suffix_table at the appropriate position.
            """

    # Calculate suffix table based on pattern prefixes
    for i in range(pattern_length - 1, -1, -1):
        '''
                                            (( Notes about the what each verable represent ))
                 suffix_length(pattern, i) calculates the length of the longest suffix of the pattern that matches the substring
                The j value represents the position where a mismatch occurs.

                '''
        if is_prefix(pattern, i + 1):
            last_prefix_position = i + 1
        suffix_table[pattern_length - 1 - i] = last_prefix_position - i + pattern_length - 1
    # Calculate suffix table based on pattern suffixes
    for i in range(pattern_length - 1):
        len_suffix = suffix_length(pattern, i)
        if pattern[i - len_suffix] != pattern[pattern_length - 1 - len_suffix]:
            suffix_table[pattern_length - 1 - len_suffix] = pattern_length - 1 - i
    # Updated with the minimum value between the current value at suffix_table[j] and a new calculated value
    return suffix_table


# This function is the Boyer-Moore search algorithm
"""             deap Explination on the purpose of the step of creating suffix_table in position J
               we calculate how far apart i and j are, and add the length of the pattern -1 to it.
Then, we compare this calculated value with the current value at suffix_table[j] and choose the smaller of the two to store in suffix_table[j].
         This way, we keep track of the minimum shift needed for each mismatch position in the pattern."""


def boyer_moore(text, pattern):
    pattern_length = len(pattern)
    text_length = len(text)
    # Create bad character and good suffix tables
    bad_char_table = bad_character_table(pattern)
    suffix_table = good_suffix_table(pattern)

    i = 0
    found_indices = []
    while i <= text_length - pattern_length:
        j = pattern_length - 1
        # Comparing the pattern characters with text characters
        while j >= 0 and pattern[j] == text[i + j]:
            j -= 1

        if j < 0:
            # Pattern found, print the index where it was found
            found_indices.append(i)
            shift = suffix_table[0] if i + pattern_length < text_length else 1
        else:
            # Calculating the shift based on bad character and good suffix tables
            bad_char_shift = bad_char_table.get(text[i + j], pattern_length)
            good_suffix_shift = suffix_table[j]
            shift = max(bad_char_shift, good_suffix_shift)

        i += shift

    return found_indices





def benchmark_boyer_moore(text_length, pattern_length, repetitions=1000):
    test_text = "A" * text_length
    test_pattern = "A" * pattern_length

    # Timing the Boyer-Moore function
    timing = timeit.timeit(lambda: boyer_moore(test_text, test_pattern), number=repetitions)
    return timing

# The '__name__ == "__main__"' part is Python's way to tell if the file is being run as the main program.
# If this script is imported from another script, the code under this if statement won't run.
if __name__ == "__main__":
    # We are asking the user to input the length of the text we want to test.
    # 'int(input())' is used to read an integer value from the user.
    text_len = int(input("Enter text length for benchmarking: "))

    # Now, we ask the user for the length of the pattern to search within the text.
    # This is also an integer value.
    pattern_len = int(input("Enter pattern length for benchmarking: "))

    # Here, we ask how many times to repeat our test. This helps in getting a more accurate average time.
    repetitions = int(input("Enter the number of repetitions for the benchmark: "))

    # Now we perform the benchmarking.
    # 'benchmark_boyer_moore' is our function that will run the Boyer-Moore algorithm multiple times.
    # We give it the text length, pattern length, and how many times to repeat the test.
    timing_result = benchmark_boyer_moore(text_len, pattern_len, repetitions)

    # Finally, we print the results.
    # This line shows how long it took, on average, to run our algorithm with the given text and pattern lengths.
    print(f"Time taken for {repetitions} repetitions with text length {text_len} and pattern length {pattern_len}: {timing_result} seconds")

