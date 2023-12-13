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


            int index = pLength - 1;
            int lastElement = pattern.Length - 1;


            while(index < tLength){
                // Console.WriteLine(" --- Running Outer Iteration with index value " + index);
                
                // Console.WriteLine("Comparing " + text[index] + " With " + pattern[lastElement] + " Text Index : " + index   );
                
                if(text[index] == pattern[lastElement]){
                    // Console.WriteLine("Match found ");
                    int l = lastElement;
                    int k = index;

                    while(l > 0){
                        // Console.WriteLine("---- Inner Iteration");
                        // Console.WriteLine("Comparing " + text[k] + " with " + pattern[l]);
                        
                        if(text[k] != pattern[l]){
                            // Console.WriteLine("No Match Found " + text[k]);
                           if(badMatchTable.ContainsKey(text[k].ToString())){
                               index = index + badMatchTable[text[k].ToString()];
                               
                               break;
                           }else{
                            //   Console.WriteLine("Match Found " + text[k]);
                              index = index + badMatchTable["*"];
                              
                              break;
                           }
                        }else{
                            l--;
                            k--;
                        }
                        if(l == 0){
                            Console.WriteLine("Match found at : " + (index - (pLength - 1)) );
                            index++;
                        }

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