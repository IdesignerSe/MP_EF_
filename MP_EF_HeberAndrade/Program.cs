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
            Console.WriteLine("Hi here all the assets!");
            using (var dbContext = new AssetsContext())
            {
                // (string brand, string modelName, int purchaseDate, int inicialCost, int expiredDate, int expiredCost)
                // new Asset("MacBook", "Pro 2018 15 inch ", 20180101, 13000, 20211201, 8000),
                dbContext.Add(new Computer("MacBook", "Pro 2018 15 inch ", 20180101, 13000, 20211201, 8000));
                dbContext.SaveChanges();

                var result = dbContext.Computers.ToList()
                                   .Where(d => d.InicialCost > 0)
                                   .Take(5)
                                   .OrderBy(d => d.InicialCost)
                                   .Select(d => d.Brand);
                Console.WriteLine(string.Join(", ", result));
                //
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
