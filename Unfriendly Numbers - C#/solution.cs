/*
 Enter your code here. Read input from STDIN. Print output to STDOUT
 Your class should be named Solution
*/
using System;
using System.Collections.Generic;

namespace UnfriendlyNumbers
{
  public class Solution
  {

    public static void Main()
    {
        List<string> input = new List<string>();
        string line;
        do {
            line = Console.ReadLine();
                input.Add(line);
        } while (line != null);
        
        string[] firstLine = input[0].Split(' ');
        
        long unfriendlyNumberCount = long.Parse(firstLine[0]);
        long numberToDivide = long.Parse(firstLine[1]);
        string[] unfriendlyNumbers = new string[unfriendlyNumberCount];
        unfriendlyNumbers = input[1].Split(' ');
        long unfriendlyDivisors = 0;
        
        List<long> divisorsFound = properDivisors(numberToDivide);
        

        foreach(string unfriendlyNumber in unfriendlyNumbers)
        {
            foreach(long divisor in divisorsFound)
            {
                if(long.Parse(unfriendlyNumber) == divisor)
                {
                    unfriendlyDivisors++;
                } 
            }
        }

        
        Console.WriteLine(divisorsFound.Count-1-unfriendlyDivisors);
    }
      
    public static List<long> properDivisors(long x)
    {
        List<long> toreturn = new List<long>();
        for (int i = 1; i <= Math.Floor(Math.Sqrt(x)); i++)
        {
            if (x % i == 0)
            {
                toreturn.Add(i);
                toreturn.Add(x / i);
            }
        }
        return toreturn;
    }
      
  }
}
