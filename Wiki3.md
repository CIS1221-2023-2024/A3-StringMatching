# Benchmarking the algorithms

In this section we will be benchmarking the boyer-moore algorithm in both programming languages to determine it's efficiency compared to other algorithms in the same programming languages, as well as 
documenting the resources it requires as well as execution time.

NOTE : The benchmarking made here will be benchmarking the attempts of implementing the algorithm and not the *"actual algorithm"* in a perfect sense. Better attempts exists on the internet


# Edge Cases
In this section, we will be challenging the boundaries of the algorithms implemented in Python & CSharp by giving in Inputs that seem to enter an area of extremity. These can include an absurd large amount of characters, involving way too many special characters or punctuations, attempting to "hide" the words in punctuation which can actually confuse the algorithm in it's ability to skip towards the required pattern, etc.


### Edge Case 1 - A very Large String with a very small pattern (just to find 1 character)

In this edge case test, we will be inputting a very Large string with a very small pattern to locate from.

```
Input: VCOKBJCBVOKNJPIOBVKJPOGHKUPOYTKPOGMBVKLCMNFLGKHKPORTYMHNKLFBMNLKGHMJPOYTG,MOGHKJYTUPOM,NLK;MTOPKHMPRTOKPORJKPOQWWSZKXOCMKCOLMVCKLMBGFKL;MHPORTYKYTPOERKGHROLBMCV,BM;LRFDGLHYRT[PYKHLPLGFDKBMLFGVMHLKFGHGLVCOKBJCBVOKNJPIOBVKJPOGHKUPOYTKPOGMBVKLCMNFLGKHKPORTYMHNKLFBMNLKGHMJPOYTG,MOGHKJYTUPOM,NLK;MTOPKHMPRTOKPORJKPOQWWSZKXOCMKCOLMVCKLMBGFKL;MHPORTYKYTPOERKGHROLBMCV,BM;LRFDGLHYRT[PYKHLPLGFDKBMLFGVMHLKFGHGLVCOKBJCBVOKNJPIOBVKJPOGHKUPOYTKPOGMBVKLCMNFLGKHKPORTYMHNKLFBMNLKGHMJPOYTG,MOGHKJYTUPOM,NLK;MTOPKHMPRTOKPORJKPOQWWSZKXOCMKCOLMVCKLMBGFKL;MHPORTYKYTPOERKGHROLBMCV,BM;LRFDGLHYRT[PYKHLPLGFDKBMLFGVMHLKFGHGL ((A))FDGIOJFSXOVJXCOIJVLCKXJKGLFDJGHPOTKREPOYKGFLBL;B,MFG;LKHJP[OTYKLJH;NHMNB.,CVVB,VC.MBLCKVKL;PGFDKHL;M,L;BM,G;L,M4596-0945-TNL,NL;FVK;'#;
Pattern : A 
```







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

**Note: Execution Times may vary depending on the system it is being executed on and also not to mention that our Implementation of boyer moore runs with the two heuristics, which add more complexity 
which over all may also impact the performance.**



