using System;
using System.Collections.Generic;
using IMDBConsoleApp.Domain;
using IMDBConsoleApp.Repository;

namespace IMDBConsoleApp
{
    class Program
    {
        private static MovieRepository _movieRepository = new MovieRepository();
        static void Main(string[] args)
        {
            //var exit = false;
            //do
            //{
            //    Console.WriteLine("1.List Movie");
            //    Console.WriteLine("2.Add Movie");
            //    Console.WriteLine("3.Add Actor");
            //    Console.WriteLine("4.Add Producer");
            //    Console.WriteLine("5.Delete Movie");
            //    Console.WriteLine("6.Exit");
            //    Console.WriteLine("Select Option");
            //    var option = int.Parse(Console.ReadLine());

            //    switch (option)
            //    {
            //        case 1:
            //            var movies = _movieRepository.GetAll();
            //            Console.WriteLine(movies);
            //            break;

            //        case 2:
            //            Console.WriteLine("Enter Movie name");
            //            var movieName = Console.ReadLine();
            //            Console.WriteLine("Enter Movie Release Date");
            //            var movieReleaseDate = Convert.ToDateTime(Console.ReadLine());
            //            Console.WriteLine("Enter Movie Plot");
            //            var moviePlot = Console.ReadLine();
            //            Console.WriteLine("Select Actor");
            //            break;
            //        case 3:
            //            Console.WriteLine("Option coming soon...");
            //            break;
            //        case 4:
            //            Console.WriteLine("Option coming soon...");
            //            break;
            //        case 5:
            //            Console.WriteLine("Option coming soon...");
            //            break;
            //        default:
            //            exit = true;
            //            break;
            //    }
            //} while (!exit);

         
        }
    }
}
