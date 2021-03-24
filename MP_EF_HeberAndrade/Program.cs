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
            Console.WriteLine("Hello World!");
            using (var dbContext = new AssetsModel.AssetsContext())
            {
                dbContext.Add(new Diet("Superduper diet", "Hard", 2, 200));
                dbContext.SaveChanges();
                var result = dbContext.Diets.ToList()
                    .Where(d => d.DietDaysProgram > 0)
                    .Take(5)
                    .OrderBy(d => d.DietDaysProgram)
                    .Select(d => d.DietName);

                var resultSum = dbContext.Diets
                    .Where(d => d.DietDaysProgram > 0)
                    .OrderBy(d => d.DietDaysProgram)
                    .GroupBy(o => 1)
                    .Select(d =>
                        "Average days:" + (float)d.Sum(d => d.DietDaysProgram) / (float)Math.Max(1, d.Count()) +
                        "(total diets: " + d.Count() + ")"
                    );
                Console.WriteLine(string.Join(", ", result));
                Console.WriteLine(string.Join(", ", resultSum));
            }

        }

    }
}
