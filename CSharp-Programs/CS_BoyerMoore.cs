using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
 



namespace BoyerMoore{
    class Program{
        public static void Main(string[] args){
            Stopwatch stopwatch = new Stopwatch();
        
            Console.WriteLine("Enter a long text");
            string userText =  Console.ReadLine();

            Console.WriteLine("Enter a word/pattern to search");
            string userPattern = Console.ReadLine();    
            stopwatch.Start();
            BoyerMoore(userText, userPattern);
            stopwatch.Stop();

            long elapsedTime = stopwatch.ElapsedMilliseconds;                                                                                                                                
            Console.WriteLine(elapsedTime);


        }

        static int GetSuffixLength(string pattern, int index){ // Returns the suffix length 
            int suffixLength = 0;
            int pLength = pattern.Length;

            for(int i = index; i >= 0; i--){
                if(pattern[i] == pattern[pLength - 1 - index + i]){ // If both characters at both pointers match
                    suffixLength++; // Increment suffix length
                }
                // This is to check for any matching substrings of the Suffix, and of the Pattern itself. the Left Pointer will start at Index, The left will start at the end of the pattern
                // Then each pointer goes down by a character each time to check if they both point at matching strings.


                // EG: Our Pattern is ABACADATA
                // When Index = 4. Then
                //  ABACADATA
                //      ^   ^ First Match. Increase Suffix Length.
                //  ABACADATA Now The left Pointer goes down to C, Right pointer goes down to T
                //     ^   ^ No Match.
                //  ABACADATA
                //    ^   ^  Match. Increase suffix Length. And thus continue until I < 0.
                // Credits to github.com/dwnusbaum for this bit of code ( my saviour )
            }

            return suffixLength;


        }
        
        static List<int> GoodSuffixTable(string pattern){
            int pLength = pattern.Length; // Length of the pattern
            int lastPrefixIndex = pLength - 1; // Recording the last prefix that was recorded by its index.

            List<int> goodSuffixTable = new List<int>();
            
            
            for(int i = 0; i < pLength; i++){
                goodSuffixTable.Add(-1); // Initilizing default values for good suffix table values.

            }
            
            // First Case -- A Matching Prefix found within the Pattern (This prefix equals our Suffix)
            for(int i = pLength - 1; i > 0; i--){ // Start from the right most character 
                
                string tempSuffix = pattern.Substring(i + 1); // Generate a suffix 


                for(int x = 0; x < pLength - tempSuffix.Length - 1; x++){ // Find a Matching prefix
                    string tempPrefix = pattern.Substring(0, x); // Generate a prefix
                    if(tempSuffix == tempPrefix){ // if our Prefix is matching our suffix
                        lastPrefixIndex = i + 1; // Record the Index that our suffix starts from 
                    }
                    
                }
                goodSuffixTable[i] = lastPrefixIndex + (pattern.Length - 1 - i);
            
            }

            // Second Case -- A Tail of the suffix occurs in the pattern before the suffix itself.
            // Example : our Pattern is ABDATCATA, and our suffix is ATA. the Tail of it is TA. and TA appears at index 3.

            // (Credits yet again to Github.com/dwnusbaum for the 2nd bit)
            for(int i = 0; i < pLength - 1; i++){ 
 
                int suffixLength = GetSuffixLength(pattern, i); // Gets the Suffix Length for each suffix
                
                if (pattern[i - suffixLength] != pattern[pLength - 1 - suffixLength]){                   
                    goodSuffixTable[pLength - 1 - suffixLength] = pLength - 1 - i + suffixLength;
                }

            }

            return goodSuffixTable;
        }
        
    

        static void BoyerMoore(string text, string pattern){
            Dictionary<string, int> badMatchTable = new Dictionary<string, int>(); // Create Dictionary for Bad Match Table
            int pLength = pattern.Length;
            int tLength = text.Length;
            bool found = false;


            List<int> GoodSuffix = GoodSuffixTable(pattern); // Generate a good suffix table
            // Console.WriteLine("Current Memory Usage : " + (memoryUsage.WorkingSet64 / (1024 * 1024)));


            // # Creation of Bad Match Table
            for (int i = 0; i < pLength ; i++){// Iterate through each character of pattern

                if(!(badMatchTable.ContainsKey(pattern[i].ToString()))){ // if character is not already in Dictionary
                    
                    // give key value that follows the formula:  patternLength - charIndex - 1
                    int value = pattern.Length - i - 1; 
                    // add Character to bad match table with it's key value given.
                    badMatchTable[pattern[i].ToString()] =  value; 
                }else{ // If there are duplicate letters
                    badMatchTable[pattern[i].ToString()] = Math.Max(1, pattern.Length - i - 1); // Update the respective key value that is a duplicate.
                }
            }
            // Asterick represents any characters not found in the pattern, which is given a value of patternLength
            badMatchTable.Add("*", pattern.Length); 
            
            
            
            // For Testing Purposes
            Console.WriteLine("----- Bad Match Table------");
            foreach(var kvp in badMatchTable){
                Console.WriteLine(kvp);
            }
            Console.WriteLine("-----------");

            Console.WriteLine("---- Good Suffix Table -----");
            foreach(var kvp in GoodSuffix){
                Console.WriteLine(kvp);
            }
            Console.WriteLine("-----------");




            int index = pLength - 1; // Index of Entire text. which starts at right most character.
            int lastElement = pLength - 1; // Last Element of pattern


            while(index < tLength){ // Iterate until index reaches tLength



                // Console.WriteLine("Current Memory Usage : " + (memoryUsage.WorkingSet64 / (1024 * 1024)));   
                if(text[index] == pattern[lastElement]){ // If the right-most character matches with a character

                    int l = lastElement; // iteration counter for character by character comparison.

                    while(l >= 0){ // (When Right most character of pattern matches something on the text) Iterate till all characters are checked.
                        
                        if(text[index] != pattern[l]){ // If characters in pattern & text don't match.
                        
                            // Check from Bad Match Table how much to skip 


                           if(badMatchTable.ContainsKey(text[index].ToString())){ // Check if mismatched character in text exists on table 
                               int skip = Math.Max(badMatchTable[text[index].ToString()], GoodSuffix[l]); // Choose the largest skip possible.
                               index = index + skip; // Skip respective positions of character
                               break;
                           }else{
                              
                              int skip = Math.Max(badMatchTable["*"], GoodSuffix[l]); // Choose largest skip possible
                              index = index + skip; // Skip entire pattern length.
                              break;
                           }
                        }else{
                          l--; // Decrement to preceding character in pattern
                          index--; // Decrement to preceding character in text
                        }


                        if(l < 0){ // If the algorithm manages to match every character, It's a match.
                            Console.WriteLine("Match found at : " + (index + 1) );
                            found = true; // something was at least found.
                            index = index + pLength + 1; // Update the Index to go to the n + 1th character.
                            break;
                            
                        }
                    }
                }else{ // If the first right most character doesn't match straight away

                    if(badMatchTable.ContainsKey(text[index].ToString())){ // Find if it exists in the bad match table
                        int skip = Math.Max(badMatchTable[text[index].ToString()], GoodSuffix[lastElement]); // Choose the largest skip possible.
                        index = index + skip; // If it does, add it's respective value to the index
                    }else{
                        int skip = Math.Max(badMatchTable["*"], GoodSuffix[lastElement]); // Choose the largest skip possible.
                        index = index + skip; // If not, skip the whole pattern length.
                    }
                }
                
            }
            if(!found){
                Console.WriteLine("The string inputted was not found.");
            }

        }
    }
}