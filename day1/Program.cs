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
            var masses = (await File.ReadAllLinesAsync("DayOneInput.txt")).Select(s=>int.TryParse(s,out int i) ? i : 0).ToList();
            long total_fuel = 0;
            for(int ctr=0; ctr<masses.Count(); ctr++)
            {
                int change_in_fuel = (int)Math.Floor(masses[ctr] / 3.0) - 2;
                if(change_in_fuel>0)
                {
                    masses.Add(change_in_fuel);
                    total_fuel += change_in_fuel;
                }
            }
            Console.WriteLine($"Total Fuel Needed :{total_fuel}");

        }
    }
}
