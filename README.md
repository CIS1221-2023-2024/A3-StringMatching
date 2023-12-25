# Boyer-Moore String Matching Project

# The Wiki Pages:
- [Wiki Page 1](Wiki1.md)
- [Wiki Page 2](Wiki2.md)

# Introduction
This project implements the Boyer-Moore algorithm for string matching, demonstrating its efficiency and effectiveness in text search. The implementation is provided in both Python and C# to showcase the algorithm's application in different programming environments.

# Team Members

Elmuntserbalah Taher: Focus on Python implementation, algorithm optimization , Documentation.

David Isaac: Specialized in C# implementation, testing, algorithm optimization and documentation.

# Running the Project


Python:

-1 Navigate to the Python source folder: cd [Python source folder]

=2 Run the script: python boyer_moore.py


C#:

-1 Navigate to the C# project folder: cd [C# project folder]

-2 Build and run the project: dotnet run


**How to Clone the Repository**
To simply clone (download) the repoistory to gain access to all the files, just open up your command terminal and run the following command:

*Note:* Be sure to run this after changing the directory of your command line "cd" to preferably your desktop path.

```
git clone https://github.com/CIS1221-2023-2024/A3-StringMatching.git
```


**Accessing the folder's contents**
Once you've cloned the folder, change your terminal's directory to the path of where the folder may be stored in.

```
cd C:/Path/To/File/A3-StringMatching
```


## CSharp Files

The CSharp file once compiled using the terminal will create an executable *.exe* file. To run the respective CSharp programs, simply enter the command on your terminal
```
CSharpProgram.exe
``` 
If you're using a built-in terminal like VSCode's Terminal, you may have to run the executables like so:
```
./CSharpProgram.exe
```

## Python Files
If you are using an IDE like VSCode, you can run the python files through there by using the Run feature. However if you wish to access this with cmd prompt;
```
cd path/to/python/file
```
And once in the same directory as the python file simply run the command
```
python pythonProgram.py
```



# Reviewing and Evaluating the Project
Guidelines for Reviewers
Focus on the following aspects:

Algorithm Implementation: Correctness and efficiency of the Boyer-Moore algorithm.

Language-Specific Features: Effective use of Python and C# features.

Code Quality: Readability, comments, and organization.

Comparative Analysis: Comparison between Python and C# implementations in terms of performance.


Evaluation Criteria

Execution Speed: Time taken for various string and pattern lengths.


Resource Usage:

CPU usage: Efficient use of resources like optimizing performance

Memory Usage: Efficient use of resources.

Cross-Language Functionality: Consistency in results between Python and C# versions.

# Input Examples
You may input the following example patterns in the C# Console as well as the Python Console when running the programs.

Example (1) 

text = "AABAACAADAABAAABAAAABABBABABAAABBBBAAABABAAABBBABAAABABBAABABBAABABA"

    pattern = "AABA"
    output : Match Found at 0,9,56

Example (2) 

text = "KEOLCOLALLOCOLAKELEKCOLACOCCOCOLACOLAAAOLOCOALCOLAOCLOACOLAALOOCLCOLAKE"

    pattern = "COLA"
    output: Match Found at 4,11,20,29,33,46,55,65
    
# Contact

For any queries or contributions, please reach out to:

Elmuntserbalah Taher: [moanta.taher.22@um.edu.mt]

David Isaac: [david.i.ohayon.23@um.edu.mt]
