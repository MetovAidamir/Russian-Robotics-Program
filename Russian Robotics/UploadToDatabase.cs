using Russian_Robotics.Models;
using System;
using System.IO;
using System.Linq;

namespace Russian_Robotics
{
    class UploadToDatabase
    {
        public void Upload(string fileName) { 
        var readcsv = File.ReadAllText("C:/Users/mnvp/Desktop/Russin Robotics/"+ fileName);
        string[] csvfilerecord = readcsv.Split('\n');
        int i = 0;
            using (context db = new context())
            {
                PriceItems items;
                try
                {
                    foreach (var row in csvfilerecord)
                    {
                        if (!string.IsNullOrEmpty(row) && i >= 1)
                        {
                            var cells = row.Split(';');
                            var searchNumber=new String(cells[10].Where(x => char.IsLetterOrDigit(x)
                                         || char.IsWhiteSpace(x)).ToArray());
                            var searchVendor = new String(cells[1].Where(x => char.IsLetterOrDigit(x)
                                           || char.IsWhiteSpace(x)).ToArray());
                            string count="";
                            foreach (char s in cells[8])
                            {
                                if(s=='>'||s=='<')
                                {
                                    count = new String(cells[8].Where(x => char.IsDigit(x)).ToArray());
                                    break;
                                }
                                else
                                {
                                    count = cells[8].Substring(cells[8].IndexOf('-') + 1);
                                }
                            }
                            items = new PriceItems { Vendor = cells[1], Number = cells[10], SearchNumber = searchNumber.ToUpper(), SearchVendor = searchVendor.ToUpper(), Description = cells[3], Price = Convert.ToDecimal(cells[6]), Count = Convert.ToInt32(count) };
                            db.PriceItems.Add(items);
                        }
                        else
                        {
                            i++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Возникло исключение: " + ex);
                }
                db.SaveChanges();
            }
        } 
    }
}
