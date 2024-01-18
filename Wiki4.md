# Edge Cases
In this section, we will be challenging the boundaries of the algorithms implemented in Python & CSharp by giving in Inputs that seem to enter an area of extremity. These can include an absurd large amount of characters, involving way too many special characters or punctuations, attempting to "hide" the words in punctuation which can actually confuse the algorithm in it's ability to skip towards the required pattern, etc.


There may not be many Edge cases for the Boyer Moore algorithm as inputting "Invalid characters" or such cannot really occur given that it recognizes **all unicode characters** and treats them as the respectful character of any input.


## Edge Case 1 - Maximum String Input
Given that Both algorithms are run using the provided Windows Console. The windows console running the algorithms only allows the user to input up to a certain amount of characters, prohibiting the user to have
an even larger input when needed

**C# Console Input Limit : 256 Characters in Console, Only about ~25,000 characters in IDE**


**Python Console Input Limit: "Endless" in Console, ~25,000 Characters in IDE**

The input limit for both python and C# seem to differ depending on the system's command prompt, in the case of python, some may allow for an endless amount of characters, for C# not so much.

Though, User wise, C# Will really only allow the user to input 256 Characters if it were to be used via command prompt. If we were to directly input large strings into the code of both the Python and C#, the IDE will begin to make it difficult to do so.



## Edge Case 2 - Overwhelming Inputs
This is to test the ability of the algorithm in it's respective programming language, it's actual accepted input, in the sense that **Will it still run?** if we forced in an overwhelming input despite the previous Edge Case's limitations.

