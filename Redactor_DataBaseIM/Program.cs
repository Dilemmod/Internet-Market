using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using DatabaseLibrary;
using ParserTelmart;
using System.Drawing;
using System.Threading;

namespace Redactor_DataBaseIM
{
    class Program
    {
        static void Main()
        {

            Console.WriteLine("To add products to the database, click\n'A'");
            Console.WriteLine("To clear the database, click\n'D'");
            ConsoleKeyInfo readKey = Console.ReadKey();
            if (readKey.Key == ConsoleKey.D)
            {
                Console.Clear();
                Console.WriteLine("To completely clear the database, click\n'A'");
                Console.WriteLine("To delete all users and orders, click\n'U'");
                Console.WriteLine("To delete all products and orders, click\n'P'");
                ConsoleKeyInfo сhoosingToRemove = Console.ReadKey();
                if (сhoosingToRemove.Key == ConsoleKey.A)
                {
                    Console.Clear();
                    Console.WriteLine("Please do not turn off the application, wait for the database to clear");
                    DB_Redactor.DestructorDB();
                    Console.ReadKey();
                }
                else if (сhoosingToRemove.Key == ConsoleKey.U)
                {
                    Console.Clear();
                    Console.WriteLine("Please do not turn off the application, wait until all users and orders are deleted");
                    DB_Redactor.DestructorUsersDB();
                    Console.ReadKey();
                }
                else if (сhoosingToRemove.Key == ConsoleKey.P)
                {
                    Console.Clear();
                    Console.WriteLine("Please do not turn off the application, wait until all products and orders are deleted");
                    DB_Redactor.DestructorProductsDB();
                    Console.ReadKey();
                }
            }
            else if (readKey.Key == ConsoleKey.A)
            {
                Console.Clear();
                Console.WriteLine("Please do not turn off the application, products are added to the database");
                DB_Redactor.FillDataBase();
                Console.ReadKey();
            }
        }
        class DB_Redactor
        {
            public static async void DestructorDB()
            {
                try
                {
                    using (DataBaseIM db = new DataBaseIM())
                    {
                        db.MenedjersInformations.RemoveRange(db.MenedjersInformations);
                        db.CustomersInformations.RemoveRange(db.CustomersInformations);
                        db.UsersLogins.RemoveRange(db.UsersLogins);
                        db.Orders.RemoveRange(db.Orders);
                        db.Characteristics.RemoveRange(db.Characteristics);
                        db.Products.RemoveRange(db.Products);
                        await db.SaveChangesAsync();
                        Console.WriteLine("DB Clear.\n You can turn off the application");
                        Console.ReadKey();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Eror :" + ex);
                }
            }
            public static async void DestructorUsersDB()
            {
                try
                {
                    using (DataBaseIM db = new DataBaseIM())
                    {
                        db.MenedjersInformations.RemoveRange(db.MenedjersInformations);
                        db.CustomersInformations.RemoveRange(db.CustomersInformations);
                        db.UsersLogins.RemoveRange(db.UsersLogins);
                        db.Orders.RemoveRange(db.Orders);
                        await db.SaveChangesAsync();
                        Console.WriteLine("All users and orders are deleted.\n You can turn off the application");
                        Console.ReadKey();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Eror :" + ex);
                }
            }
            public static async void DestructorProductsDB()
            {
                try
                {
                    using (DataBaseIM db = new DataBaseIM())
                    {
                        db.Orders.RemoveRange(db.Orders);
                        db.Characteristics.RemoveRange(db.Characteristics);
                        db.Products.RemoveRange(db.Products);
                        await db.SaveChangesAsync();
                        Console.WriteLine("All products and orders are deleted.\n You can turn off the application");
                        Console.ReadKey();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Eror :" + ex);
                }
            }
            public static async void FillDataBase()
            {
                List<string> ReferenceByTelemart = new List<string>()
                {
                    "https://telemart.ua/ua/processor/",
                    "https://telemart.ua/ua/motherboard/",
                    "https://telemart.ua/ua/videocard/",
                    "https://telemart.ua/ua/ram/",
                    "https://telemart.ua/ua/hard-drive/",
                    "https://telemart.ua/ua/case/",
                    "https://telemart.ua/ua/powersuply/",

                    "https://telemart.ua/ua/ua/mouse/",
                    "https://telemart.ua/ua/keyboards/",
                    "https://telemart.ua/ua/kovriki/",
                    "https://telemart.ua/ua/microphones/",
                    "https://telemart.ua/ua/earphones/",
                    "https://telemart.ua/ua/web-cam/",
                    "https://telemart.ua/ua/hdmi-dvi-vga-cables/",

                    "https://telemart.ua/ua/monitors/filter/for-office-tasks/",
                    "https://telemart.ua/ua/monitors/filter/for-game/",
                    "https://telemart.ua/ua/monitors/filter/work-with-graphics/",
                    "https://telemart.ua/ua/monitors/",

                    "https://telemart.ua/ua/laptops/filter/1920x1080/",
                    "https://telemart.ua/ua/laptops/filter/geforce-1080/geforce-1660-ti/geforce-2060/geforce-2070/geforce-2080/",
                    "https://telemart.ua/ua/laptops/",

                    "https://telemart.ua/ua/pc/filter/t-gaming/",
                    "https://telemart.ua/ua/pc/filter/t-ultra/",
                };
                List<string> CategoriesNameForReferance = new List<string>()
            {
                "Processor","Motherboard","Videocard","Ram","HardDrive","Case","Powersuply",
                "Mouse","Keyboard","Capet","Microphone","Headset","Camera","Cabel",
                "MonitorOfice", "MonitorGame", "MonitorDisign", "MonitorAll",
                "NoutbookOfice", "NoutbookGame", "NoutbookAll",
                "PcGame", "PcUltra"
            };
                using (DataBaseIM db = new DataBaseIM())
                {
                    UsersLogin uL = new UsersLogin();
                    uL.Admin = true;
                    uL.Login = "Admin";
                    uL.Password = "123";
                    uL.Mail = "admin@gmail.com";
                    MenedjerInformation mInfo = new MenedjerInformation();
                    mInfo.UserLogin = uL;
                    db.UsersLogins.Add(uL);
                    db.MenedjersInformations.Add(mInfo);
                    Console.WriteLine("Менеджер Admin доданий в базу даних\n");
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
                                foreach (var iteDataBaseIM in s)
                                {
                                    Characteristic ch = new Characteristic();
                                    string target = "";
                                    regex = new Regex(@"<[^>]*>");
                                    string withoutTags = regex.Replace(iteDataBaseIM, target);
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
                            Console.WriteLine("Link : " + l + " uploaded");
                        }
                        catch (Exception)
                        {

                            Console.WriteLine("Eror by: " + l);
                        }
                    }
                    Console.WriteLine("All links uploaded successfully");
                }
            }
        }
    }
}
