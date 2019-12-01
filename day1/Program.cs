using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Day1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Starting fuel calculations");
            var masses = (await File.ReadAllLinesAsync("DayOneInput.txt")).Select(s=>int.TryParse(s,out int i) ? i : 0);
            int total_fuel = 0;
            foreach(int mass in masses)
            {
                total_fuel += (int)Math.Floor(mass / 3.0) - 2;
            }
            Console.WriteLine($"Total Fuel Needed:{total_fuel}");
        }
    }
}
