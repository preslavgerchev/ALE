﻿namespace ALEConsole
{
    using System;
    using PropositionLogic;

    class Program
    {
        static void Main(string[] args)
        {
            var properOutput = "|(~(D),&(>(A,B),~(C)))";
            var nodes = TreeCreator.Initialize(properOutput);
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
