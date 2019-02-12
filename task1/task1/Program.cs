using System;
using System.Globalization;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            String str = Console.ReadLine();
            DateTime date = new DateTime();
            DateTime.TryParse(str, out date);
            var month = date.Month;
            var year = date.Year;
            var startDay = new DateTime(year, month, 1);
            
            var endDay = startDay.AddMonths(1);

            DateTime stuff = new DateTime(2019, 2, 4);
            DateTime stuffEnd = stuff.AddDays(7);
            for (var curDay = stuff; stuff != stuffEnd; stuff.AddDays(1))
            {
                
            }

            var culture = new CultureInfo("ru-RU");
            var monday = culture.DateTimeFormat.GetDayName(DayOfWeek.Monday);
            var tuesday = culture.DateTimeFormat.GetDayName(DayOfWeek.Tuesday);
            var wednesday = culture.DateTimeFormat.GetDayName(DayOfWeek.Wednesday);
            var thursday = culture.DateTimeFormat.GetDayName(DayOfWeek.Thursday);
            var friday = culture.DateTimeFormat.GetDayName(DayOfWeek.Friday);
            var saturday = culture.DateTimeFormat.GetDayName(DayOfWeek.Saturday);
            var sunday = culture.DateTimeFormat.GetDayName(DayOfWeek.Sunday);

            for (var curDate = startDay; curDate != endDay; curDate = curDate.AddDays(1))
            {
                Console.WriteLine($"Number: {curDate.Day}, day of week: {curDate.DayOfWeek}");
                if (curDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    Console.WriteLine(Environment.NewLine);
                }
            }
            
            Console.ReadLine();
        }
    }
}
