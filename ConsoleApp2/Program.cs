using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string x =ReplaceAdjacentDuplicateLetters("wworlld");
            Console.WriteLine(x);
            Console.WriteLine(ReplacePi("pi"));
            string f = AutoCorrectText("I donn’t knoow pii value, so I will go eat my ppiie…");
            Console.WriteLine(f);
            //List<int> e = new List<int>() { 1,2,3,4,5,6,7,8,9,10};
            List<int> e = new List<int>() { 2,3,4,5,6,7,8,9,10,11,12,13,14};
            List<int> h = RemoveNumbers(e);
        }
        // Task 1
        static string ReplaceAdjacentDuplicateLetters(string word)
        {
            char[] letters = word.ToCharArray();
            string Corrected = "";
            for (int i = 0; i < word.Length; i++)
            {
                if (word.Length == 1)
                {
                    return word;
                }
                if (i+1 == word.Length && letters[i].Equals(letters[i-1]) == false)
                {
                    Corrected += letters[i];
                }
                else if (letters[i].Equals(letters[i+1]))
                {
                    Corrected += letters[i];
                    i += 1;
                }
                else
                {
                    Corrected += letters[i];
                }
            }
            return Corrected;
        }

        static string ReplacePi(string word)
        {
            string corrected = Regex.Replace(word, @"\b(pi)\b", "3.14");

            return corrected;
        }

        static string AutoCorrectText(string input)
        {
            string[] words = input.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = ReplaceAdjacentDuplicateLetters(words[i]);
                words[i] = ReplacePi(words[i]);
            }
            string corrected = string.Join(" ",words);
            return corrected;
        }

        // Task 2

        static bool isEven(int number)
        {
            return (number % 2) == 0;
        }

        static List<int> RemoveNumbers(List<int> integers)
        {
            List<int> temp = new List<int>();
            if (isEven(integers[0]))
            {
                for (int i = 0; i < integers.Count; i++)
                {
                        temp.Add(integers[i]);
                        i += 1;
                }
            }
            else if (isEven(integers[0]) == false)
            {
                for (int i = 0; i < integers.Count; i++)
                {
                        temp.Add(integers[i]);
                    i += 1;
                }
            }
            RemoveEveryXNumbers(temp);

            return temp;
        }

        static List<int> RemoveEveryXNumbers(List<int> integers)
        {
            int step = integers[1];
            for (int i = 2; i < integers.Count; i++)
            {
                if (i > integers.Count)
                {
                    break;
                }
                else
                {
                    integers.RemoveAt(i);
                    i += step-1;
                }
            }

            return integers;
        }
    }
}
