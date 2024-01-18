# Benchmarking the algorithms

In this section we will be benchmarking the boyer-moore algorithm in both programming languages to determine it's efficiency compared to other algorithms in the same programming languages, as well as 
documenting the resources it requires as well as execution time.

NOTE : The benchmarking made here will be benchmarking the attempts of implementing the algorithm and not the *"actual algorithm"* in a perfect sense. Better attempts exists on the internet




# Execution Time
We will be documenting the execution time the boyer moore algorithm takes through each respective programming language and comparing them with other algorithms executed in the same programming languages.

## C# Boyer Moore
A pre-existing library  (**System.Diagonistics**) providing the appropriate functions in measuring execution time will be used for this documentation.
```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace BoyerMoore{
    class Program{
        public static void Main(string[] args){

            Stopwatch stopwatch = new Stopwatch();
        



            Console.WriteLine("Enter a long text");
            string userText = Console.ReadLine();
            Console.WriteLine("Enter a word/pattern to search");
            string userPattern = Console.ReadLine();

            stopwatch.Start();
            BoyerMoore(userText, userPattern);
            stopwatch.Stop();

            TimeSpan elapsedTime = stopwatch.ElapsedMilliseconds;

            Console.WriteLine("Program finished in " + elapsedTime + "ms");


        }
```


```
ExampleInput = This is a sample text that will contain an explanation of the boyer moore algorithm, within this sample text there will be a "word" word. Which will be deliberately emphasized as this is also going to be an input example for the boyer moore string matching algorithm in order to find this word.


The boyer moore algorithm is said to be the most effective and most efficient string matching algorithm when it comes to finding specific words. It makes use of two certain heuristics in order to efficiently find that said specific word by having them allow the algorithm to skip a certain amount of indexes in the long paragrah, sentence, etc in order to reach a match with that word. 

The two heuristics in question are the good suffix table heuristic and the bad character table heuristic. The bad character heuristic works mainly by the use of a mathematically defined formula which applies to any word inputted that is to be searched. This formula generates values for all the unique letters of the word for the algorithm to use to skip an amount of characters in the long string.


The good suffix table heuristic is a bit more counter intuitive and may be quite a challenging concept for the average programmer. It works by 2 Rules. The first rule being that if in a word, a right most suffix is found to be matching a prefix (the left most prefix) and they both don't have the same preceding character (e.g ABA & CBA) the distance between them will be recorded. The second rule being that if in a word, the first rule cannot be applied, and that either a matching prefix has the same preceding character as the suffix, or there is no matching prefix at all, then their matching tails will have to be taken into consideration instead for the word.



Pattern = word
```

The pattern occurs quite frequently here, just to test further the execution time for when there are several words that match the pattern, in order to maximize the needed loops to execute relevant checks.

The Unfortunate part here is that C# being run in the console does not allow us to insert the entire text here given the console prompt when running CS files gives us a limit of only 256 Characters as an input, so we have to directly insert the entire text as a string variable.

Given the possibile inconsistencies in results, we will also be taking the execution time twice and averaging them out.    

**Note: Execution Times may vary depending on the system it is being executed on and also not to mention that our Implementation of boyer moore runs with the two heuristics, which add more complexity 
which over all may also impact the performance.**



