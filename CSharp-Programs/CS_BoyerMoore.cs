using System;
using System.Collections.Generic;
 



namespace BoyerMoore{
    class Program{
        public static void Main(string[] args){
            Console.WriteLine("Enter a long text");
            string userText = Console.ReadLine();
            Console.WriteLine("Enter a word/pattern to search");
            string userPattern = Console.ReadLine();
            
            BoyerMoore(userText, userPattern);


        }

        static void BoyerMoore(string text, string pattern){
            Dictionary<string, int> badMatchTable = new Dictionary<string, int>(); // Create Dictionary for Bad Match Table

            for (int i = 0; i < pattern.Length ; i++){// Iterate through each character of pattern
            
                if(!(badMatchTable.ContainsKey(pattern[i].ToString()))){ // if character is not already in Dictionary
                    
                    // give key value that is the largest between 1 and the formula patternLength - charIndex - 1
                    int value = Math.Max(1, (pattern.Length - i - 1)); 
                    // add Character to bad match table with it's key value given.
                    badMatchTable.Add(pattern[i].ToString(), value); 
                    

                }else{
                    badMatchTable[pattern[i].ToString()] = Math.Max(1, pattern.Length - i - 1); // Update Key value.
                }
            }

            // Asterick represents any characters not found in the pattern, which is given a value of patternLength
            badMatchTable.Add("*", pattern.Length); 
            foreach(var entry in badMatchTable){
                Console.WriteLine(entry.Key + " : " + entry.Value);
            }
        }
    }



}