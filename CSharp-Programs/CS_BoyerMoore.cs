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
                string tempPrefix = pattern[pLength - i - 1].ToString(); // Get Prefix (Character previous to our suffix)
                // Console.WriteLine($"Current Suffix {tempSuffix} Current Prefix {tempPrefix}");

                int suffixLength = tempSuffix.Length;

                for(int x = 1; x < pLength - suffixLength ; x++){// Find next Prefix up to characters excluding the suffix characters.
                    // Console.WriteLine("Inner iteration inside " + x);

                    // Console.WriteLine($"{pattern.Substring(x, suffixLength)} Compared with {tempSuffix}");
                    // Console.WriteLine("ooo, what's this " + pattern.Substring(x, suffixLength));
            
        
                    if(pattern.Substring(x , suffixLength) == tempSuffix){ // If Prefix matches Suffix and has a different Previous character
                        if(pattern[x - 0].ToString() != tempPrefix){
                            // Console.WriteLine($"Found matching Prefix, Our Suffix {tempSuffix} with preceeding {pattern[x - 1]} matched with {pattern.Substring(x, suffixLength)}");
                            // Console.WriteLine("This ran");
                            int prefixIndex = x - 1; // Index at which the inner prefix starts from
                        // Console.WriteLine($"Prefix : {pattern.Substring(x, suffixLength)} Is different to Suffix : {tempSuffix}.");
                        
                        
                        // Console.WriteLine($"Prefix of {pattern[x-1]} matches prefix of suffix {tempPrefix}");
                        
                        // Console.WriteLine($"Index at {x-1}");

                        goodSuffixTable[pLength - suffixLength] = (pLength - i - suffixLength);
                            
                        }
                    

                        
                        
                        
                    }

                    
                }
                
                
            
            }

            foreach(int element in goodSuffixTable){
                Console.WriteLine(element);
            }



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
            
            
            Console.WriteLine("-----------");
            foreach(var kvp in badMatchTable){
                Console.WriteLine(kvp);
            }
            Console.WriteLine("-----------");






            // For Debugging 
            // foreach(var entry in badMatchTable){ 
            //     Console.WriteLine(entry.Key + " : " + entry.Value);
            // }

            // More Efficient Search


            int index = pLength - 1; // Starting Index.
            int lastElement = pattern.Length - 1; // Last Element of pattern


            while(index < tLength){ // Iterate until index reaches tLength
                // Console.WriteLine(" --- Running Outer Iteration with index value " + index);
                
                Console.WriteLine("Comparing " + text[index] + " With " + pattern[lastElement] + " Text Index : " + index   );
                
                if(text[index] == pattern[lastElement]){ // If the right-most character matches with a character
                    Console.WriteLine("Match found ");
                    int l = lastElement;
                    int k = index;

                    while(l > 0){ // (When Right most character of pattern matches something on the text) Iterate till all characters are checked.

                        // Console.WriteLine("---- Inner Iteration");
                        // Console.WriteLine("Comparing " + text[k] + " with " + pattern[l]);
                        
                        if(text[k] != pattern[l]){ // If characters in pattern & text don't match.

                            // Console.WriteLine("No Match Found " + text[k]);

                            // Check from Bad Match Table how much to skip 
                           if(badMatchTable.ContainsKey(text[k].ToString())){ // Check if mismatched character in text exists on table 
                               index = index + badMatchTable[text[k].ToString()]; // Skip respective positions of character
                               break;
                           }else{
                            //   Console.WriteLine("Match Found " + text[k]);
                              index = index + badMatchTable["*"]; // Skip entire pattern length.
                              break;
                           }
                        }else{
                            l--;
                            k--;
                        }
                        if(l == 0){ // If the algorithm manages to match every character, It's a match.
                            Console.WriteLine("Match found at : " + (k) );
                            break;
                        }
                        index++;

                    }
                }else{
                    // Console.WriteLine(" --- No Outer Match");
                    if(badMatchTable.ContainsKey(text[index].ToString())){
                        // Console.WriteLine(" Word " + text[index] +  " is a key in dictionary, giving new value to index");
                        index = index + badMatchTable[text[index].ToString()];
                        Console.WriteLine(index);
                    }else{
                        // Console.WriteLine(" Word " + text[index] +  " is not a key in dictionary, giving new value to index");
                        index = index + badMatchTable["*"];
                        // Console.WriteLine(index);
  
                    }
                }
                
            }






















             






        }
    }



}