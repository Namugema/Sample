using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sample.Core;
using Sample.Data;

namespace Sample.Pages.Projects
{
    public class DetailModel : PageModel
    {
        private readonly IProjectData projectData;

        [TempData]
        public string Message { get; set; }
        public Project Project { get; set; } = new Project();

        public DetailModel(IProjectData projectData)
        {
            this.projectData = projectData;
        }

        public IActionResult OnGet(int projectId)
        {
            Project = projectData.getById(projectId);

            if (Project == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();

        }
    }
}
