namespace StudyApsCode.Core.Repositories
{
    using StudyApsCode.Core.Domain;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;


    public interface ISearchMovies
    {

        Task<Moives> Movies(string title, string type, string year);

        Task<MoviesItem> MoviiesByID(string movieID);
    }
}