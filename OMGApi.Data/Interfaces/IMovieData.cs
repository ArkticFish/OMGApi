using OMGApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMGApi.Data.Interfaces
{

    public interface IMovieData
    {

        public void AddToDatabase(Movie movie);

        void EditDatabaseRecord(string id, Movie movie);

        void DeleteDatabaseRecord(string id);

        IEnumerable<Movie> GetAllMovies();

    }

}
