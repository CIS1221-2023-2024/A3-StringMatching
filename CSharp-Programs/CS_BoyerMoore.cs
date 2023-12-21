using System;
using System.Collections.Generic;
using System.Linq;
 



namespace BoyerMoore{
    class Program{
        public static void Main(string[] args){
            Console.WriteLine("Enter a long text");
            string userText = Console.ReadLine();
            Console.WriteLine("Enter a word/pattern to search");
            string userPattern = Console.ReadLine();
            
            BoyerMoore(userText, userPattern);


        }




        
        
        
        
        
        
        static void GoodSuffixTable(string pattern){

            int pLength = pattern.Length; // Pattern Length
            int lastIndex = pLength - 1; // Last Pattern Character

            List<int> goodSuffixTable = new List<int>();
            for(int i = 0; i < pLength; i++){
                goodSuffixTable.Add(0); // Generate Default Good Suffix Table
            }
            Console.WriteLine("Good Suffix Table Function Run.");




            for(int i = 1; i < pLength - 1 ; i++){ // Iteration for Suffix

                // Console.WriteLine("Outer Iteration on index" + i);
                string tempSuffix = pattern.Substring(pLength - i); // Get temp suffix
                string precedingChar = pattern[pLength - i - 1].ToString(); // Get Preceding character (Character previous to our suffix)
                // Console.WriteLine($"Current Suffix {tempSuffix} Current Prefix {tempPrefix}");

                bool noPrefix = false; // Matching Prefix to Suffix was found but has same previous character. (For Optimization)
                int lastPrefix = 0; // Last Prefix with a common preceding character 
                int suffixLength = tempSuffix.Length;


                for(int x = 1; x < pLength - suffixLength ; x++){// Find next Prefix up to characters excluding the suffix characters.
                    // Console.WriteLine("Inner iteration inside " + x);

                    // Console.WriteLine($"{pattern.Substring(x, suffixLength)} Compared with {tempSuffix}");
                    // Console.WriteLine("ooo, what's this " + pattern.Substring(x, suffixLength));
                    

                    
                    if(pattern.Substring(x , suffixLength) == tempSuffix){ // If Prefix matches Suffix


                         // Case 1 - Matching Prefix with Suffix but different previous characters.

                         // Developer Note. If two existing prefixes with different 
                         // preceding characters exist. This will basically override the earliest 
                         // prefixes with the last one automatically. (Hence getting the "longest prefix")

                        if(pattern[x].ToString() != precedingChar){ 

                            // Console.WriteLine($"Found matching Prefix, Our Suffix {tempSuffix} with preceeding {pattern[x - 1]} matched with {pattern.Substring(x, suffixLength)}");
                            // Console.WriteLine("This ran");
                            int prefixIndex = x - 1; // Index at which the inner prefix starts from
                            noPrefix = false; // a prefix was found.

                            goodSuffixTable[pLength - suffixLength] = (pLength - i - suffixLength);


                         // Case 2 - Find the longest Prefix of our suffix ( This is if Case 1 Has absolutely no chance in occuring)
                        }else{
                         
                            lastPrefix = x; // Update Index to when last prefix was found. (This is to monitor all prefixes if more than 1 prefix with same preceding char is found.)
                            noPrefix = true; // To acknowledge that till now. No matching prefix was found.

                            // Wait till inner iteration finishes. 

                        }
                    

                    }
                }
                // Continuation of Case 2.
                if(noPrefix){
                    for(int x = lastPrefix; x <= pLength - suffixLength; x++){
                        Console.WriteLine("Suffix of Prefix " + pattern.Substring(lastPrefix, x));
                    }
                }




            }
            Console.WriteLine("---------");
            foreach(int element in goodSuffixTable){
                Console.WriteLine(element);
            }
            Console.WriteLine("---------");
        }



        static void BoyerMoore(string text, string pattern){
            Dictionary<string, int> badMatchTable = new Dictionary<string, int>(); // Create Dictionary for Bad Match Table
            int pLength = pattern.Length;
            int tLength = text.Length;

            GoodSuffixTable(pattern);


            // # Creation of Bad Match Table
            for (int i = 0; i < pLength ; i++){// Iterate through each character of pattern

                if(!(badMatchTable.ContainsKey(pattern[i].ToString()))){ // if character is not already in Dictionary
                    
                    // give key value that is the largest between 1 and the formula patternLength - charIndex - 1
                    int value = Math.Max(1, (pattern.Length - i - 1)); 
                    // add Character to bad match table with it's key value given.
                    badMatchTable[pattern[i].ToString()] =  value; 
    

                }else{ // If there are duplicate letters
                    badMatchTable[pattern[i].ToString()] = Math.Max(1, pattern.Length - i - 1); // Update the respective key value that is a duplicate.
                }
            }
            // Asterick represents any characters not found in the pattern, which is given a value of patternLength
            badMatchTable.Add("*", pattern.Length); 
            
            
            Console.WriteLine("----- Bad Match Table------");
            foreach(var kvp in badMatchTable){
                Console.WriteLine(kvp);
            }
            Console.WriteLine("-----------");



            int index = pLength - 1; // Index of Entire text. which starts at right most character.
            int lastElement = pLength - 1; // Last Element of pattern


            while(index < tLength){ // Iterate until index reaches tLength

                
                if(text[index] == pattern[lastElement]){ // If the right-most character matches with a character

                    int l = lastElement; // iteration counter for character by character comparison.

                    while(l >= 0){ // (When Right most character of pattern matches something on the text) Iterate till all characters are checked.
                        
                        if(text[index] != pattern[l]){ // If characters in pattern & text don't match.
                        
                            // Check from Bad Match Table how much to skip 
                           if(badMatchTable.ContainsKey(text[index].ToString())){ // Check if mismatched character in text exists on table 
                               index = index + badMatchTable[text[index].ToString()]; // Skip respective positions of character
                               break;
                           }else{

                              index = index + badMatchTable["*"]; // Skip entire pattern length.
                              break;
                           }
                        }else{
                          l--; // Decrement to next (previous) character in pattern
                          index--; // Decrement to next (previous) character in text
                        }


                        if(l < 0){ // If the algorithm manages to match every character, It's a match.
                            Console.WriteLine("Match found at : " + (index + 1) ); 
                            index = index + pLength + 1; // Update the Index to go to the n + 1th character.
                            break;
                            
                        }
                    }
                }else{ // If the first right most character doesn't match straight away

                    if(badMatchTable.ContainsKey(text[index].ToString())){ // Find if it exists in the bad match table
                        index = index + badMatchTable[text[index].ToString()]; // If it does, add it's respective value to the index
                    }else{
                        index = index + badMatchTable["*"]; // If not, skip the whole pattern length.
                    }
                }
                
            }

        }
    }



}