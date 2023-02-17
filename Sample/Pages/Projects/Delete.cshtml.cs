using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sample.Core;
using Sample.Data;

namespace Sample.Pages.Projects
{
    public class DeleteModel : PageModel
    {
        private readonly IProjectData projectData;
        public Project project { get; set; }

        public DeleteModel(IProjectData projectData) { 
            this.projectData = projectData;
        }
        public IActionResult OnGet(int projectId)
        {
            project = projectData.getById(projectId);
            if(project == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int projectId)
        {
            var deletedProj = projectData.Delete(projectId);
            projectData.Commit();

            if(deletedProj == null)
            {
                return RedirectToPage("./NotFound");
            }
            TempData["Message"] = $"{project.Name} deleted!";
            return RedirectToPage("./List");
        }
    }
}
