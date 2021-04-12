using Newtonsoft.Json;
using OMGApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestConsole
{
    class Program
    {

        static IWebApiClient webApiClient = new WebApiClient();

        static void Main(string[] args)
        {

            string reply;

            do
            {

                Console.Clear();

                Console.WriteLine("OMG Api Test");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("1. Search by title and year.");
                Console.WriteLine("2. Search by IMDB ID.");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("3. Create custom entry.");
                Console.WriteLine("4. Query all cached entries.");
                Console.WriteLine("5. Update cached entry.");
                Console.WriteLine("6. Delete cached entry.");
                Console.WriteLine("-----------------------------");
                reply = Console.ReadLine();

                Console.Clear();

                switch (reply)
                {
                    case "1":
                        SearchOmdbByTitleAndYear();
                        break;
                    case "2":
                        SearchOmdbByID();
                        break;
                    case "3":
                        CreateCustom();
                        break;
                    case "4":
                        SearchCache();
                        break;
                    case "5":
                        UpdateCached();
                        break;
                    case "6":
                        DeleteCached();
                        break;
                }

            }
            while (reply != "");

            Console.Clear();

            Console.WriteLine("Thank you come again.");
            Console.ReadLine();

        }

        static void SearchOmdbByTitleAndYear()
        {
            Console.WriteLine("Type in the title and year of the movie.");
            Console.Write("Title: ");
            var title = Console.ReadLine();
            Console.Write("Year: ");
            var year = Console.ReadLine();

            if(string.IsNullOrEmpty(title))
            {
                Console.WriteLine("Search must have a title.");
                Console.ReadLine();
                return;
            }

            Console.Clear();

            try
            {
                Movie movie = webApiClient.GetAsync<Movie>("https://localhost:5001", $"OMDbMovies/searchTitle/{title}" + (string.IsNullOrEmpty(year) ? "" : $"/{year}")).Result;
                OutputMovie(movie);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();

        }

        static void SearchOmdbByID()
        {
            Console.WriteLine("Type in the IMDB id of the movie.");
            Console.Write("IMDB ID: ");
            var id = Console.ReadLine();

            if (string.IsNullOrEmpty(id))
            {
                Console.WriteLine("Search must have an id.");
                Console.ReadLine();
                return;
            }

            Console.Clear();

            try
            {
                Movie movie = webApiClient.GetAsync<Movie>("https://localhost:5001", $"OMDbMovies/searchID/{id}").Result;
                OutputMovie(movie);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();

        }

        static void CreateCustom()
        {

            var movie = new Movie
            {
                imdbID = "tt0000001",
                imdbRating = "7.5",
                imdbVotes = "500,000",
                Title = "Custom Movie",
                Year = "2021",
                Rated = "PG-13",
                Released = "01 Jan 2021",
                Runtime = "120 min"
            };

            movie = ReadMovie(movie);

            Console.Clear();

            try
            {
                webApiClient.PostAsync("https://localhost:5001", "cachedEntries", movie);
                OutputMovie(movie);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();

        }

        static void SearchCache()
        {

            Console.WriteLine("Type in the parameters of the search.");
            Console.Write("Title: ");
            var title = Console.ReadLine();
            Console.Write("Year: ");
            var year = Console.ReadLine();
            Console.Write("IMDB ID: ");
            var imdbID = Console.ReadLine();

            Console.Clear();

            try
            {
                List<string> filters = new List<string>();
                if (!string.IsNullOrEmpty(title))
                    filters.Add($"title eq '{title}'");
                if (!string.IsNullOrEmpty(year))
                    filters.Add($"year eq '{year}'");
                if (!string.IsNullOrEmpty(imdbID))
                    filters.Add($"imdbID eq '{imdbID}'");

                IEnumerable<Movie> movies = webApiClient.GetAsync<IEnumerable<Movie>>("https://localhost:5001", $"cachedEntries" + (filters.Any() ? "?$Filter=" + string.Join(" and ", filters) : "")).Result;

                foreach (var movie in movies)
                    OutputMovie(movie);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();

        }

        static void UpdateCached()
        {

            Console.WriteLine("Type in the IMDB id of the movie.");
            Console.Write("IMDB ID: ");
            var id = Console.ReadLine();

            if (string.IsNullOrEmpty(id))
            {
                Console.WriteLine("Update must have an id.");
                Console.ReadLine();
                return;
            }

            Console.Clear();

            try
            {

                var movie = webApiClient.GetAsync<IEnumerable<Movie>>("https://localhost:5001", $"cachedEntries" + $"?$Filter=imdbID eq '{id}'").Result.FirstOrDefault();

                if (movie is null)
                {
                    Console.WriteLine("No movie found.");
                    Console.ReadLine();
                    return;
                }

                movie = ReadMovie(movie);

                webApiClient.PutAsync("https://localhost:5001", $"cachedEntries/{id}", movie);
                OutputMovie(movie);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();

        }

        static void DeleteCached()
        {

            Console.WriteLine("Type in the IMDB id of the movie.");
            Console.Write("IMDB ID: ");
            var id = Console.ReadLine();

            if (string.IsNullOrEmpty(id))
            {
                Console.WriteLine("Delete must have an id.");
                Console.ReadLine();
                return;
            }

            Console.Clear();

            try
            {
                webApiClient.DeleteAsync("https://localhost:5001", $"cachedEntries/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();

        }

        private static Movie ReadMovie(Movie movie)
        {

            Console.WriteLine("Type in the details of the movie.");

            Console.WriteLine("imdbID: " + movie.imdbID);
            movie.imdbID = Console.ReadLine();
            Console.WriteLine("imdbRating: " + movie.imdbRating);
            movie.imdbRating = Console.ReadLine();
            Console.WriteLine("imdbVotes: " + movie.imdbVotes);

            movie.imdbVotes = Console.ReadLine();
            Console.WriteLine("Title: " + movie.Title);
            movie.Title = Console.ReadLine();
            Console.WriteLine("Year: " + movie.Year);
            movie.Year = Console.ReadLine();
            Console.WriteLine("Rated: " + movie.Rated);
            movie.Rated = Console.ReadLine();
            Console.WriteLine("Released: " + movie.Released);
            movie.Released = Console.ReadLine();
            Console.WriteLine("Runtime: " + movie.Runtime);
            movie.Runtime = Console.ReadLine();

            return movie;

        }

        private static void OutputMovie(Movie movie)
        {
            Console.WriteLine("Result:");
            Console.WriteLine("Title   : " + movie.Title);
            Console.WriteLine("Year    : " + movie.Year);
            Console.WriteLine("Runtime : " + movie.Runtime);
            Console.WriteLine("imdbID  : " + movie.imdbID);
        }

    }
}
