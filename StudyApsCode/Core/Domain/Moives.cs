using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyApsCode.Core.Domain
{

    public class Moives
    {
        public Search[] Search { get; set; }

        public string totalResults { get; set; }

        public string Response { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public List<string> SelectedMovies { get; set; }
    }

    public class Search
    {
        public string Title { get; set; }

        public string Year { get; set; }

        public string imdbID { get; set; }

        public string Type { get; set; }

        public string Poster { get; set; }
    }



}
