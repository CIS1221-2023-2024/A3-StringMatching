using System;
using System.Diagnostics;

/*
* Note: Upon compilation of this C-Sharp program, the compiler will generate an executable file (.exe) just be sure to run "csc" and then 
* "name_of_file.exe" in the command prompt.
* 
* The comments are debug console loggers.
*/ 
namespace StringMatching
{
    class Program
    {
      static void Main(string[] args){

          Console.WriteLine("Enter a long text with letters");
          string text = Console.ReadLine();
          Console.WriteLine("Enter a pattern to find in your text");
          string pattern = Console.ReadLine();
          StringMatch(text, pattern);

      }

      static void StringMatch(string text, string pattern){ // Naive-Algorithm
        Stopwatch timeRec = new Stopwatch();
        timeRec.Start();
        int count = 0; // Pattern Index 
        int patLength = pattern.Length;
        int txtLength = text.Length;

        if(patLength > txtLength){ // Validation (Pattern must never be > than Text length)
          Console.WriteLine("Pattern length cannot exceed Text length.");
          Console.ReadLine();
          return;
        }



        for(int i = 0; i < txtLength - 1; i++){ // Iterate through text
          // Console.WriteLine($"Starting at index {i}"
          count = 0; // Initiate Pattern Index to 0
          // Console.WriteLine("Initiated new Loop" + " Count Value: " + count + " Index Value " + i );
          

          while(count < patLength){ // Perform Comparative Iteration
            // Console.WriteLine("Comparing text " + text[i + count] + " with pat " + pattern[count]);
            if(text[i + count] != pattern[count]){ // If 1 letter doesn't match
              // Console.WriteLine("Breaking...");
              break; // terminate iteration
            }else{
              count++; // move to (N + 1)th letter
              if(count == patLength){ // if all pattern letters are matched
                Console.WriteLine("Match detected at index " + i); // Indicate starting index in text
              }
            
            }
          }
        }
        timeRec.Stop();
        long elapsedTime = timeRec.ElapsedMilliseconds;
        Console.WriteLine("Whole program finished " + elapsedTime + "ms");


      }
    }



}