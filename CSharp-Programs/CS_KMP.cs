using System;
using System.Diagnostics;
using System.Collections.Generic;
// https://www.youtube.com/watch?v=5i7oKodCRJo Explanation of KMP algorithm - Note for developers


namespace StringMatchingKMP{

    class Program{

        static void Main(string[] args){
          // Console.WriteLine("Enter a long text with letters");
          // string text = Console.ReadLine();
          Console.WriteLine("Enter a pattern to find in your text");
          string pattern = Console.ReadLine();
          List<int> LPS = new List<int>(LPSArray(pattern));

          
          Console.WriteLine("[" + string.Join("," , LPS) + "]");



        }



        static List<int> LPSArray(string pattern){ // Return the LPS array of a given pattern
         
          int patLength = pattern.Length; // Pattern Length

          List<int> lps = new List<int>(); // LPS list 
          
          for(int i = 0; i < patLength ; i++){ // Progessively increment through each character (e.g; A,AB,ABC....ABCDEF)


            string tempPat = pattern.Substring(0, i + 1); // Create new string up to index of pattern each iteration

 
            List<string> prefix = new List<string>(); // Temporary Prefix List
            List<string> suffix = new List<string>(); // Temporary Suffix List
            




            for(int j = 0; j < tempPat.Length; j++ ){ // Create Prefix of pattern
                prefix.Add(tempPat.Substring(0, j)); // Start from index 0, till but exclusive nth index
            }
 
  
            for(int k = tempPat.Length; k > 0; k--){ // Create Suffix of pattern 
                suffix.Add(tempPat.Substring(k)); // start from index N, down till but exclusive 0th index
            }

            // # For Debugging Purposes   
            // Console.WriteLine("Prefix - [" + string.Join(",", prefix) + "]");
            // Console.WriteLine("Suffix - [" + string.Join(",", suffix) + "]"); 

            
            int count = 0;
            foreach(string pElement in prefix){ // Find common suffixes and prefixes within each other
              // Console.WriteLine("Checking " + pElement);
              if(suffix.Contains(pElement)){ // if prefix element is in suffix list
                count = pElement.Length; // add prefix element length to count
              }else{
                continue; // Ignore and go to next element
              }
            }
            Console.WriteLine("Adding to LPS " + count);
            lps.Add(count); // add count to LPS 
          }

          
          return lps;
        }

      }

}