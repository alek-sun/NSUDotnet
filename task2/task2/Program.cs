using System;
using System.Collections.Generic;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Как тебя зовут?");
            Random random = new Random();
            int num = random.Next(50);

            string user = Console.ReadLine();            
            Console.WriteLine($"Привет, {user}! Угадай число от 0 до 50");

            int userNumber;
            string input, status;
            List<string> history = new List<string>();
            string[] funArray = new string[5]
            {
                $"Все получится, {user} :) попробуй ещё раз :",
                "Когда-нибудь ты угадаешь:) выпей кофейку и попробуй снова :",
                $"{user}, я в тебя верю, попробуй ещё : ",
                "Ты близок! Давай, в десяточку :",
                $"{user}, тебе сегодня повезет! Попробуй снова :"
            };
            int tryCount = 0;

            DateTime start = DateTime.Now;

            while (true)
            {
                input = Console.ReadLine();
                tryCount++;
                if (input == "q")
                {
                    Console.WriteLine("Прости, но мне пора, а то оперативка опять ругаться будет, что мусор не вынес. " +
                        "Приятно было пообщаться с живым человеком:)");
                    break;
                }
                userNumber = Int32.Parse(input);
                if (userNumber == num)
                {                  
                    TimeSpan interval = DateTime.Now - start;
                    Console.WriteLine($"Правильно! {num}");
                    Console.WriteLine($"Число попыток : {tryCount}");
                    Console.WriteLine($"Угадал за {interval.ToString()} ");
                    foreach (string s in history){
                        Console.WriteLine(s);
                    }
                    break;
                } else
                {
                    if (userNumber < num)
                    {
                        status = "Моё число больше";                        
                    } else
                    {
                        status = "Моё число меньше";
                    }
                    history.Add($"> {userNumber} {status} ");
                    Console.WriteLine(status);
                    int index = random.Next(0, 4);
                    Console.WriteLine(funArray[index]);
                    Console.WriteLine("-----------------------------");
                }
            }
            Console.ReadLine();
        }
    }
}
