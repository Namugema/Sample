using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sample.Core;
using Sample.Data;

namespace Sample.Pages.Restaurant
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IProjectData projectData;
        private readonly ILogger<ListModel> logger;

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; } = string.Empty;
        public string footerText { get; set; } = string.Empty;
        public IEnumerable<Project> Projects { get; set; } = Enumerable.Empty<Project>();

        public ListModel(IConfiguration config, IProjectData projectData, ILogger<ListModel> logger)
        {
            this.config = config;
            this.projectData = projectData;
            this.logger = logger;
        }

        public void OnGet()
        {
            //logger.LogError("Executing List Model");
            Projects = projectData.GetProjectByName(SearchTerm);

            footerText = config["copyRightText"];

        }
    }
}
