using System;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;

using StudyApsCode.Core.Domain;

namespace StudyApsCode.api
{
    public class Data : ApiController
    {


        public async Task<Moives> GetMoviesAsync(string title, string type, string year)
        {
            try
            {
                using (var httpClient = new System.Net.Http.HttpClient())
                {
                    Moives movies = new Moives();
                    var url = AplicationData.Url;
                    if (title != null)
                    {
                        url = $"{url}&s={title}";

                    }
                    if (type.Trim() != string.Empty)
                    {
                        url = $"{url}&type={type}";

                    }

                    if (year != null)
                    {
                        url = $"{url}&y={year}";

                    }

                    using (System.Net.Http.HttpResponseMessage response = await httpClient.GetAsync(url))
                    {


                        if (response.IsSuccessStatusCode)
                        {
                            string json = await response.Content.ReadAsStringAsync();

                            movies = JsonConvert.DeserializeObject<Moives>(json);
                        }
                    }

                    return movies;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<MoviesItem> GetMoviesByIDAsync(string movidID)
        {
            try
            {
                using (var httpClient = new System.Net.Http.HttpClient())
                {
                    MoviesItem movies = new MoviesItem();
                    var url = AplicationData.Url + "&i=" + movidID;

                    using (System.Net.Http.HttpResponseMessage response = await httpClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string json = await response.Content.ReadAsStringAsync();

                            movies = JsonConvert.DeserializeObject<MoviesItem>(json);
                        }
                    }

                    return movies;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}