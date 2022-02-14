/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace ISM6225_Assignment_2_Spring_2022
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 2, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most frequent word is {0}:", commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 3, 4 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1122";
            string guess = "2211";
            string hint = GetHint(secret, guess);
            Console.WriteLine("Hint for the guess is :{0}", hint);
            Console.WriteLine();


            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "abcdefghijklmnopqrstuvwxyz";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "()[]{}";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            Console.WriteLine("Question 9");
            int[,] grid = { { 0, 1, 2, 3, 4 }, { 24, 23, 22, 21, 5 }, { 12, 13, 14, 15, 16 }, { 11, 17, 18, 19, 20 }, { 10, 9, 8, 7, 6 } };
            int time = SwimInWater(grid);
            Console.WriteLine("Minimum time required is: {0}", time);
            Console.WriteLine();

            //Question 10:
            Console.WriteLine("Question 10");
            string word1 = "horse";
            string word2 = "ros";
            int minLen = MinDistance(word1, word2);
            Console.WriteLine("Minimum number of operations required are {0}", minLen);
            Console.WriteLine();
        }


        /*
        
        Question 1:
        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search
        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2
        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1
        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4
        */

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                /*
                 * Firstly we will take the mid value of the array and check if the target value is less than or greater than the mid value.
                 * If the target value is greater than mid value that means we need to take second half of the array for comparison
                 *              So, we will assign answer as first index of new array that is mid+1 and since we need new mis value will change the min value to mid+1
                 * Else if the target value is less than target value it means we need to take first half of the existing array.
                 *              so, We will assign the max value to mid-1 and answer to mid to calculate the new mid value of the array.
                 * We will Contiue the process till we get the index location of the target and loop will stop once our min will be grater than max value.
                 */
                int min = 0, max = nums.Length - 1, mid, ans = 0;
                // Declaring the values min value to 0 and max value to last index location. 
                while (min <= max)
                {
                    mid = min + (max - min) / 2; 
                    if (nums[mid] < target)
                    {
                        min = mid + 1; // changing the minimum value so that we can ignore first half of the array
                        ans = mid + 1;
                    }
                    else if (nums[mid] >= target)
                    {
                        ans = mid;
                        max = mid - 1; // changing the maximum value so that we can ignore second half of the array.
                    }
                }

                return (ans);
                 
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         
        Question 2
       
        Given a string paragraph and a string array of the banned words banned, return the most frequent word that is not banned. It is guaranteed there is at least one word that is not banned, and that the answer is unique.
        The words in paragraph are case-insensitive and the answer should be returned in lowercase.

        Example 1:
        Input: paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.", banned = ["hit"]
        Output: "ball"
        Explanation: "hit" occurs 3 times, but it is a banned word. "ball" occurs twice (and no other word does), so it is the most frequent non-banned word in the paragraph. 
        Note that words in the paragraph are not case sensitive, that punctuation is ignored (even if adjacent to words, such as "ball,"), and that "hit" isn't the answer even though it occurs more because it is banned.

        Example 2:
        Input: paragraph = "a.", banned = []
        Output: "a"
        */

        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {
                string s = paragraph;
                s = s.ToLower();  //Converting the paragraph to lower case.
                /*
                 * Creating a for loop to replace all banned word with empty string
                 */
                for (int y = 0; y < banned.Length; y++)
                {
                    s = s.Replace(banned[y], ""); 
                }
                string[] d = s.Split(new char[] { ' ', '!', ',', ':', ';', '?', '.', '\'' });//spliting the string based on the special character as per constraints
                int i = 0;
                int[] f = new int[s.Length]; // declaring an integer array to store frequency of all words
                int j = 0;
                string[] unique = d.Distinct().ToArray();//storing only unique words
                string[] v = new string[unique.Length]; // creating string array to store the words for which frequency is counted.

                /*
                 * In the below we compared each unique word which is not equal to empty string with all words array.
                 * If word is equal to the unique words then we will increase the count in the frequency array and at same index location we will also store the word at another string array.
                 */
                foreach (string u in unique)
                {
                    if (u != "")
                    {
                        for (j = 0; j < d.Length; j++)
                        {
                            if (d[j] == u)
                            {
                                f[i] = f[i] + 1;

                            }
                        }
                        v[i] = u;
                        i = i + 1;
                    }
                }
                return (v[f.ToList().IndexOf(f.Max())]); 
                /*
                 * First we will check the most frequent value in the frequency array
                 * then we will check the index location of that value
                 * Then we return the string of that index location from the string array where we stored all words.
                 */

                 
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
        Question 3:
        Given an array of integers arr, a lucky integer is an integer that has a frequency in the array equal to its value.
        Return the largest lucky integer in the array. If there is no lucky integer return -1.
 
        Example 1:
        Input: arr = [2,2,3,4]
        Output: 2
        Explanation: The only lucky number in the array is 2 because frequency[2] == 2.

        Example 2:
        Input: arr = [1,2,2,3,3,3]
        Output: 3
        Explanation: 1, 2 and 3 are all lucky numbers, return the largest of them.

        Example 3:
        Input: arr = [2,2,2,3,3]
        Output: -1
        Explanation: There are no lucky numbers in the array.
         */

        public static int FindLucky(int[] arr)
        {
            try
            {
                int[] dist = arr.Distinct().ToArray(); // getting distinct array elements.
                int[] v = new int[dist.Length]; // Declaring array to store all lucky numbers.
                int[] m = new int[501]; // dummy array using whose index values we will get the frequency of all distinct elements of the array.
                for (int i = 0; i < arr.Length; i++)
                    m[arr[i]] = m[arr[i]] + 1; // Increasing the value by 1 in the index location of the array element.In this way we will storing the frequency of all distince numbers.
                for (int i = 0; i < dist.Length; i++)
                {
                    if (dist[i] == m[dist[i]]) // verifing whether the frequency at index location of the frequency array is equal to the number. 
                    {
                        v[i] = dist[i]; // if condition statisfies storing the array of lucky integers
                    }
                }
                if (v.Max() > 0) // if max value in lucky array is greater than 0 then it means there is a lucky integer.
                    return(v.Max());
                else // if max value is 0 that means there were no lucky ingteger hence returning 0.
                    return(-1);
            }
            catch (Exception)
            {

                throw;
            }

        }

        /*
        
        Question 4:
        You are playing the Bulls and Cows game with your friend.
        You write down a secret number and ask your friend to guess what the number is. When your friend makes a guess, you provide a hint with the following info:
        •	The number of "bulls", which are digits in the guess that are in the correct position.
        •	The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position. Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
        Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.
        The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows. Note that both secret and guess may contain duplicate digits.
 
        Example 1:
        Input: secret = "1807", guess = "7810"
        Output: "1A3B"
        Explanation: Bulls relate to a '|' and cows are underlined:
        "1807"
          |
        "7810"

        */

        public static string GetHint(string secret, string guess)
        {
            try
            {
                char[] s = secret.ToCharArray(); // Converting String to array elements
                char[] g = guess.ToCharArray(); // Converting String to array elements
                int a = 0; // Declaring the count of bulls to 0. 
                int count = 0; // Declaring the count of cow to 0.
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == g[i]) // Checking the letter of same index of secert and guess as same.
                    {
                        a += 1; // if the at same index location character of both arrays are same. Increasing the count.
                        g[i] = ' '; // Changing the element to empty character so that next time it will not be Compared.
                        s[i] = ' '; // Changing the element to empty character so that next time it will not be Compared.
                    }

                }
                for (int i = 0; i < s.Length; i++)
                {
                    for (int j = 0; j < g.Length; j++)
                    {
                        /*
                         * Checking the condition of whether any other avaliable character other than space.
                         * if the there is any character in guess which is equal to secert letter than increasing the count for cows.
                         */
                        if (s[i] == g[j] && s[i] != ' ' && g[j] != ' ')  
                        {
                            s[i] = ' ';
                            g[j] = ' ';
                            count += 1;
                        }
                    }
                }
                string ans = Convert.ToString(a) + "A" + count + "B"; //Converting the count elements to string and returning the value.
                return(ans);
                
            }
            catch (Exception)
            {

                throw;
            }
        }


        /*
        Question 5:
        You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part.
        Return a list of integers representing the size of these parts.

        Example 1:
        Input: s = "ababcbacadefegdehijhklij"
        Output: [9,7,8]
        Explanation:
        The partition is "ababcbaca", "defegde", "hijhklij".
        This is a partition so that each letter appears in at most one part.
        A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits s into less parts.

        */

        public static List<int> PartitionLabels(string s)
        {
            try
            {
                var result = new List<int>(); // declaring the var to store lengths of the string
                int j = 0; // Variable to index+1 location of end of parition string
                int last = 0;// to Store last index location of the character in the string.

                for (int i = 0; i < s.Length; i++)
                {
                    last = Math.Max(last, s.LastIndexOf(s[i])); // checking max value of last index of the present character to the previous character

                    if (last == i) // if the present last index of the character is equal to the index location of the character
                                    // that means it is not avaliable further in the string and we need to split the string at this location
                    {
                        result.Add(i - j + 1); // adding the string length of the parition string in the results.
                        // value of the string will be calcuated as index location +1 - previous parition location.
                        j = i + 1; // index +1 showing that we parition that string till that point.
                    }
                }


                return (result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 6

        You are given a string s of lowercase English letters and an array widths denoting how many pixels wide each lowercase English letter is. Specifically, widths[0] is the width of 'a', widths[1] is the width of 'b', and so on.
        You are trying to write s across several lines, where each line is no longer than 100 pixels. Starting at the beginning of s, write as many letters on the first line such that the total width does not exceed 100 pixels. Then, from where you stopped in s, continue writing as many letters as you can on the second line. Continue this process until you have written all of s.
        Return an array result of length 2 where:
             •	result[0] is the total number of lines.
             •	result[1] is the width of the last line in pixels.
 
        Example 1:
        Input: widths = [10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], s = "abcdefghijklmnopqrstuvwxyz"
        Output: [3,60]
        Explanation: You can write s as follows:
                     abcdefghij  	 // 100 pixels wide
                     klmnopqrst  	 // 100 pixels wide
                     uvwxyz      	 // 60 pixels wide
                     There are a total of 3 lines, and the last line is 60 pixels wide.



         Example 2:
         Input: widths = [4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], 
         s = "bbbcccdddaaa"
         Output: [2,4]
         Explanation: You can write s as follows:
                      bbbcccdddaa  	  // 98 pixels wide
                      a           	 // 4 pixels wide
                      There are a total of 2 lines, and the last line is 4 pixels wide.

         */

        public static List<int> NumberOfLines(int[] widths, string s)
        {
            try
            {
                string al = "abcdefghijklmnopqrstuvwxyz"; // string which stores all alphabets.
                int line = 1; // line is 1 since already 1 line is there by default.
                int sum = 0; // declaring sum varaiable to count sum of pixels
                for (int i = 0; i < s.Length; i++)
                {
                    if (sum + widths[al.IndexOf(s[i])] <= 100) // if upcoming sum is less or equal to 100 then we add the pixel value to the sum.
                    {
                        sum = sum + widths[al.IndexOf(s[i])];
                    }
                    else // this means the new sum will be grater than 100 hence we need to start new line.
                    {
                        line = line + 1;
                        sum = widths[al.IndexOf(s[i])]; // since loop will now once again calcualte the ith pixel location assigning that value to sum.

                    }
                }
                return new List<int>() {line,sum };
            }
            catch (Exception)
            {
                throw;
            }

        }


        /*
        
        Question 7:

        Given a string bulls_string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        An input string is valid if:
            1.	Open brackets must be closed by the same type of brackets.
            2.	Open brackets must be closed in the correct order.
 
        Example 1:
        Input: bulls_string = "()"
        Output: true

        Example 2:
        Input: bulls_string  = "()[]{}"
        Output: true

        Example 3:
        Input: bulls_string  = "(]"
        Output: false

        */

        public static bool IsValid(string bulls_string10)
        {
            try
            {
                bool flag = true; // declaring the bool variable for string continuity.
                int count;
                string bulls_string = bulls_string10;
                while (flag)
                {
                    count = 0;// initizing count to 0.
                    if (bulls_string.Contains("()")) // if string conatins () then we will replace all () with empty string
                    {
                        bulls_string = bulls_string.Replace("()", "");
                    }
                    else
                        count = count + 1; // if string doesn't conating any () then increase the count by the value 1. 
                    if (bulls_string.Contains("[]") && bulls_string != "") //if string conatins [] then we will replace all [] with empty string
                    {
                        
                        bulls_string = bulls_string.Replace("[]", "");
                    }
                    else
                        count += 1; // if string doesn't conating any [] then increase the count by the value 1. 
                        if (bulls_string.Contains("{}") && bulls_string != "") //if string conatins {} then we will replace all {} with empty string
                    {
                        bulls_string = bulls_string.Replace("{}", "");
                    }
                    else count += 1; // if string doesn't conating any {} then increase the count by the value 1. 

                    if (count == 3) // if count is 3 it means that string doesn't contains any brackets and we can end the loop.
                    {
                        flag = false;
                    }
                }
                if (bulls_string == "") // if string is empty it means that all there are all valid brackets and the string is valid string.
                    return(true);
                else
                    return false; // if string is not empty it means that there non pair brackets and string is not valid.
            }
            catch (Exception)
            {
                throw;
            }


        }



        /*
         Question 8
        International Morse Code defines a standard encoding where each letter is mapped to a series of dots and dashes, as follows:
        •	'a' maps to ".-",
        •	'b' maps to "-...",
        •	'c' maps to "-.-.", and so on.

        For convenience, the full table for the 26 letters of the English alphabet is given below:
        [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]
        Given an array of strings words where each word can be written as a concatenation of the Morse code of each letter.
            •	For example, "cab" can be written as "-.-..--...", which is the concatenation of "-.-.", ".-", and "-...". We will call such a concatenation the transformation of a word.
        Return the number of different transformations among all words we have.
 
        Example 1:
        Input: words = ["gin","zen","gig","msg"]
        Output: 2
        Explanation: The transformation of each word is:
        "gin" -> "--...-."
        "zen" -> "--...-."
        "gig" -> "--...--."
        "msg" -> "--...--."
        There are 2 different transformations: "--...-." and "--...--.".

        */

        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {
                string al = "abcdefghijklmnopqrstuvwxyz"; // alphabets to get index location
                string[] m = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
                string[] t = new string[words.Length];
                for (int i = 0; i < words.Length; i++)
                {
                    for (int j = 0; j < words[i].Length; j++) // double for loop to get each character of each string of string array
                    {
                        /*
                         * we can morse of particular chracter by getting the index value of that character from al string and using that in morse code array
                         */
                        t[i] = t[i] + m[al.IndexOf(words[i][j])];  // concatinating the string to previous charcter morse cose

                    }
                }
                string[] d = t.Distinct().ToArray(); // getting distinct elements in array since we need only unique length.
                return (d.Length); 
            }
            catch (Exception)
            {
                throw;
            }

        }




        /*
        
        Question 9:
        You are given an n x n integer matrix grid where each value grid[i][j] represents the elevation at that point (i, j).
        The rain starts to fall. At time t, the depth of the water everywhere is t. You can swim from a square to another 4-directionally adjacent square if and only if the elevation of both squares individually are at most t. You can swim infinite distances in zero time. Of course, you must stay within the boundaries of the grid during your swim.
        Return the least time until you can reach the bottom right square (n - 1, n - 1) if you start at the top left square (0, 0).

        Example 1:
        Input: grid = [[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]
        Output: 16
        Explanation: The final route is shown.
        We need to wait until time 16 so that (0, 0) and (4, 4) are connected.

        */

        public static int SwimInWater(int[,] grid)
        {
            try
            {
                //write your code here.
                return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
         
        Question 10:
        Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.
        You have the following three operations permitted on a word:

        •	Insert a character
        •	Delete a character
        •	Replace a character
         Note: Try to come up with a solution that has polynomial runtime, then try to optimize it to quadratic runtime.

        Example 1:
        Input: word1 = "horse", word2 = "ros"
        Output: 3
        Explanation: 
        horse -> rorse (replace 'h' with 'r')
        rorse -> rose (remove 'r')
        rose -> ros (remove 'e')

        */

        public static int MinDistance(string word1, string word2)
        {
            try
            {
                //write your code here.
                return 0;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}