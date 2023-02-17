using System.ComponentModel.DataAnnotations;

namespace Sample.Core
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public string GithubRepo { get; set; } = string.Empty;
        public string ProjectImage { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [Required]
        public ProjectStatus Status { get; set; }
    }
}