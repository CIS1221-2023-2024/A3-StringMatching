# Benchmarking the algorithms

In this section we will be benchmarking the boyer-moore algorithm in both programming languages to determine it's efficiency compared to other algorithms in the same programming languages, as well as 
documenting the resources it requires as well as execution time.


# Execution Time
We will be documenting the execution time the boyer moore algorithm takes through each respective programming language and comparing them with other algorithms executed in the same programming languages.

## C# Boyer Moore
A pre-existing library  (**System.Diagonistics**) providing the appropriate functions in measuring execution time will be used for this documentation.
![image](https://github.com/CIS1221-2023-2024/A3-StringMatching/assets/147913714/e906969e-af93-4bed-95b5-9b741156d07d)


```
ExampleInput = ABDBADABTACADDATABWADADTABADBADTATAOZLXCJADATAQWUEUYIQAYHASUIDYAHSIUDYUIAYADTAFHZXCHKJZXHFKJADTAIJIOJOIJIOJOIADTA
Pattern = ADTA
```

The pattern occurs quite frequently here, just to test further the execution time for when there are several words that match the pattern, in order to maximize the needed loops to execute relevant checks.

Given the possibile inconsistencies in results, we will also be taking the execution time twice and averaging them out.
### 1st Test -- C#
![image](https://github.com/CIS1221-2023-2024/A3-StringMatching/assets/147913714/1e7e10e7-7db9-4ba1-b6fb-7d07a6306068)


Recorded Time: **7.86 Milliseconds**
### 2nd Test -- C#
![image](https://github.com/CIS1221-2023-2024/A3-StringMatching/assets/147913714/5683e81e-d0c4-487c-be7c-7fffcb63881b)


Recorded Time: **8.24 Milliseconds**

**Overall Average:** **8.05 Milliseconds**


Other Algorithms like the **KMP (Knuth-Morris Pratt)** and **Naive Algorithm** have been run as well with the same input example to document the time difference between the three algorithms.

**KMP Average Time: **2.5 Milliseconds**

**Naive Algorithm: **1.02 Milliseconds**

Through a graph representation, we may see that with C#, The Boyer Moore Algorithm actually took **much more time** than both the two algorithms.

![image](https://github.com/CIS1221-2023-2024/A3-StringMatching/assets/147913714/466e20cd-d2ab-4303-8b75-7f9f8662da6d)



This contradiction of Boyer Moore supposedly being more efficient may come down to either C# itself or the way a programmer themself may come up in implementing the solutions.
**In a given sample code of Boyer Moore taken from https://www.geeksforgeeks.org/boyer-moore-algorithm-for-pattern-searching/ the Algorithm actually ran on average, 1 Millisecond, proving that given the proper implementation, takes way less time than KMP**








