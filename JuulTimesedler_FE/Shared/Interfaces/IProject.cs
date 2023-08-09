using SharedModels.DTOs;

namespace JuulTimesedler_FE.Shared;

public interface IProjectInterface
{
    Task<IEnumerable<GetProjectDTO>> GetProjects(HttpClient httpClient, string uri);
}
