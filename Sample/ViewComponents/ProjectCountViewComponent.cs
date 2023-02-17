using Microsoft.AspNetCore.Mvc;
using Sample.Data;

namespace Sample.ViewComponents
{
    public class ProjectCountViewComponent: ViewComponent
    {
        private readonly IProjectData projectData;

        public ProjectCountViewComponent(IProjectData projectData) { 
            this.projectData = projectData;
        }

        public IViewComponentResult Invoke() 
        {
            var count = projectData.GetCountOfProjects();
            return View(count);
        }
    }
}
