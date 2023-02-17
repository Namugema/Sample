using Sample.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Data
{
    public class InMemoryProjectData : IProjectData
    {
        List<Project> projects;

        public InMemoryProjectData()
        {
            projects = new List<Project>
            {
                new Project{Id=1, Name="FFARM", Description="Farm Financial Analysis and Risk Assessment System", Status=ProjectStatus.Complete},
                new Project{Id=2, Name="SportsPal", Description="Mobile app to connect Individuals to do sports together", Status=ProjectStatus.Complete},
                new Project{Id=3, Name="Planner", Description="Using knowledge from Project Management, create an efficient planner to order your life", Status=ProjectStatus.New}
            };
        }

        public IEnumerable<Project> GetProjectByName(string? name)
        {

            return from p in projects
                   where string.IsNullOrEmpty(name) || p.Name.ToLower().Contains(name.ToLower())
                   orderby p.Status
                   select p;
        }

        public Project getById(int Id)
        {
            return projects.SingleOrDefault(r => r.Id == Id);
        }

        public Project Update(Project updatedProject)
        {
            var project = projects.SingleOrDefault(r => r.Id == updatedProject.Id);
            if (project != null)
            {
                //project = updatedProject;
                project.Name = updatedProject.Name;
                project.Description = updatedProject.Description;
                project.Status = updatedProject.Status;
                project.StartDate = updatedProject.StartDate;
                project.EndDate = updatedProject.EndDate;
                project.GithubRepo = updatedProject.GithubRepo;
            }
            return project;
        }

        public int Commit()
        {
            return 0;
        }

        public Project Add(Project newProject)
        {
            projects.Add(newProject);
            newProject.Id = projects.Max(r => r.Id) + 1;
            return newProject;
        }

        public Project Delete(int Id)
        {
            var project = projects.FirstOrDefault(r => r.Id == Id);

            if (project != null)
            {
                projects.Remove(project);
            }

            return project;
        }

        public int GetCountOfProjects()
        {
            return projects.Count();
        }
    }
}
