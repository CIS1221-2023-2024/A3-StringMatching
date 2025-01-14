**By David Isaac Ohayon & Elmuntserbalah Taher**

This project will be covering the “String Matching” Algorithm. This will be documented with all the information and instructions of operation and decision making for tackling said algorithm. As well as a well-detailed explanation of the paradigms and methods used.

## **What is a string-matching algorithm?**
Logically, a string-matching algorithm works by searching through a long string of a sentence or a sequence of letters, and will attempt to match a set of those characters with a given pattern. This of course can also work in attempting to find words in a sentence, rather than just string patterns such as AABB or BAAB.

![image](https://github.com/Montaser-Taher/-string-matching/assets/147913714/749d96ed-25c3-418f-9e08-f9c230aaa43b)

## **Existing Solutions to a string matching algorithm**
There are several existing algorithms that tackle a string matching system. They all vary in their complexity and efficiency. Such existing algorithms go by the name of **Brute Force Algorithm (Or Naive-Algorithm)** , **KMP - Knuth Morris Algorithm**, **Boyer-Moore Algorithm**.

# The Boyer Moore Algorithm

As a student navigating the realm of algorithms, we introduce you to the Boyer-Moore algorithm, a remarkable tool in string searching and pattern matching. Developed by Robert S. Boyer and J. Strother Moore, this algorithm has revolutionized the field with its efficiency.

The Boyer-Moore algorithm hinges on two pivotal heuristics: the Bad Character Heuristic and the Good Suffix Heuristic. These heuristics work in tandem to streamline pattern matching and reduce character comparisons.

# Bad Character Heuristic:
Quickly identifies and skips to the next mismatched character in the text, thus saving time by avoiding exhaustive comparisons.

This is achieved by the use of a **Bad Match Table**.

## **How the Bad Match Table is Created**

The Bad Match table is used in order to assign each specific letter within the pattern that we wish to find in our long string, a calculated value.
The purpose of this value is to simply allow the algorithm to skip an amount of letters with the **"Impression"** that the pattern we wish to find is no where
near the current index it is pointing at. 




![image](https://github.com/CIS1221-2023-2024/A3-StringMatching/assets/147913714/46d4a862-9485-4612-a7cc-2944824f3c13)

The Bad Match Table contains all these values for each leter in the pattern, and is calculated by the following:
### **LetterValue = max(1, (patternLength - indexOfLetter - 1))**

![image](https://github.com/CIS1221-2023-2024/A3-StringMatching/assets/147913714/e816d862-56c8-4a64-bb08-69355ef1e1fa)

![image](https://github.com/CIS1221-2023-2024/A3-StringMatching/assets/147913714/6f20ea6f-584c-494c-93e5-32a45aeb7ac5)

Then of course, Any character in the long string that is not an existing character in the pattern will have the value **equivalent to the pattern's length**

### **So..What's actually happening during the Boyer Moore String Algorithm search when it comes to the Bad Character Heuristic?**





https://github.com/CIS1221-2023-2024/A3-StringMatching/assets/147913714/3766d8d2-3452-422e-a6d0-279bec3f00db


















it operates by:

- Scanning from right to left in the pattern.

- Using our precomputed table to identify the last occurrence of each character in the pattern.

When a character mismatch occurs with a character 'X' in the text, shifting the pattern based on the table's information:
If 'X' is not in the pattern, shift the pattern by its full length.
If 'X' appears in the pattern, align the rightmost occurrence of 'X' with the mismatched 'X' in the text.

The Bad Character Heuristic's smart handling of character mismatches, making  its status as a core tool for pattern matching and string searches.

# Good Suffix Heuristic:
Discerns matching segments on the right side of a mismatch, optimizing pattern alignment and minimizing character comparisons.

These heuristics make Boyer-Moore a go-to choice for efficient text searching in large documents. In this exploration, we'll delve deeper into how these heuristics drive the algorithm's effectiveness, shedding light on its elegance and significance in computer science. Join us on this journey into the Boyer-Moore algorithm and its ingenious heuristics!

1) If a mismatch occurs:

- If the mismatched character previously appears in the pattern, align the last occurrence of that character in the pattern with its first occurrence in the pattern.
This follows roughly the same principle of the first case, just a bit more abstracted, the algorithm takes notice of the first substring of our suffix (the tailing characters before the left most character of the comparison loop) which actually managed to satisfy a match, and tries to find within the pattern, a **second** corresponding substring only this time, with a different preceding character, as it knows if it finds the same substring with the same preceding character, it will be a useless jump, and could even cause an infinite loop in certain cases.


- If the mismatched character does not have a previous occurrence in the pattern, find the longest suffix that matches a substring of the pattern's prefix and align it in the text.

2) Choose the larger shift value between the two cases to skip more characters in the text and reduce comparisons.

The Good Suffix Heuristic is a critical component of the Boyer-Moore string searching algorithm. It efficiently handles mismatches during pattern matching by determining how the pattern can be shifted to maximize the number of skipped characters in the text. This optimization significantly improves the algorithm's performance, making it a powerful and efficient tool for searching patterns in large texts.
