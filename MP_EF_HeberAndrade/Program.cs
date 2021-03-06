using Microsoft.EntityFrameworkCore;
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


                //void PageMainMenu()
                //{
                //    Header("Update Item");
                //    ShowAllComputers();
                //    WriteLine("What Item are you looking for?");
                //    WriteLine("a) Press key a to go to MENU");
                //    WriteLine("b) Press key b to create a Item");
                //    WriteLine("c) Press key c to Update Item");
                //    WriteLine("d) Press key d to Delete Item");

                //    ConsoleKey command = Console.ReadKey(true).Key;

                //}

              
                Computer computerItem = new Computer ("MacBook", "2018 15 inch ", 20180101, 13000, 20211201, 8000);
                string classBrand = computerItem.GetType().Name;
                PropertyInfo brand = computerItem.GetType().GetProperty("Brand");
                List<PropertyInfo> properties = computerItem.GetType().GetProperties().ToList();

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


                void Header(string text)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    Console.WriteLine(text.ToUpper());
                    Console.WriteLine();
                }

                void WriteLine(string text = "")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(text);
                }

                void Write(string text)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(text);
                }


                void ShowAllComputers()
                {
                    foreach (Computer computer in computers)
                    {
                        foreach (var colWidth in colWidths)
                        {
                            var c = computer.GetType().GetProperties().Where(c => c.Name == colWidth.Key).FirstOrDefault();
                            Console.Write(c.GetValue(computer).ToString().PadRight(colWidth.Value + 2));
                        }
                        Console.WriteLine();
                    }
                }

                //void ShowAllComputers()
                //{
                //    foreach (var x in dbContext.Computers)
                //    {
                //        WriteLine(x.Id.ToString().PadRight(5) + x.Brand.PadRight(30));
                //    }
                //    Console.WriteLine();
                //}

            }
        }
    }
}
