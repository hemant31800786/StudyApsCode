namespace StudyApsCode.Persistence.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;
    using StudyApsCode.Core.Domain;
    using StudyApsCode.api;
    using StudyApsCode.Core.Repositories;

    public class SearchMovies : ISearchMovies
    {
        public async Task<Moives> Movies(string title, string type, string year)
        {
            try
            {
                using (var getMoviesData = new Data())
                {
                    return await getMoviesData.GetMoviesAsync(title, type, year);
                }
            }
            catch (Exception)
            {
                // not implement log information.
                throw;
            }
        }

        public async Task<MoviesItem> MoviiesByID(string movieID)
        {
            try
            {
                using (var getMoviesData = new Data())
                {
                    return await getMoviesData.GetMoviesByIDAsync(movieID);
                }
            }
            catch (Exception)
            {
                // not implement log information.
                throw;
            }
        }


    }
}