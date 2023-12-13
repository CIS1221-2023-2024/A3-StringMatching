**By David Isaac Ohayon & Elmuntserbalah Taher**

This project will be covering the “String Matching” Algorithm. This will be documented with all the information and instructions of operation and decision making for tackling said algorithm. As well as a well-detailed explanation of the paradigms and methods used.

## **What is a string-matching algorithm?**
Logically, a string-matching algorithm works by searching through a long string of a sentence or a sequence of letters, and will attempt to match a set of those characters with a given pattern. This of course can also work in attempting to find words in a sentence, rather than just string patterns such as AABB or BAAB.

![image](https://github.com/Montaser-Taher/-string-matching/assets/147913714/749d96ed-25c3-418f-9e08-f9c230aaa43b)

## **Existing Solutions to a string matching algorithm**
There are several existing algorithms that tackle a string matching system. They all vary in their complexity and efficiency. Such existing algorithms go by the name of **Brute Force Algorithm (Or Naive-Algorithm)** , **KMP - Knuth Morris Algorithm**, **Boyer-Moore Algorithm**.

## Brute Force Algorithm (Naive-Algorithm)
The Naive-Algorithm, or more appropriately, Brute Force algorithm, goes by it's name. The way this algorithm works is that it simply takes in a long string of text, this can be a sequence of letter patterns such as "AAABABABAAACCEDAAAA", and will attempt to iterate through each letter from left to right, and tries to compare each letter after the selected letter, with each letter of the pattern.

Logically speaking this can be defined by taking a first letter from the long string at index N. Upon selecting this first letter, a second inner iteration of each letters in the pattern will be run, starting from index J. If the first letters of both the string and the pattern match, the algorithm will move on to the next Nth letter of the text, in which case. N + 1, and then compare it to the next letter of the pattern, J + 1.

This cycle will repeat for each letter in the long string until a full match is made.

![image](https://github.com/Montaser-Taher/-string-matching/assets/147913714/4f231d52-edbf-4ff3-830f-237474e7d62a)




For this project, we will be proceeding with the Boyer-Moore Algorithm, given that it integrates a part of both the Naive-Algorithm and Knuth Morris Algorithm, and it happens to be the most efficient solution as a string matching algorithm. This of course comes with a greater complexity in its code structure.


## Knuth-Morris-Pratt - (KMP) Algorithm
The KMP Algorithm has a similar approach to the brute force algorithm, though a bit more complex & efficient.

The algorithm takes in a long string, as mentioned (e.g: **AAAABACAGATACAAA** ) and a pattern to search for within (e.g: **BACAGA**)
