using System;

namespace curriculum_2_13
{
    class Program
    {
        enum DayOfWeek
        {
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday
        }
        static void Main(string[] args)
        {
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                Console.WriteLine(day);
            }
        }
    }
}