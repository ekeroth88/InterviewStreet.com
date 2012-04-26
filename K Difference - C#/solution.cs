using System;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        List<string> input = new List<string>();
        string line;
        do {
            line = Console.ReadLine();
                input.Add(line);
        } while (line != null);
        int totalNumbers = int.Parse(input[0].Split(' ')[0]);
        int diff = int.Parse(input[0].Split(' ')[1]);
        string[] numArr = input[1].Split(' ');
        
        int count = 0;
        Array.Sort(numArr);
        for (int i = totalNumbers - 1; i >= 0; i--) {
            for (int j = i - 1; j >= 0; j--) {
                int pairDiff = int.Parse(numArr[i]) - int.Parse(numArr[j]);
                if(pairDiff > diff)
                {
                    break;
                }
                if (pairDiff == diff) {
                    count++;
                }
            }
        }
        Console.WriteLine(count);
    }
}