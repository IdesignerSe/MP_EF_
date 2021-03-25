﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MP_EF_HeberAndrade
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new AssetsContext())
            {

                Computer computerItem = new Computer("MacBook", "2018 15 inch ", 20180101, 13000, 20211201, 8000);
                string classBrand = computerItem.GetType().Name;
                PropertyInfo brand = computerItem.GetType().GetProperty("Brand");
                List<PropertyInfo> properties = computerItem.GetType().GetProperties().ToList();


                //foreach(PropertyInfo property in properties)
                //{
                //    Console.Write(property.Name.PadRight(property.Name.Length + 7));
                //}

                //Console.WriteLine();

                //foreach (PropertyInfo property in properties)
                //{
                //        Console.Write(property.GetValue(computerItem).ToString().PadRight(property.GetValue(computerItem).ToString().Length + 7));
                //}

                Computer computerItem2 = new Computer("MacBook", "2019 15 inch ", 20180101, 16000, 20211201, 10000);
                List<Computer> computers = new List<Computer>();

                computers.Add(computerItem);
                computers.Add(computerItem2);
                computers = dbContext.Computers.ToList();

                Dictionary<string, int> colWidths = new Dictionary<string, int>();

                foreach (PropertyInfo property in properties)
                {
                    int colLength = property.Name.Length;
                    int tmpLength = 0;
                    int dataLength = 0;

                    foreach (Computer computer in computers)
                    {
                        tmpLength = computers.Max(computer => computer.GetType().GetProperty(property.Name)).GetValue(computer).ToString().Length;
                        dataLength = Math.Max(dataLength, tmpLength);
                    }
                    int maxLength = Math.Max(colLength, dataLength);

                    colWidths.Add(property.Name, maxLength);
                }

                Console.WriteLine();

                //Print Header with correct widths
                foreach (var colWidth in colWidths)
                {
                    Console.Write(colWidth.Key.PadRight(colWidth.Value + 2));
                }

                Console.WriteLine();

                //Print Data with correct widths
                foreach (Computer computer in computers)
                {
                    foreach (var colWidth in colWidths)
                    {
                        var c = computer.GetType().GetProperties().Where(c => c.Name == colWidth.Key).FirstOrDefault();
                        Console.Write(c.GetValue(computer).ToString().PadRight(colWidth.Value + 2));
                    }
                    Console.WriteLine();

                }





                //Computer computer1 = new Computer("MacBook", "Pro 2018 15 inch ", 20180101, 13000, 20211201, 8000);

                //dbContext.Add(computer1);
                //dbContext.SaveChanges();


                //Computer computer2 = new Computer("MacBook", "Pro 2019 15 inch ", 20180101, 16000, 20211201, 10000);
                //Computer computer3 = new Computer("MacBook", "Pro 2020 15 inch ", 20180101, 18000, 20211201, 13000);


                //dbContext.Computers.AddRange(computer2,computer3);
                //Computer computer4 = new Computer("MacBook", "Pro 2020 15 inch ", 20180101, 18000, 20211201, 13000);
                //dbContext.Add(computer4);

                //dbContext.SaveChanges();





                //(string brand, string modelName, int purchaseDate, int inicialCost, int expiredDate, int expiredCost)
                // new Asset("MacBook", "Pro 2018 15 inch ", 20180101, 13000, 20211201, 8000),
                // dbContext.Add(new Computer("MacBook", "Pro 2018 15 inch ", 20180101, 13000, 20211201, 8000));

                //// dbContext.SaveChanges();

                // var result = dbContext.Computers.ToList()
                //                   .Select(d => d.Brand);
                // Console.WriteLine(string.Join(", ", result));;

            }
        }
    }
}
