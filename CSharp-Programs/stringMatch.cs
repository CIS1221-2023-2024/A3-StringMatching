using System;
using System.Diagnostics;
using System.Collections.Generic;



namespace MainProgram{
    class Program{

        static void Main(string[] args){
            string mainText = "";
            string pattern = "";

            mainText = Console.ReadLine();
            pattern = Console.ReadLine();

            StringMatch(mainText, pattern);


        }

        static void StringMatch(string text, string pattern){
            int patternLength = pattern.Length;
            int textLength = text.Length;
          

            for(int i = 0; i < textLength; i++){
                if(text[i] == pattern[0]){
                    int count = 0;
                    while (count < patternLength){
                        if(text[i + count] == pattern[count]){
                         count++;
                             if(count == patternLength){
                                 Console.WriteLine("Pattern Found at Index: " + i);
                             }
                        }else{
                          break;
                        }
                    }
                }
            }
        }

    }
}