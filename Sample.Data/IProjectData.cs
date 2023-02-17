using Sample.Core;

namespace Sample.Data
{
    public interface IProjectData
    {
        IEnumerable<Project> GetProjectByName(string name);
        Project getById(int Id);
        Project Update(Project updatedProject);
        Project Add(Project newProject);
        Project Delete(int Id);

        int GetCountOfProjects();
        int Commit();
    }
}