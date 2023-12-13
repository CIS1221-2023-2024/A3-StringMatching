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

Bad Character Heuristic:
Quickly identifies and skips to the next mismatched character in the text, thus saving time by avoiding exhaustive comparisons.

Good Suffix Heuristic:
Discerns matching segments on the right side of a mismatch, optimizing pattern alignment and minimizing character comparisons.

These heuristics make Boyer-Moore a go-to choice for efficient text searching in large documents. In this exploration, we'll delve deeper into how these heuristics drive the algorithm's effectiveness, shedding light on its elegance and significance in computer science. Join us on this journey into the Boyer-Moore algorithm and its ingenious heuristics!
