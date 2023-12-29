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
























