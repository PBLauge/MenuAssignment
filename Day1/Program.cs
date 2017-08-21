using System;
using MenuAppBLL;
using MenuAppEntity;

namespace MenuAppUI
{
    class Program
    {
        static BLLFacade bllFacade = new BLLFacade();

        static void Main(string[] args)
        {

            bllFacade.Service.Create(new Video()
            {
                Title = "Saw",
                Genre = "Horror"
             });

            bllFacade.Service.Create(new Video()
            {
                Title = "Cat does stuff",
                Genre = "Cat video",
            });


            string[] menuItems =
            {
                "Create video",
                "List of videos",
                "Edit video",
                "Delete video",
                //"Search video",
                "Exit"
            };

            var selection = ShowMenu(menuItems);
            while (selection != 5)
            {
                switch (selection)
                {
                    case 1:
                        CreateVideo();
                        break;
                    case 2:
                        ListVideos();
                        break;
                    case 3:
                        EditVideo();
                        break;
                    case 4:
                        DeleteVideo();
                        break;
                    //case 5:
                    //    SearchVideo();
                    //    break;
                }
                Console.ReadLine();
                selection = ShowMenu(menuItems);

            }
            Console.WriteLine("\nBye!");
            

            Console.ReadLine();

        }

        //private static void SearchVideo()
        //{
        //    Console.WriteLine("What would you like to search for? \n");
        //    var videoFound = FindVideoById();
        //    if (videoFound != null)
        //    {
        //        Console.WriteLine($"The video - {videoFound.Title} - was found.");
        //    }
        //}

        private static void DeleteVideo()
        {
            var videoFound = FindVideoById();
            if (videoFound != null)
            {
                bllFacade.Service.Delete(videoFound.Id);
            }
            else
            {
                Console.WriteLine("Video not found");
            }
        }

        private static void EditVideo()
        {
            var video = FindVideoById();
            if (video != null)
            {
                Console.WriteLine("Title: ");
                video.Title = Console.ReadLine();
                Console.WriteLine("Genre: ");
                video.Genre = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Video not found");
            }
            
        }

        private static void ListVideos()
        {
            Console.WriteLine("\n List of videos");
            foreach (var video in bllFacade.Service.GetAll())
            {
                Console.WriteLine($"Id: {video.Id} Title: {video.Title} | Genre: {video.Genre}");
            }
            Console.WriteLine("\n");
        }

        private static void CreateVideo()
        {
            Console.WriteLine("Title: ");
            var title = Console.ReadLine();

            Console.WriteLine("Genre: ");
            var genre = Console.ReadLine();

            bllFacade.Service.Create(new Video()
            {
                Title = title,
                Genre = genre,
            });
        }

        static Video FindVideoById()
        {
            Console.WriteLine("Please type in a viable id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("The id is a number...");
            }

            return bllFacade.Service.Get(id);
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
                Console.WriteLine("You need to select a number between 1 and 5");
            }
            
            return selection;
        }
    }
}