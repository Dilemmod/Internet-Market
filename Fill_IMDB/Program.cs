using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using DatabaseLibrary;
using ParserTelmart;
using System.Drawing;


namespace Fill_M5
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
            List<string> ReferenceByTelemart = new List<string>()
                {
                    "https://telemart.ua/processor/",
                    "https://telemart.ua/motherboard/",
                    "https://telemart.ua/videocard/",
                    "https://telemart.ua/ram/",
                    "https://telemart.ua/hard-drive/",
                    "https://telemart.ua/case/",
                    "https://telemart.ua/powersuply/",

                    "https://telemart.ua/mouse/",
                    "https://telemart.ua/keyboards/",
                    "https://telemart.ua/kovriki/",
                    "https://telemart.ua/microphones/",
                    "https://telemart.ua/earphones/",
                    "https://telemart.ua/web-cam/",
                    "https://telemart.ua/hdmi-dvi-vga-cables/",

                    "https://telemart.ua/monitors/filter/for-office-tasks/",
                    "https://telemart.ua/monitors/filter/for-game/",
                    "https://telemart.ua/monitors/filter/work-with-graphics/",
                    "https://telemart.ua/monitors/",

                    "https://telemart.ua/laptops/filter/1920x1080/",
                    "https://telemart.ua/laptops/filter/geforce-1080/geforce-1660-ti/geforce-2060/geforce-2070/geforce-2080/",
                    "https://telemart.ua/laptops/",

                    "https://telemart.ua/pc/filter/t-work/",
                    "https://telemart.ua/pc/filter/t-gaming/",
                    "https://telemart.ua/pc/filter/t-ultra/",
                    "https://telemart.ua/pc/"
                };
            List<string> CategoriesNameForReferance = new List<string>()
            {
                "Processor","Motherboard","Videocard","Ram","HardDrive","Case","Powersuply",
                "Mouse","Keyboard","Capet","Microphone","Headset","Camera","Cabel",
                "MonitorOfice", "MonitorGame", "MonitorDisign", "MonitorAll",
                "NoutbookOfice", "NoutbookGame", "NoutbookAll",
                "PcOfice", "PcGame", "PcUltra", "PcAll"
            };
            using (M5 db = new M5())
            {
                for (int l = 0; l < ReferenceByTelemart.Count; l++)
                {
                    List<Product> productList = new List<Product>();
                    var parser = new Parser();
                    var result = parser.GetInfo(ReferenceByTelemart[l]).Result;
                    try
                    {
                        for (int i = 0; i < result.Title.Count; i++)
                        {
                            Product p = new Product();
                            //Categoty
                            p.ProductCategory = CategoriesNameForReferance[l];

                            p.Title = result.Title[i];
                            Regex regex = new Regex(@"\s*грн");
                            string clear = regex.Replace(result.Price[i], "");
                            regex = new Regex(@"\s+");
                            clear = regex.Replace(clear, "");
                            p.Price = clear;

                            //Reference on image
                            p.ImageData = result.Images[i];
                            //Characteristics
                            string[] s = Regex.Split(result.Characteristics[i], "</div>");
                            s = Regex.Split(s[1], "<br>");
                            List<Characteristic> listCharact = new List<Characteristic>();
                            foreach (var iteM5 in s)
                            {
                                Characteristic ch = new Characteristic();
                                string target = "";
                                regex = new Regex(@"<[^>]*>");
                                string withoutTags = regex.Replace(iteM5, target);
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
                        Console.WriteLine("Link : " + l+ " uploaded");
                    }
                    catch (Exception)
                    {

                        Console.WriteLine("Eror by: "+l);
                    }
                }
                Console.WriteLine("All links uploaded successfully");
            }
        }
    }
}