```
Input: VCOKBJCBVOKNJPIOBVKJPOGHKUPOYTKPOGMBVKLCMNFLGKHKPORTYMHNKLFBMNLKGHMJPOYTIUASDFDHIOSDJGFIODGJIOFDGJODFGBJOBKLFDMNBODFJOFIGJDIOFJGDOIJGDOSGJIOSJGIODFJGVDOITJEWROITUWEJFVMNCJKVBNXCVKJFGHGKLDJRGBOISFGJOIERDGJNDFJKGBNKSDJRGFNKSDFGHISDKJFNJKFSDHGEJRDUKGHJKOSERJGNIOREKDGJHOISDEWJNGOJIRFSDNGHOJVCOKBJCBVOKNJPIOBVKJPOGHKUPOYTKPOGMBVKLCMNFLGKHKPORTYMHNKLFBMNLKGHMJPOYTIUASDFDHIOSDJGFIODGJIOFDGJODFGBJOBKLFDMNBODFJOFIGJDIOFJGDOIJGDOSGJIOSJGIODFJGVDOIUSERNLJKDRNGOJKERSNJKRNGKJERSWNKJRDGNRKSEJNVJKDLRGNKJRSWNKJRSNVVCOKBJCBVOKNJPIOBVKJPOGHKUPOYTKPOGMBVKLCMNFLGKHKPORTYMHNKLFBMNLKGHMJPOYTIUASDFDHIOSDJGFIODGJIOFDGJODFGBJOBKLFDMNBODFJOFIGJDIOFJGDOIJGDOSGJIOSJGIODFJGVDOIKJRSNGKJRSENVJKSLRGNJKOLSDERNVJKLRDENGKJERSDNGKJRDENGJKRDENGKJSDRNGKJSDFHJFIOEWSJKFPWEMFLKSDNVKJOREHTGIURNFJKLSDNGFJKLNIOBVKJPOGHKUPOYTKPOGMBVKLCMNFLGKIOBVKJPOGHKUPOYTKPOGMBVKLCMNFLGKIOBVKJPOGHKUPOYTKPOGMBVKLCMNFLGKDHIOSDJGFIODGJIOFDGJODFGBJOBKLFDMNBODFJOFIGJDIOFJGDOIJGDOSGJIOSJGIODFJGVDOITJEWROITUWEJFVMNCJKVBNXCVKJFGHGKLDJRGBOISFGJOIERDGJNDFJKGBNKSDVCOKBJCBVOKNJPIOBVKJPOGHKUPOYTKPOGMJRGFNKSDFGHISDKJVCOKBJCBVOKNJPIVCOKBJCBVOKNJPIOBVKJPOGHKUPOYTKPOGMBVKLCMNVCOKBJCBVOKNJPIOBVKJPOGHKUPOYTKPOGMBVKLCMNFLGKHKPORTYMHNKLFBMNLKGHMJPOYTIUASDFDHIOSDJGFIODGJIOFDGJODFGBJOBKLFDMNBODFJOFIGJDIOFJGDOIJGDOSGJIOSJGIODFJGVDOITJEWROITUWEJFVMNCJKVBNXCVKJFGHGKLDJRGBOISFGJOIERDGJNDFJKGBNKSDJRGFNKSDFGHISDKJFNJKFSDHGEJRDUKGHJKOSERJGNIOREKDGJHOISDEWJNGOJIRFSDNGHOJVCOKBJCBVOKNJPIOBVKJPOGHKUPOYTKPOGMBVKLCMNFLGKHKPORTYMHNKLFBMNLKGHMJPOYTIUASDFDHIOSDJGFIODGJIOFDGJODFGBJOBKLFDMNBODFJOFIGJDIOFJGDOIJGDOSGJIOSJGIODFJGVDOIUSERNLJKDRNGOJKERSNJKRNGKJERSWNKJRDGNRKSEJNVJKDLRGNKJRSWNKJRSNVVCOKBJCBVOKNJPIOBVKJPOGHKUPOYTKPOGMBVKLCMNFLGKHKPORTYMHNKLFBMNLKGHMJPOYTIUASDFDHIOSDJGFIODGJIOFDGJODFGBJOBKLFDMNBODFJOFIGJDIOFJGDOIJGDOSGJIOSJGIODFJGVDOIKJRSNGKJRSENVJKSLRGNJKOLSDERNVJKLRDENGKJERSDNGKJRDENGJKRDENGKJSDRNGKJSFLGKHKPORTYMHNKLFBMNLKGHMJPOYTIUASDFDHIOSDJGFIODGJIOFDGJODFGBJOBKLFDMNBODFJOFIGJDIOFJGDOIJGDOSGJIOSJGIODFJGVDOIOBVKJPOGHKUPOYTKPOGMBVKLCMNFLGKHKPORTYMHNKLFBMNLKGHMJPOYTIUASDFDHIOSDJGFIODGJIOFDGJODFGBJOBKLFDMNBODFJOFIGJDIOFJGDOIJGDOSGJIOSJGIODFJGVDOIFNJKFSDHGEJRDUKGHJKOSERJGNIOREKDGJHOISDEWJNGOJIRFSDNGHOJUSERNLJKDRNGOJKERSNJKRNGKJERSWNKJRDGNRVCOKBJCBVOKNJPIOBVKJPOGHKUVCOKBJCBVOKNJPIOBVKJPOGHKUVCOKBJCBVOKNJPIOBVKJPOGHKUVCOKBJCBVOKNJPIOBVKJPOGHKUVCOKBJCBVOKNJPIOBVKJPOGHKUGMBVKLCMNFLGKIOBVKJPOGHKUPOYTKPOGMBVKLCMGMBVKLCMNFLGKIOBVKJPOGHKUPOYTKPOGMBVKLCMJUSERNLJKDRNGOJKERSNJKRNGKJERSWNKJRDGNRKSEJNVJKDLRGNKJRSWNKJRSNVKJVCOKBJCBVOKNJPIOBVKJPOGHKUPOYTKPOGMRSNGKJRSENVJKSLRGNJKOLSDERNVJKLRDENGKJERSDNGKJRDENGJKRDENGKJSDRNGKJSDFHJFIOEWSJKFPWEMFLKSDNVKJOREHTGIURNFJKLSDNGFJKLNIOBVKJPOGHKUPOYTKPOGMBVKLCMNFLGKIOBVKJPOGHKUPOYTKPOGMBVKLCMNFLGKIOBVKJPOGHKUP

Pattern : VCOKBJCBVOKNJPIOBVKJPOGHKUPOYTKPOGMBVKLCMNFLGKHKPORTYMHNKLFBMNLKGHMJPOYTIUASDFDHIOSDJGFIODGJIOFDGJODFGBJOBKLFDMNBODFJOFIGJDIOFJGDOIJGDOSGJIOSJGIODFJGVDOITJEWROITUWEJFVMNCJKVBNXCVKJFGHGKLDJRGBOISFGJOIERDGJNDFJKGBNKSDJRGFNKSDFGHISDKJFNJKFSDHGEJRDUKGHJKOSERJGNIOREKDGJHOISDEWJNGOJIRFSDNGHOJVCOKBJCBVOKNJPIOBVKJPOGHKUPOYTKPOGMBVKLCMNFLGKHKPORTYMHNKLFBMNLKGHMJPOYTIUASDFDHIOSDJGFIODGJIOFDGJODFGBJOBKLFDMNBODFJOFIGJDIOFJGDOIJGDOSGJIOSJGIODFJGVDOIUSERNLJKDRNGOJKERSNJKRNGKJERSWNKJRDGNRKSEJNVJKDLRGNKJRSWNKJRSNVVCOKBJCBVOKNJPIOBVKJPOGHKUPOYTKPOGMBVKLCMNFLGKHKPORTYMHNKLFBMNLKGHMJPOYTIUASDFDHIOSDJGFIODGJIOFDGJODFGBJOBKLFDMNBODFJOFIGJDIOFJGDOIJGDOSGJIOSJGIODFJGVDOIKJRSNGKJRSENVJKSLRGNJKOLSDERNVJKLRDENGKJERSDNGKJRDENGJKRDENGKJSDRNGKJS
```

