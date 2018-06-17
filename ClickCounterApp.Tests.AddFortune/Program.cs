using ClickCounterApp.Entities.Fortune;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ClickCounterApp.Tests.AddFortune
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("= = = = = = Add Fortune Test = = = = = =");
            string again = "y";

            Console.WriteLine($"Total number of fortunes : {new Business.UnitOfWork.GenericRequest<Messages>(new Business.UnitOfWork.Transaction<Messages>.ExecuteDb()).GetEntryCount()}");
            Console.Write("Input Another Fortune (y or n): ");
            again = Console.ReadLine();
            while (again=="y")
            {
                Console.Write("Input Fortune Message : ");
                var message = Console.ReadLine();
                Console.Write("Input Category of Fortune : ");
                var category = Console.ReadLine();
                Console.Write("Input Fortune Lucky Numbers : ");
                var numbers = Console.ReadLine();
                Console.WriteLine("= = = = = = Creating Entry = = = = = =");
                var fortune = new Entities.Fortune.Messages
                {
                    CreatedDate = DateTime.UtcNow,
                    Message = message,
                    Type = category,
                    LuckyNumbers = numbers

                };
                new Business.UnitOfWork.GenericRequest<Messages>(new Business.UnitOfWork.Transaction<Messages>.ExecuteDb()).Insert(fortune);
                Console.Write("Input Another Fortune (y or n): ");
                again = Console.ReadLine();
                Console.WriteLine();
            }
            
            IEnumerable<Messages> data = (new Business.UnitOfWork.GenericRequest<Messages>(new Business.UnitOfWork.Transaction<Messages>.ExecuteDb()).Get().OrderByDescending(x => x.Id));
            var output = data.OrderByDescending(x => x.Id).ToList();
            //var output = (List<Messages>)Convert.ChangeType(data, typeof(List<Messages>));
            
            Console.WriteLine($"\r\n  {"Messages".PadRight(65)}Type");
            Console.WriteLine($"{"- - - - - -".PadRight(65)}- - - -");
            foreach (var message in output)
            {
                Console.WriteLine($" {message.Id.ToString().PadRight(3)}{message.Message.PadRight(65)}{message.Type}");
            }
            Console.WriteLine("\r\nPress any key to continue...");
            Console.ReadKey();

        }
    }
}
