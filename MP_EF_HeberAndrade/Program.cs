using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MP_EF_HeberAndrade
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using (var dbContext = new AssetsContext())
            {
                string itemName;
                itemName = "item";

                DateTime dateNow = new DateTime();
                dateNow = DateTime.Now;

                string dateNowOnly = dateNow.ToShortDateString();
                string PurchaseDay = new DateTime(2007, 10, 12).ToString();
                string ExpiredDate = new DateTime(201, 10, 12).ToString();

                int lifeTimeOfItem = (365 * 3);
                int expriresAt = (lifeTimeOfItem - 90);

                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($">.............................................................<\n");
                Console.WriteLine($"       Welcomen to IDESIGNER.SE\n");
                Console.WriteLine($">.............................................................<\n");
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine($"              INVENTORY        \n");
                Console.WriteLine($">.............................................................<\n");
                Console.ResetColor();

                Console.WriteLine($"Wich item are you looking for?\n\nPRESS Key to ENTER\n\nOR 'q' TO QUIT.\n");
                Console.ResetColor();

                Console.Write($"Write the name Item: ");
                itemName = Console.ReadLine();
                var item = itemName;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"\nYou have asked for : " + " *** " + itemName + " *** ");
                Console.ResetColor();

                

                Console.WriteLine($"\n\nOur actual Inventory is : \n");
                Console.WriteLine($">.............................................................<\n");


                Console.WriteLine($"\n\n\nENTER 'q' TO QUIT.\n");

                while (true)
                {

                    string insert = Console.ReadLine();

                    if (insert == "q")
                    {
                        Console.WriteLine("\nBye, Thanks for your visit!\n");
                        break;
                    }

                    if (insert != "q")
                    {
                    }
                }
                // (string brand, string modelName, int purchaseDate, int inicialCost, int expiredDate, int expiredCost)
                // new Asset("MacBook", "Pro 2018 15 inch ", 20180101, 13000, 20211201, 8000),
                dbContext.Add(new Computer("MacBook", "Pro 2018 15 inch ", 20180101, 13000, 20211201, 8000));
                dbContext.SaveChanges();

                var result = dbContext.Computers.ToList()
                                   .Select(d => d.Brand);
                Console.WriteLine(string.Join(", ", result));

                //                var resultSum = dbContext.Computers
                //                    .Where(d => d.InicialCost > 0)
                //                   .OrderBy(d => d.InicialCost)
                //                   .GroupBy(o => 1)
                //                    .Select(d =>
                //                       "Average days:" + (float)d.Sum(d => d.InicialCost) / (float)Math.Max(1, d.Count()) +
                //                       "(total diets: " + d.Count() + ")"
                //                   );
                //               Console.WriteLine(string.Join(", ", result));
                //               Console.WriteLine(string.Join(", ", resultSum));

            }
        }
    }
}
