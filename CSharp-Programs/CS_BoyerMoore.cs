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
            int pLength = pattern.Length;
            int tLength = text.Length;


            // # Creation of Bad Match Table
            for (int i = 0; i < pLength ; i++){// Iterate through each character of pattern

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






            // For Debugging 
            // foreach(var entry in badMatchTable){ 
            //     Console.WriteLine(entry.Key + " : " + entry.Value);
            // }



            // Requires Fixing for actual Boyer-Moore comparison.
            int iter = pLength - 1;
            int patIndex = pLength - 1;

            while(iter <= tLength - 1){
                Console.WriteLine("Comparing : " + text[iter] + " with " + pattern[patIndex] + " At index " + iter);
                if(text[iter] == pattern[patIndex]){
                       Console.WriteLine("Match Found, Entering For Loop Iteration");
                       int a = iter;
                       for(int k = 0 ; k < patIndex; k++){
                         Console.WriteLine("Comparing : " + text[a - k] + " with " + pattern[patIndex - k] + " At index " + (a - k));
                         if(text[a - k] != pattern[patIndex - k]){
                            if(badMatchTable.ContainsKey(text[a-k].ToString())){
                                iter = iter + badMatchTable[text[a-k].ToString()];
                            }else{
                                iter = iter + badMatchTable["*"];
                            }
                         }

                         if(a == 0){
                            Console.WriteLine("Match found at index " + iter);
                         }


                       }




                }else{
                    Console.WriteLine("No Match Found");
                    if(badMatchTable.ContainsKey(text[iter].ToString())){
                        Console.WriteLine("Key is not in dictionary");
                        iter = iter + badMatchTable["*"];
                        Console.WriteLine("This ran well");
                        Console.WriteLine("New Value of Iter " + iter);
                    }else{
                        Console.WriteLine("Key is in dictionary");
                        iter = iter + badMatchTable[text[patIndex].ToString()];
                        Console.WriteLine("This ran well");
                        Console.WriteLine("New Value of Iter " + iter);
                    }
                }
            }







        }
    }



}