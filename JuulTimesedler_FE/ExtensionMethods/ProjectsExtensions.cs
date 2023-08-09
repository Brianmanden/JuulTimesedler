using SharedModels.DTOs;

namespace JuulTimesedler_FE.ExtensionMethods;

public static class ProjectsExtensions
{
    public static List<string> GetProjectNames(this GetProjectDTO[]? projects)
    {
        return projects.Select(project => project.ProjectName).ToList();
    }
}
