using System;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        // Create an empty list
        List<string> input = new List<string>();
        // Create a string called line
        string line;
        // Add values to the list until line = null
        do {
            // Set line to the current STDIN line
            line = Console.ReadLine();
                // Add that while to the list
                input.Add(line);
        } while (line != null);
        int testCases = int.Parse(input[0]);
        
        for(int i = 1; i <= testCases; i++)
        {
            string testString = input[i];
            solve(testString);
        }
    }
    
    public static void solve(string testString)
    {
        string str = testString;
        int len = testString.Length;
        int count = 0;
        int total = 0;
        for(int i = 1;i<len;i++)
        {
            count = 0;
            for(int j=i;j<len;j++)
            {
                if(str[j-i]==str[j])
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            total = total+count;
        }
        Console.WriteLine(total+len);
    }
}