### 1st Test -- C#
 ![image](https://github.com/CIS1221-2023-2024/A3-StringMatching/assets/147913714/f75c21b5-8d6e-4a56-880b-142346fb8a78)



Recorded Time: **3 Milliseconds**
### 2nd Test -- C#
![image](https://github.com/CIS1221-2023-2024/A3-StringMatching/assets/147913714/62e94d55-9597-4fcf-b68e-781222fb893c)




Recorded Time: **3 Milliseconds**

**Overall Average: 3 Milliseconds**


Other Algorithms like the **KMP (Knuth-Morris Pratt)** and **Naive Algorithm** have been run as well with the same input example to document the time difference between the three algorithms.

**KMP Average Time: 2.5 Milliseconds**

**Naive Algorithm: 1.02 Milliseconds**

Through a graph representation, we may see that with C#, The Boyer Moore Algorithm actually took **much more time** than both the two algorithms.

![image](https://github.com/CIS1221-2023-2024/A3-StringMatching/assets/147913714/7909f4f3-d6a1-4d27-98f7-bf499427ff3e)




Note: This contradiction of Boyer Moore supposedly being more efficient is most likely due to the inefficient structure of the solutions, where code simplification and optimization likely exists, just not known.
**In a given sample code of Boyer Moore taken from https://www.geeksforgeeks.org/boyer-moore-algorithm-for-pattern-searching/ the Algorithm actually ran on average, 1 Millisecond in C#, proving that given the proper implementation, takes way less time than KMP**


## Python Boyer Moore
We will also be using a pre-existing library to document and monitor the execution time for the python file of the Boyer Moore Algorithm as well as comparing the execution time of this algorithm with the same other ones (KMP & Naive)


![image](https://github.com/CIS1221-2023-2024/A3-StringMatching/assets/147913714/8673fea2-070f-40f0-a0e2-abf1bc68786f)

**Note:** The time difference calculated in the end is multiplied by 1000 to convert it into **milliseconds**
### 1st Test -- Python
![image](https://github.com/CIS1221-2023-2024/A3-StringMatching/assets/147913714/77c685a2-d962-4c29-9b30-507746654b3b)

Recorded Time: **0.5 Milliseconds** 

### 2nd Test -- Python
![image](https://github.com/CIS1221-2023-2024/A3-StringMatching/assets/147913714/a4333b8d-13b2-4bbd-9e7d-ca6e9604493c)

Recorded Time: **0.5 Milliseconds** 

**Overall Average: 0.5 Milliseconds**


And of course, we've run the other algorithms in the respective python language as well and collected their average:

**KMP Average Time: 1.51 Milliseconds**

**Naive Average Time: 1.53 Milliseconds** 

![image](https://github.com/CIS1221-2023-2024/A3-StringMatching/assets/147913714/ee41fd76-0345-414d-b502-b8f9c631b594)


Thus Overall, in Comparison Python was capable at running our implemented algorithms of Boyer Moore roughly **600%** faster.
In a general comparison however, with the online source of the C# implementation on Boyer Moore, Python would've managed to run at only **200%** faster speeds.



# Memory Usage
Both the C# and Python programs of the Boyer Moore Algorithms will be documented based on their memory usage. For the sake of mainly comparing the difference between Python and C# we will only be comparing the Memory usage of the Boyer Moore algorithm between python and C# and not focus on other algorithms such as Naive or KMP

We'll be using the given input example to test the memory usage provided the pattern is longer to extend further the potential tables that will be generated and saved.

```
ExampleInput = ABDBADABTACADDATABWADADTABADBADTAFSAFTAOZLXCJADATAQWUEUYIQAYHASUIDYAHSIUDYUIAYADTAFHZXCHKJZXHFKJADTAIJIOJOIJIOJOIADTAADTAFSADDUISAHIUHNXZJICNIJNADTAFSAD
Pattern = ADTAFSAD
```



## C# Memory Usage
In C# within the System.Diagnostics Namespace we utilized an already defined method that keeps track of memory usage that the program being run uses **dynamically** (meaning this value can change over time depending on specific parts of the algorthim). 

This will be constantly monitored by placing the following line of code at multiple parts of the algorithm, especially inside parts where there are for loops.
```C#
Process currentProcess = new Process; // Define a Process Object to get access to the monitoring methods
Console.WriteLine("Current Memory Usage: " + (currentProcess.WorkingSet65 * (1024 * 1024)) + " MB"); // Display the current Memory Usage at the line of execution in terms of Megabytes (.WorkingSet64 is in Bytes)
```


Therefore we'll be keeping track of the **Highest Memory Usage** that the algorithm may be allocated.
### Result -- C#
As a result, It seems that the average Memory usage of C# is roughly **13 MegaBytes**


## Python Memory Usage
For this the given packages that we will be using (the package involved **memory_profiler**). This package gives us details of the Memory usage of **each function that is placed under a decorator @profile**
```python
from memory_profiler import profile
@profile

# One Example of the functions we will be monitoring.

def bad_character_table(pattern):
    # empty dictionary ti store the character postions
    table = {}
    # to get the length of the pattern
    pattern_length = len(pattern)
    # Loop through the pattern characters, except for the last one
    for i in range(pattern_length - 1):
        # to Calculate the "bad character" shift for the current character to store it in the table
        table[pattern[i]] = pattern_length - 1 - i
    return table
```
In the case of all functions involved in the boyer moore algorithm, we will be placing the **@profile** decorator above each function.
![image](https://github.com/CIS1221-2023-2024/A3-StringMatching/assets/147913714/b2e654cd-5ce8-46e7-b34e-3bc44e919f57)

The image above is an example of the prompt giving us information of the memory usage for each function. 

As a result, all Functions beng run had utilized an average of **40.75 Megabytes**
Therefore;

**Python : ~40.75MB Memory Use**

**CSharp : ~13MB Memory Use**

## Conclusion

Comparing the overall memory usage of Python and C# with the boyer moore algorithm


























