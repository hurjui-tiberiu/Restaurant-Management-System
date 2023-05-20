using System;
using System.Collections.Generic;
using System.Linq;

public class Prgoram
{
    public static void Main()
    {
        var lines = System.IO.File.ReadAllLines("in.txt");

        var a = lines[1].Split(' ').Select(int.Parse).ToArray();
        var b = lines[3].Split(' ').Select(int.Parse).ToArray();


        TiparesteLCS(a, b, LCS(a, b));

        Console.Read();


    }

   
    public static int[,] LCS(int[] a, int[]b)
    {
        var n = a.Length;
        var m = b.Length;
        var lung = new int[n, m];

        lung[0, 0] = (a[0] == b[0]) ? 1 : 0;

        for (int j = 1; j < m; j++)
            lung[0, j] = (a[0] == b[j]) ? 1 : lung[0, j - 1];

        for (int i = 1; i < n; i++)
            lung[i, 0] = (a[i] == b[0]) ? 1 : lung[i - 1, 0];

        for (int i = 1; i < n;i++)
            for (int j = 1; j < m; j++)
                lung[i, j] = Math.Max((a[i] == b[j]) ? lung[i - 1, j - 1] + 1 : lung[i - 1, j - 1], Math.Max(lung[i - 1, j], lung[i, j - 1]));

        return lung;
    }


    public static void TiparesteLCS(int[] a, int[] b, int[,]lung)
    {
        var i = a.Length - 1;
        var j = b.Length - 1;

        var secventa = new List<int>();

        while(i>=0 && j>=0)
        {
            if (a[i] == b[j])
            {
                secventa.Add(a[i]);
                i--;
                j--;
            }
            else if (i >= 1 && lung[i - 1, j] == lung[i, j])
                i--;
            else if (j >= 1 && lung[i, j - 1] == lung[i, j])
                j--;
        }

        secventa.Reverse();
        Console.Write(string.Join(" ", secventa));
    }

}
