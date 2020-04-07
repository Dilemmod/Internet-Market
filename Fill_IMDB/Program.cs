using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using DatabaseLibrary;
using ParserTelmart;
using System.Drawing;


namespace Fill_M1
{
    class Program
    {
        static void Main()
        {
             FillDataBase();
            //string input = "Mother sadsakhj sakjdaskd";
            //string patern = "Th";
            //if(Regex.IsMatch(input, patern, RegexOptions.IgnoreCase))
            //{
            //    Console.WriteLine("OK");
            //}
            //else
            //{
            //    Console.WriteLine("NO");
            //}
            Console.ReadKey();
        }
        public static async void FillDataBase()
        {
            using (M1 db = new M1())
            {
                List<Product> productList = new List<Product>();
                var parser = new Parser();
                var result = parser.GetInfo("https://telemart.ua/videocard/").Result;
                try
                {
                    for (int i = 0; i < result.Title.Count; i++)
                    {
                        Product p = new Product();
                        //Categoty
                        p.ProductCategory = "Videocard";
                        //p.ProductSubCategory = "Motherboard";
                        //Manufacture
                        // p.ProductManufacturer = "All";
                        p.Title = result.Title[i];
                        Regex regex = new Regex(@"\s*грн");
                        string clear = regex.Replace(result.Price[i], "");
                        regex = new Regex(@"\s+");
                        clear = regex.Replace(clear, "");
                        p.Price = Convert.ToInt32(clear);
                        //Reference on image
                        p.ImageData = result.Images[i];
                        //Characteristics
                        string[] s = Regex.Split(result.Characteristics[i], "</div>");
                        s = Regex.Split(s[1], "<br>");
                        List<Characteristic> listCharact = new List<Characteristic>();
                        foreach (var item1 in s)
                        {
                            Characteristic ch = new Characteristic();
                            string target = "";
                            regex = new Regex(@"<[^>]*>");
                            string withoutTags = regex.Replace(item1, target);
                            regex = new Regex(@"^\s+");
                            clear = regex.Replace(withoutTags, target);
                            ch.CharacteristicString = clear;
                            listCharact.Add(ch);
                        }
                        p.Characteristics = listCharact;
                        productList.Add(p);
                    }
                    db.Products.AddRange(productList);
                    await db.SaveChangesAsync();
                    Console.WriteLine("Done");
                }
                catch (Exception)
                {

                    Console.WriteLine("Eror");
                }
            }
        }
    }
}
