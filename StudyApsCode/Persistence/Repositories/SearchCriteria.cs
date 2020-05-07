namespace StudyApsCode.Persistence.Repositories
{

    using System.ComponentModel.DataAnnotations;

    public class SearchCriteria
    {
        [Required]
        public string Title { get; set; }

        public string Year { get; set; }

        public string Type { get; set; }
    }
}