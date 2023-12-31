# Creating The Boyer Moore String Matching Algorithm

For our approach, we will be creating a string matching algorithm by following the model of the **Boyer-Moore** Algorithm.
Our decision to move forward with this algorithm was justified by the efficiency of the said algorithm, contrary to other possible models such as **Brute-Force** or **KMP**.

The programming languages in question that we have implemented such algorithm are **C#** and **Python**


# Computer Resources:

Memory: The Boyer-Moore algorithm doesn't require much additional memory beyond what is needed to store the input text and pattern. It primarily uses arrays or tables for its heuristic computations, which have a fixed size related to the size of the character set.

Processor: It doesn't require advanced processing capabilities and can be implemented efficiently on most modern processors.

# Time Complexity:

The Boyer-Moore algorithm can achieve remarkable time complexity for practical cases. On average, it performs linear or sublinear searches, making it very efficient.

Best-case Time Complexity: O(n/m), where n is the length of the text, and m is the length of the pattern. This occurs when the pattern is rare in the text.

Worst-case Time Complexity: O(nm), which happens when the pattern and text are similar or when the pattern has many repetitive characters.

# Efficiency and Why Boyer-Moore is a Good Choice:

Quick and Practical: Boyer-Moore often does the job faster than other methods, like the basic brute force way or fancier methods like Knuth-Morris-Pratt. In real-life situations, if you want something done fast, Boyer-Moore is usually the best option.

Comparatively speaking, The Boyer Moore algorithm is at it's maximum efficiency when it's two heuristics is impletmented, the **Good Match Table** and **Good Suffix Rule** as these two heuristics independently assist the algorithm in finding a specific amount to **skip** indexes in a long string, preventing unnecessary comparison loops between substrings and the pattern that we wish to locate.
this is why in terms of efficiency it is superior to the KMP algorithm & the Brute Force algorithm

Easy to Understand: This algorithm isn't too complicated to learn and use. That's great for students and developers because it means we can get things done without getting stuck on complicated concepts.


Adapts Well: This algorithm can handle different situations nicely. Even if our pattern has lots of the same letters or it's a bit long, Boyer-Moore keeps working reasonably fast without slowing down too much.

Doesn't Use Up a Lot of Memory: Boyer-Moore doesn't use much extra memory space. Think of it as being mindful of not overeating when you're on a diet. This is great when your computer doesn't have a lot of memory to spare.

In a nutshell, we like Boyer-Moore because it's fast, easy to understand, prepares itself for the search, works well in various situations, and doesn't use up too much memory. It's a versatile and efficient tool for finding strings in text.
