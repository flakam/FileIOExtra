using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FileIOProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> MenuItems;
            string filepath = @"C:\Users\Flaka\Desktop\Menu.txt";
            Console.WriteLine(filepath);
            StreamReader reader;
            StreamWriter writer;
            try
            {
                reader = new StreamReader(filepath);
                string fileOutput = reader.ReadToEnd();
                List<string> existingMenu = fileOutput.Split(',').ToList();

                Console.WriteLine("Existing Menu items in the file: ");
                PrintMenuList(existingMenu);
                
                Console.WriteLine("Please input a menu item. When inputing please use character | between name of the item,category,description and price.Please put a comma in the end");
                string inputMenuItem = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine();

                if (!fileOutput.Contains(inputMenuItem))
                {
                    fileOutput += $", {inputMenuItem}";
                    Console.WriteLine("New item added!");
                    Console.WriteLine(fileOutput);
                }
                else
                {
                    Console.WriteLine("That item is already on the menu, the file has not been changed");
                    Console.WriteLine(fileOutput);
                }

                MenuItems = fileOutput.Split(',').ToList();
                reader.Close();

                writer = new StreamWriter(filepath);
                writer.Write(fileOutput);

                writer.Close();
                PrintMenuList(MenuItems);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            

        }

        public static void PrintMenuList(List<string> MenuItems)
        {
            foreach (string item in MenuItems)
            {
                Console.WriteLine(item.Trim());
            }
        }
    }
}


        
    

