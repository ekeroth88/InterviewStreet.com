/*
 Enter your code here. Read input from STDIN. Print output to STDOUT
 Your class should be named Solution
*/
using System;

namespace StringReduction
{
    public static class Solution
    {
        static int FindLongestPart(string line, char c, out int i, out int j)
        {
            var leni = 0;
            var lenj = 0;
            var lel = 0;
            var len = 0;
            i = 0;
            j = 0;
            
            foreach(var li in line)
            {
                if (li == c)
                {
                    ++lenj;
                }
                else
                {
                    lel = lenj - leni;
                    if (lel > len)
                    {
                        len = lel;
                        i = leni;
                        j = lenj;
                    }
                    ++lenj;
                    leni = lenj;
                }
            }

            lel = lenj - leni;
            if (lel > len)
            {
                len = lel;
                i = leni;
                j = lenj;
            }
            
            --j;

            return len;
        }

        static char ReplaceWithChar(char c1, char c2)
        {
            var a = 'a';
            var b = 'b';
            var c = 'c';
            
            if (c1 == a && c2 == b || c1 == b && c2 == a)
                return c;
            if (c1 == a && c2 == c || c1 == c && c2 == a)
                return b;
            if (c1 == b && c2 == c || c1 == c && c2 == b)
                return a;
            
            return 'x';
        }
        
        static bool IsOnlyOneChar(string line)
        {
            var c = line[0];
            foreach(var lin in line)
                if (lin != c)
                    return false;
            return true;
        }
        
        static string RewriteWithOneReplace(string line, int i, int j)
        {
            var returns = string.Empty;
            returns += line.Substring(0, i);
            returns += ReplaceWithChar(line[i], line[j]);
            returns += line.Substring(j + 1, line.Length - j - 1);
            return returns;
        }
        
        static string RewriteWithReplace(string line, int i, int j)
        {
            if (IsOnlyOneChar(line))
                return line;
            
            var m = line.Length - 1;
            var b0 = i == j;
            var b1 = i > 0;            
            var b2 = j < line.Length - 1;

            if (b0)
            {
                if (i == 0)
                {
                    return RewriteWithOneReplace(line, i, i + 1);
                }
                if (i == 1)
                {
                    return RewriteWithOneReplace(line, i - 1, i);
                }                
                else if (j == m)
                {
                    return RewriteWithOneReplace(line, j - 1, j);
                }
                else if (j == m - 1)
                {
                    return RewriteWithOneReplace(line, j, j + 1);
                }                
                else if (b1)
                {
                    return RewriteWithOneReplace(line, i - 1, i);
                }
                else if (b2)
                {
                    return RewriteWithOneReplace(line, j, j + 1);
                }
            }

            if (b1)
            {
                return RewriteWithOneReplace(line, i - 1, i);
            }
            
            if (b2)
            {
                return RewriteWithOneReplace(line, j, j + 1);
            }
                
            return line;
        }
        
        static string Transform(string line)
        {
            if (line.Length == 0)
                return string.Empty;

            var a = 'a';
            var b = 'b';
            var c = 'c';

            var lenAi = 0;
            var lenAj = 0;
            var lenA = FindLongestPart(line, a, out lenAi, out lenAj);
            var lenBi = 0;
            var lenBj = 0;
            var lenB = FindLongestPart(line, b, out lenBi, out lenBj);
            var lenCi = 0;
            var lenCj = 0;
            var lenC = FindLongestPart(line, c, out lenCi, out lenCj);
            
            if (lenA >= lenB && lenB >= lenC)
                return RewriteWithReplace(line, lenAi, lenAj);
            if (lenA >= lenC && lenC >= lenB)
                return RewriteWithReplace(line, lenAi, lenAj);
            if (lenB >= lenC && lenC >= lenA)
                return RewriteWithReplace(line, lenBi, lenBj);
            if (lenB >= lenA && lenA >= lenC)
                return RewriteWithReplace(line, lenBi, lenBj);
            if (lenC >= lenB && lenB >= lenA)
                return RewriteWithReplace(line, lenCi, lenCj);
            if (lenC >= lenA && lenA >= lenB)
                return RewriteWithReplace(line, lenCi, lenCj);
            
            return line;
        }
        
        public static void Main()        
        {            
            var n = int.Parse(Console.ReadLine());

            while (n > 0)
            {
                var s = Console.ReadLine();
                var m = s.Length;
                var l = m;
                
                ++m;
                
                while (l < m)
                {
                    m = l;
                    s = Transform(s);
                    l = s.Length;
                }
                
                --n;
                
                Console.WriteLine(l);
            }
        }
    }
}