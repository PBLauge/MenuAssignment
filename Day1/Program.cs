using System;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] menuItems =
            {
                "Create video",
                "Read video",
                "Update video",
                "Delete video",
                "Search video",
                "Exit"
            };

            var selection = ShowMenu(menuItems);
            while (selection != 6)
            {
                switch (selection)
                {
                    case 1:
                        Console.WriteLine("\nCreate video");
                        break;
                    case 2:
                        Console.WriteLine("\nRead video");
                        break;
                    case 3:
                        Console.WriteLine("\nUpdate video");
                        break;
                    case 4:
                        Console.WriteLine("\nDelete video");
                        break;
                    case 5:
                        Console.WriteLine("\nSearch video");
                        Console.WriteLine("What would you like to find?");
                        break;
                }
                Console.ReadLine();
                selection = ShowMenu(menuItems);

            }
            Console.WriteLine("\nBye!");
            

            Console.ReadLine();

        }
        
        private static int ShowMenu(string[] menuItems)
        {
            Console.Clear();
            Console.WriteLine("Select what you want to do: \n");

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{(i + 1)}: {menuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1
                || selection > 6
                )
            {
                Console.WriteLine("You need to select a number between 1 and 6");
            }
            
            return selection;
        }
    }
}