The initial character count of the Input is about **2560 Characters** whilst the Pattern, **726 Characters**.

### Result :
#### C# 
manually programming the variables to contain the long string doesn't really seem to have a maximum length. By continuously copying and pasting the input string, it was at some point, exceeding **25,000 Characters** and was still able to run the comparison. 

We will be copying and pasting our inputs continuously, varying the character count and seeing hte result.

- At 2560 Characters of the Long String & 726 Characters of the pattern : **Maximum Memory at 17MB, Completion at 269 milliseconds**

- At 24210 Characters of the Long String & 726 Characters of the pattern: **Maximum Memory at 17 MB, Completion at 270 Milliseconds**

The C# Program of Boyer Moore from a user perspective has quite a limited input ability given that if the user utilized a command prompt, they'd only be able to input 256 Characters.
However, from a programmer's perspective, directly inputting long strings into the code's variables to search from, there seems to only be an ability to input ~25,000 Characters in each variable before the IDE
begins to sort of "prohibit" us from properly inputting it, making arrangements a bit difficult.




#### Python

- At 2560 Characters of the Long String & 726 Characters of the pattern: **Maximum Memory at ~23.8MB, Completion in 83 milliseconds**
  
- At 24210 Characters of the Long String & 726 Characters of the pattern: **Memory yet again set at 23.8Mb, Completion in 174 Milliseconds**

In the case of Python, the command prompt does seem to allow an Endless length of strings being inputted into the console, a huge nuance. Though IDE-Wise, it's practically the same situation as the C# program.


## Conclusion
In the most practical sense for how the user would normally utilize a string matching feature, with python, there doesn't seem to be a limit to what the program will be able to search for a string regardless of how long both the long string and the pattern the user may wish to search. However for C# they may be limited if they were to use it with a command prompt, a GUI would be able to overcome this issue.



## Edge Case 3 - Overlapping Patterns

Here we will be testing the Algorithms on both programming languages to see how well they handle situations where 2 instances of a pattern overlap onto each other.

As an example we'll take the following input

```
Input = ATAGADATATA
Pattern = ATA
```
Here we can notice that there's actually 2 instances of ATA starting at index 6 and 8.


### Result:
#### C#
CSharp actually ignores the left most occurance of the pattern and instead only pays attention to the right most occurance if the substring ATATA is read and our pattern is ATA.

#### Python 
Python does the complete opposite, ignoring the right most occurance of the pattern ATA in ATATA and instead only records the left most occurance.



## Edge Case 4 - Case Sensitivity
Here we will be testing if whether or not the boyer moore string matching algorithm is capable of differentiating between strings and patterns which are in upper case or lower case.
Of course, given that by default, a letter with its capitalized counterpart are recognized as two different unicode characters thus we'll keep the algorithm to be case sensitive.

This also implies that the good suffix table and bad match table would create individual values for both a letter and it's said uppercase counterpart.

For this case, we will be utilizing the following inputs:

```
Input = This will be a long sentence with the word "this". Our input will be the pattern "This" with a capital T. This should only give us the indexes of all words "this" that have only a capital T.
"This" that "That" and this...

Pattern = This
2nd Pattern = this 
```

### Result
### C# 
C# was able to return just only the instances of which the word "This" starts with a capital T and as well as the word "this" that starts with a non-capital t, in separate tests.
Therefore, The C# Algorithm is indeed case sensitive.

### Results of finding "This" 
![image](https://github.com/CIS1221-2023-2024/A3-StringMatching/assets/147913714/45fe397f-e3d4-445d-bca7-1de6a3b1dd88)

### Results of finding "this" 

![image](https://github.com/CIS1221-2023-2024/A3-StringMatching/assets/147913714/64259746-3fbd-4ce7-8dee-36ce4abfdf17)



### Python
### Results of finding "This"
![image](https://github.com/CIS1221-2023-2024/A3-StringMatching/assets/147913714/bcaab78f-ca56-4591-82e0-f49837a817f3)

### Results of finding "this"
![image](https://github.com/CIS1221-2023-2024/A3-StringMatching/assets/147913714/12edfcd4-acec-4e0c-8a71-4c3c36a86b8f)

This shows that both the python and C# Implementation of the boyer moore algorithm retain a case sensitivity feature within their functionality as they returned the same indexes of occurances. This is primarily due to the reason that by unicode, T and t and all other letters and their uppercase counterparts are not "the same" character. If a non-case sensitive setting were to be made, there'd have to be functions such as **.lower()** or **ToLower()** used in the generation of both tables from both heuristics.







