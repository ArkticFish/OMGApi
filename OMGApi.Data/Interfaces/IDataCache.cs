using OMGApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMGApi.Data.Interfaces
{
    public interface IDataCache
    {

        void AddNewEntry(Movie movie);

        void EditEntry(string id, Movie movie);

        void DeleteEntry(string id);

        List<Movie> GetAllEntries();

        bool EntryExists(string id);

    }
}
