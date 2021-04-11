using OMGApi.Models;
using System.Collections.Generic;

namespace OMGApi.UnitTests.DummyData
{
    public class DummyMovies
    {

        public static Movie SingleMovie = new Movie
        {
            imdbID = "00000",
            imdbRating = "0",
            imdbVotes = "0",
            Title = "Movie1",
            Year = "1990",
            Rated = "R18",
            Released = "18 May 1990",
            Runtime = "10 min"
        };

        public static Movie NewMovie = new Movie
        {
            imdbID = "00002",
            imdbRating = "0",
            imdbVotes = "0",
            Title = "Movie2",
            Year = "1992",
            Rated = "R18",
            Released = "18 May 1992",
            Runtime = "12 min"
        };

        public static List<Movie> ListOfMovies = new List<Movie>
        { 
            new Movie
            {
                imdbID = "00000",
                imdbRating = "0",
                imdbVotes = "0",
                Title = "Movie10",
                Year = "1990",
                Rated = "R18",
                Released = "18 May 1990",
                Runtime = "10 min"

            },
            new Movie
            {
                imdbID = "00001",
                imdbRating = "0",
                imdbVotes = "0",
                Title = "Movie1",
                Year = "1991",
                Rated = "R18",
                Released = "18 May 1991",
                Runtime = "11 min"
            },
        };

    }
}
