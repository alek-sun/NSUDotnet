using System;
using System.Globalization;
using System.Collections;

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

            Console.WriteLine(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month) + " " + year);
           

            var startDay = new DateTime(year, month, 1);
            
            var endDay = startDay.AddMonths(1);

            string[] names = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedDayNames;

            for (int i = 1; i <= 6; ++i)
            {                
                Console.Write($"{names[i]}\t");
            }
            Console.WriteLine(names[0]);
            Console.WriteLine("------------------------------------------------------");

            int tabCount = (int) startDay.DayOfWeek;

            Console.Write(new String('\t', startDay.DayOfWeek == DayOfWeek.Sunday ? 6 : tabCount - 1));
            for (var curDate = startDay; curDate != endDay; curDate = curDate.AddDays(1))
            {                 
                Console.Write($"{curDate.Day}\t");

                if (curDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    Console.WriteLine(Environment.NewLine);
                }
            }
            
            Console.ReadLine();
        }
    }
}
