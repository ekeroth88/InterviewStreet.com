using System;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        // Create a list to put input in
        List<string> input = new List<string>();
        // Create a string for input
        string line;
        do {
            // Add all lines to a list
            line = Console.ReadLine();
                input.Add(line);
        } while (line != null);
        // Save the total amount of billboards
        int amountOfBillboards = int.Parse(input[0].Split(' ')[0]);
        // Save the total amount together
        int mostTogether = int.Parse(input[0].Split(' ')[1]);
        // Create an int array for all the boards
        int[] boards = new int[100000];
        // Set the lowest start int
        int lowestStart = 0;
        // Set the lowest start pos
        int lowestStartPos = 0;
        for (int i = 1; i <= amountOfBillboards; i++)
        {
            boards[i-1] = int.Parse(input[i]);
            //Console.WriteLine("Inserted " + input[i] + " into the array.");
        }
        // Set first to true
        bool first = true;
        if(amountOfBillboards > mostTogether)
        {
            for (int i = 0; i <= mostTogether; i++)
            {
                if(first)
                {
                    lowestStart = boards[i];
                    lowestStartPos = i;
                    first = false;
                }
                else if(boards[i] < lowestStart)
                {
                    lowestStart = boards[i];
                    lowestStartPos = i;
                }
                //Console.WriteLine("The lowest number right now is " + lowestStart + " on position " + lowestStartPos);
            }
        }
        int currentPosition = 0;
        int lastRemoved = 0;
        for (int i = 0; i < amountOfBillboards; i++)
        {
            if(currentPosition == lowestStartPos && amountOfBillboards != mostTogether)
            {
                //Console.WriteLine("Removed the lowest number " + boards[i] + " on position " + i);
                boards[i] = 0;
                lastRemoved = i;
            } else if(lastRemoved+mostTogether+1 == i && amountOfBillboards != mostTogether)
            {
                //Console.WriteLine("Removed the next in line which was " + boards[i] + " on position " + i);
                boards[i] = 0;
                lastRemoved = i;
            }
            currentPosition++;
        }
        long maxValue = 0;
        foreach(int boardValue in boards)
        {
            //Console.WriteLine(boardValue);
            maxValue += boardValue;
        }
        Console.WriteLine(maxValue);
    }
}