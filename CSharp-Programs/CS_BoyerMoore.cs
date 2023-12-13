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

            // More Efficient Search


            int index = pLength - 1;
            int lastElement = pattern.Length - 1;


            while(index < tLength){
                // Console.WriteLine(" --- Running Outer Iteration with index value " + index);
                
                // Console.WriteLine("Comparing " + text[index] + " With " + pattern[lastElement]);
                
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
                               index = index + badMatchTable["*"];
                               break;
                           }else{
                            // Console.WriteLine("Match Found " + text[k]);
                              index = index + badMatchTable[text[k].ToString()];
                              break;
                           }
                        }else{
                            l--;
                            k--;
                        }
                        if(l == 0){
                            Console.WriteLine("Match found at : " + (index - (pLength - 1)));
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
                        Console.WriteLine(index);
  
                    }
                }
            }



















            // int pIndex = pLength - 1; // Start at index equal to last element of pattern 
            // int index = pLength - 1; // Start in long text at the nth element of pattern.
             

            // while(index < tLength){
            //     string tempString = text.Substring((index - pIndex), (index));
                
            //     Console.WriteLine("Your string " + tempString);

            
            //     for(int i = 0; i < pLength ; i++){
            //         Console.WriteLine("Iteration " + i);
            //         Console.WriteLine(" current Char Index : " + (index - 1 ) + " current Pattern Char Index " + (pIndex - i));
            //         string curChar = tempString[index + i].ToString();
            //         Console.WriteLine("Iteration First: " + curChar);
            //         string curPatChar = pattern[pIndex - i].ToString();
            //         Console.WriteLine("Iteration Second : " + curPatChar);


            //        if(curChar != curPatChar){
            //           if(badMatchTable.ContainsKey(curChar)){
            //              index = index + badMatchTable[curChar];
            //           }else{
            //              index = index + badMatchTable["*"];
            //           }
            //        }else if (i == pLength - 1){
                       
            //        }
            //     }
            // }




             







            // Requires Fixing for actual Boyer-Moore comparison.
            // int iter = pLength - 1;
            // int patIndex = pLength - 1;

            // while(iter <= tLength - 1){
            //     Console.WriteLine("Comparing : " + text[iter] + " with " + pattern[patIndex] + " At index " + iter);


            //     if(text[iter] == pattern[patIndex]){
            //            Console.WriteLine("Match Found, Entering For Loop Iteration");
            //            int a = iter;

            //            for(int k = 0 ; k < patIndex; k++){
            //              Console.WriteLine("Comparing : " + text[a - k] + " with " + pattern[patIndex - k] + " At index " + (a - k));

            //              if(text[a - k] != pattern[patIndex - k]){
            //                 Console.WriteLine("No Match");

            //                 if(badMatchTable.ContainsKey(text[a-k].ToString())){
                                
            //                     iter = iter + badMatchTable[text[a-k].ToString()];
            //                 }else{
            //                     iter = iter + badMatchTable["*"];
            //                 }
            //                 break;
            //              }else{

            //              }

            //              if(a == 0){
            //                 Console.WriteLine("Match found at index " + iter);
            //                 iter++;
            //                 break;
            //              }
            //            }
            //     }else{
            //         Console.WriteLine("No Match Found");
            //         if(badMatchTable.ContainsKey(text[iter].ToString())){
            //             Console.WriteLine("Key is not in dictionary");
            //             iter = iter + badMatchTable["*"];
            //             Console.WriteLine("This ran well");
            //             Console.WriteLine("New Value of Iter " + iter);
            //         }else{
            //             Console.WriteLine("Key is in dictionary");
            //             iter = iter + badMatchTable[text[patIndex].ToString()];
            //             Console.WriteLine("This ran well");
            //             Console.WriteLine("New Value of Iter " + iter);
            //         }
            //     }
            // }







        }
    }



}