using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using Russian_Robotics.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Russian_Robotics
{
    class UploadToDatabase
    {
        public void Upload(string fileName)
        {
            using (context db = new context())
            {
                PriceItems items;
                var badRow = new List<string>();
                var config = new CsvConfiguration(CultureInfo.CurrentCulture)
                {

                    Delimiter = ";",
                    BadDataFound = arg => badRow.Add(arg.Context.Parser.RawRecord)
                };
                var reader = new StreamReader(@"C:/Users/mnvp/Desktop/Russin Robotics/"+ fileName);
                var csvReader = new CsvReader(reader, config);
                var reacords = csvReader.GetRecords<PriceitemsClassMap>().ToList();
                int countRow = 1;
                foreach (var row in reacords)
                {
                    countRow++;
                    try
                    {
                        var searchNumber = new String(row.Number.Where(x => char.IsLetterOrDigit(x)
                                          || char.IsWhiteSpace(x)).ToArray());
                        var searchVendor = new String(row.Vendor.Where(x => char.IsLetterOrDigit(x)
                                       || char.IsWhiteSpace(x)).ToArray());
                        string count = "";
                        if (row.Count[0] == '>' || row.Count[0] == '<')
                        {
                            count = row.Count.Substring(1);

                        }
                        else
                        {
                            count = row.Count.Substring(row.Count.IndexOf('-') + 1);
                        }
                        items = new PriceItems { Vendor = row.Vendor, Number = row.Number, SearchNumber = searchNumber.ToUpper(), SearchVendor = searchVendor.ToUpper(), Description = row.Description, Price = Convert.ToDecimal(row.Price), Count = Convert.ToInt32(count) };
                        db.PriceItems.Add(items);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message + " - Nomer: " + countRow);
                    }
                }
                Console.WriteLine("Bad Date: " + badRow.Count);
            }
        }
    }
    class PriceitemsClassMap
    {
        [Name("Бренд")]
        public string Vendor { get; set; }

        [Name("Каталожный номер")]
        public string Number { get; set; }

        [Name("Бренд")]
        public string SearchVendor { get; set; }

        [Name("Каталожный номер")]
        public string SearchNumber { get; set; }

        [Name("Описание")]
        public string Description { get; set; }

        [Name("Цена, руб.")]
        public string Price { get; set; }
        [Name("Наличие")]
        public string Count { get; set; }
    }
}
