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

                 //(string brand, string modelName, int purchaseDate, int inicialCost, int expiredDate, int expiredCost)
                // new Asset("MacBook", "Pro 2018 15 inch ", 20180101, 13000, 20211201, 8000),
                 dbContext.Add(new Computer("MacBook", "Pro 2018 15 inch ", 20180101, 13000, 20211201, 8000));
                  
                 dbContext.SaveChanges();
                
                 var result = dbContext.Computers.ToList()
                                   .Select(d => d.Brand);
                Console.WriteLine(string.Join(", ", result));;



   //             Console.WriteLine("Hello World!");
     //           using (var dbContext = new CustomTreatmentContext())
       //         {
         //           dbContext.Add(new Diet("Superduper diet", "Hard", 2, 200));
           //         dbContext.SaveChanges();
             //       var result = dbContext.Diets.ToList()
               //         .Where(d => d.DietDaysProgram > 0)
                 //       .Take(5)
                   //     .OrderBy(d => d.DietDaysProgram)
 //                       .Select(d => d.DietName);
 //
   //                 var resultSum = dbContext.Diets
     //                   .Where(d => d.DietDaysProgram > 0)
       //                 .OrderBy(d => d.DietDaysProgram)
         //               .GroupBy(o => 1)
           //             .Select(d =>
             //               "Average days:" + (float)d.Sum(d => d.DietDaysProgram) / (float)Math.Max(1, d.Count()) +
               //             "(total diets: " + d.Count() + ")"
                 //       );
 //                   Console.WriteLine(string.Join(", ", result));
   //                 Console.WriteLine(string.Join(", ", resultSum));
     //           }



            }
        }
    }
}
