using System;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            IntCodeProgram program = new IntCodeProgram("./DayTwoInput.txt");
            program[1] = 12;
            program[2] = 2;
            program.Run();
            Console.WriteLine($"Program halted with error : {program.Errored}");
            Console.WriteLine($"Program value at position 0: {program[0]}");
        }
    }
}
