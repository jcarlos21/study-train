﻿using System;

namespace URI_1073
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            for (int i = 1; i <= N; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine($"{i}^2 = {Math.Pow(i, 2)}");
                }
            }
        }
    }
}
