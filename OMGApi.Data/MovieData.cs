using MySql.Data.MySqlClient;
using OMGApi.Data.Interfaces;
using OMGApi.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace OMGApi.Data
{
    public class MovieData : IMovieData
    {

        private readonly IDatabaseComs databaseComs;

        public MovieData(IDatabaseComs databaseComs)
        {
            this.databaseComs = databaseComs;
        }

        public void AddToDatabase(Movie movie)
        {

            (string, MySqlDbType, string)[] parameters = {
                ("@imdbID" , MySqlDbType.VarChar, movie.imdbID),
                ("@imdbRating" , MySqlDbType.VarChar, movie.imdbRating),
                ("@imdbVotes" , MySqlDbType.VarChar, movie.imdbVotes),
                ("@Title" , MySqlDbType.VarChar, movie.Title),
                ("@Year" , MySqlDbType.VarChar, movie.Year),
                ("@Rated" , MySqlDbType.VarChar, movie.Rated),
                ("@Released" , MySqlDbType.VarChar, movie.Released),
                ("@Runtime" , MySqlDbType.VarChar, movie.Runtime),
            };

            var commandText = $@"
INSERT INTO movies 
VALUES (
    @imdbID, 
    @imdbRating, 
    @imdbVotes, 
    @Title, 
    @Year, 
    @Rated,
    @Released,
    @Runtime)";

            databaseComs.RunCommand(commandText, parameters);

        }

        public void EditDatabaseRecord(string id, Movie movie)
        {

            (string, MySqlDbType, string)[] parameters = {
                ("@sid" , MySqlDbType.VarChar, id),
                ("@imdbID" , MySqlDbType.VarChar, movie.imdbID),
                ("@imdbRating" , MySqlDbType.VarChar, movie.imdbRating),
                ("@imdbVotes" , MySqlDbType.VarChar, movie.imdbVotes),
                ("@Title" , MySqlDbType.VarChar, movie.Title),
                ("@Year" , MySqlDbType.VarChar, movie.Year),
                ("@Rated" , MySqlDbType.VarChar, movie.Rated),
                ("@Released" , MySqlDbType.VarChar, movie.Released),
                ("@Runtime" , MySqlDbType.VarChar, movie.Runtime),
            };

            var commandText = $@"
UPDATE movies SET
    imdbID = @imdbID,
    imdbRating = @imdbRating, 
    imdbVotes = @imdbVotes, 
    Title = @Title, 
    Year = @Year, 
    Rated = @Rated,
    Released = @Released,
    Runtime = @Runtime
WHERE imdbID = @sid";

            databaseComs.RunCommand(commandText, parameters);

        }

        public void DeleteDatabaseRecord(string id)
        {
            (string, MySqlDbType, string)[] parameters = {
                ("@imdbID" , MySqlDbType.VarChar, id)
            };

            var commandText = $@"
DELETE FROM movies WHERE imdbID = @imdbID
";

            databaseComs.RunCommand(commandText, parameters);

        }

        public IEnumerable<Movie> GetAllMovies()
        {
            var commandText = "SELECT * FROM movies";

            return from DataRow row in databaseComs.FillTable(commandText).Rows
                    select new Movie
                    {
                        imdbID = row["imdbID"].ToString(),
                        imdbRating = row["imdbRating"].ToString(),
                        imdbVotes = row["imdbVotes"].ToString(),
                        Title = row["Title"].ToString(),
                        Year = row["Year"].ToString(),
                        Rated = row["Rated"].ToString(),
                        Released = row["Released"].ToString(),
                        Runtime = row["Runtime"].ToString()
                    };
        }

    }
}