### 1st Test -- C#
![image](https://github.com/CIS1221-2023-2024/A3-StringMatching/assets/147913714/0f900394-c7bc-4f40-b917-8a7e8e571531)




Recorded Time: **11 Milliseconds**
### 2nd Test -- C#
![image](https://github.com/CIS1221-2023-2024/A3-StringMatching/assets/147913714/deab71e8-e6f0-4303-8ef6-cf7b5fa2b912)





Recorded Time: **9 Milliseconds**

**Overall Average: 10 Milliseconds**


Other Algorithms like the **KMP (Knuth-Morris Pratt)** and **Naive Algorithm** have been run as well with the same input example to document the time difference between the three algorithms.

**KMP Average Time C#: 10.2 Milliseconds**

**Naive Algorithm C#: 12.5 Milliseconds**

Through a graph representation, we may see that with C#, The Boyer moore algorithm took less time than the Naive Algorithm, succeeded **barely** faster than the KMP algorithm. 

![image](https://github.com/CIS1221-2023-2024/A3-StringMatching/assets/147913714/d366c250-04ab-415c-b168-0271ba9126a1)

**Statistics: Our C# implementation of the boyer moore algorithm is barely faster than the KMP C# algorithm and about 25% faster than the Naive C# algorithm**


** Important To Note: Our own Implementation of the C# algorithm of Boyer Moore may include inefficient practices which may overall influence the actual execution time of the algorithm.**




## Python Boyer Moore
We will also be using a pre-existing library to document and monitor the execution time for the python file of the Boyer Moore Algorithm as well as comparing the execution time of this algorithm with the same other ones (KMP & Naive)


```python
    if not text:
        print("You didn't input any text.")
    elif not pattern:
        print("You didn't input any pattern.")
        
    else:
        # Call the Boyer-Moore search algorithm
        start = time.time()
        found_indices = boyer_moore(text, pattern)
        end = time.time()

        if found_indices:
            print("Pattern found at indices:", found_indices)

        if not found_indices:
            print('Pattern is not matching in the text')

        print(f"{(end - start) * 1000} Milliseconds")

```

**Note:** The time difference calculated in the end is multiplied by 1000 to convert it into **milliseconds**
### 1st Test -- Python
![image](https://github.com/CIS1221-2023-2024/A3-StringMatching/assets/147913714/77c685a2-d962-4c29-9b30-507746654b3b)

Recorded Time: **0.5 Milliseconds** 

### 2nd Test -- Python
![image](https://github.com/CIS1221-2023-2024/A3-StringMatching/assets/147913714/a4333b8d-13b2-4bbd-9e7d-ca6e9604493c)

Recorded Time: **0.5 Milliseconds** 

**Overall Average: 0.5 Milliseconds**


And of course, we've run the other algorithms in the respective python language as well and collected their average:

**KMP Average Time Python: 9.50 Milliseconds**

**Naive Average Time Python : 13.85 Milliseconds** 

![image](https://github.com/CIS1221-2023-2024/A3-StringMatching/assets/147913714/6fd65630-5c49-4375-b7de-5119244b45f5)


**Statistics: Our Python implementation of Boyer Moore Took was incredibly fast, taking up less than a millisecond to execute, making it comparatively **1,900%** Faster than the KMP Python implemented algorithm and **2,770%** faster than the Naive Python implemented algorithm**

![image](https://github.com/CIS1221-2023-2024/A3-StringMatching/assets/147913714/0c2453a5-89a5-4c1d-83fc-8e9102e6821f)



## Conclusion
Thus Overall, in Comparison Python was capable at running our implemented algorithms of Boyer Moore roughly **2,000%** faster than C# with our boyer moore implementation



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
using System.Diagnostics;
Process currentProcess = Process.GetCurrentProcess; // Define a Process Object to get access to the monitoring methods
Console.WriteLine("Current Memory Usage: " + (currentProcess.WorkingSet65 * (1024 * 1024)) + " MB"); // Display the current Memory Usage at the line of execution in terms of Megabytes (.WorkingSet64 is in Bytes)
```


Therefore we'll be keeping track of the **Highest Memory Usage** that the algorithm may be allocated.
 
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
![image](https://github.com/CIS1221-2023-2024/A3-StringMatching/assets/147913714/3783be6e-dbfb-48ea-a955-c359558c8dc6)


The image above is an example of the prompt giving us information of the memory usage for each line running in the function.

As a result, all Functions beng run had utilized an average of **40.75 Megabytes**
Therefore;

**Python : ~40.75MB Memory Use**

**CSharp : ~13MB Memory Use**

## Conclusion

Comparing the overall memory usage of Python and C# with the boyer moore algorithm



![image](https://github.com/CIS1221-2023-2024/A3-StringMatching/assets/147913714/c9d02f8b-e2a2-4992-98ed-09ed8ff0f990)


The C# Implementation of Boyer Moore takes up **~69%** Less memory than the Python Implementation 




# CPU Usage

Here we will be measuring the CPU usage that both the programming languages utilize when running the Boyer Moore algorithm. We will be using certain libraries within C# and Python, specifically for Python **Psutil** and for C# **System.Threading**

To measure CPU Usage we will also be utilizing the following inputs (The same inputs we used to benchmark the excecution times)
```
Input = This is a sample text that will contain an explanation of the boyer moore algorithm, within this sample text there will be a "word" word. Which will be deliberately emphasized as this is also going to be an input example for the boyer moore string matching algorithm in order to find this word.The boyer moore algorithm is said to be the most effective and most efficient string matching algorithm when it comes to finding specific words. It makes use of two certain heuristics in order to efficiently find that said specific word by having them allow the algorithm to skip a certain amount of indexes in the long paragrah, sentence, etc in order to reach a match with that word. The two heuristics in question are the good suffix table heuristic and the bad character table heuristic. The bad character heuristic works mainly by the use of a mathematically defined formula which applies to any word inputted that is to be searched. This formula generates values for all the unique letters of the word for the algorithm to use to skip an amount of characters in the long string.The good suffix table heuristic is a bit more counter intuitive and may be quite a challenging concept for the average


Pattern = word
```


## C#
For C# as previously mentioned, we utilized a pre-defined library **System.Threading** which allows us to record the CPU usage. This works by us calling the **.NextValue() method** on a **PerformanceCounter** object. We call this method twice, once before the Main function calls the Boyer Moore method, and after. **This is to allow the PerformanceCounter to record meaningful data during the interval of which the functions are running**


```C#
using System.Threading;

namespace BoyerMoore{
    class Program{
        public static void Main(string[] args){

            PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            string userText  = "OurPattern"
            string userPattern = "word";

            cpuCounter.NextValue(); // Call For the initial CPU usage readings
            BoyerMoore(userText, userPattern); // Call method

            Thread.Sleep(1000); // Call the sleep method for 1000 Milliseconds (1 Second) to allow the counter to collect the data.

            float finalCpuUsage = cpuCounter.NextValue(); // Call for the final CPU usage reading.

            Console.WriteLine(final);
        }

```

And Thus, we will be recording the Average CPU Usage **Three** Times on the C# program and check the overall average

### Call 1
![image](https://github.com/CIS1221-2023-2024/A3-StringMatching/assets/147913714/48814d8d-c681-4dd3-bf72-38c05b542b17)

### Call 2
![image](https://github.com/CIS1221-2023-2024/A3-StringMatching/assets/147913714/236c3e8a-3636-4ee1-a57c-b19cbe2ea926)

### Call 3
![image](https://github.com/CIS1221-2023-2024/A3-StringMatching/assets/147913714/55fe6c08-347b-4650-8dbd-2bf63cb54e89)


So the Overall average CPU usage for the C# implementation of Boyer Moore is roughly **2.10**


## Python
For python we had to resort to a third party package named **Psutil** which has a similar function to the Systems.Threading method. Which also records data of CPU usage in 1 second.

```python
        found_indices = boyer_moore(text, pattern)
        finalCpuUsage = psutil.cpu_percent(interval=1) # Can be called after the boyer moore method is called (Data collected at an interval of 1 second)

        print(f"Final CPU Usage {finalCpuUsage}%")

```






