using System.Net.Http.Json;
using SharedModels.DTOs;

namespace JuulTimesedler_FE.Services;

public class ProjectsService
{
    private HttpClient _http;
    private const string _baseUri = "https://localhost:44388/api";
    private const string _projectsEndpoint = _baseUri + "/projects";

    public ProjectsService(HttpClient http)
    {
        _http = http;
    }

    public async Task<GetProjectDTO[]> GetProjects()
    {
        return await _http.GetFromJsonAsync<GetProjectDTO[]>(_projectsEndpoint);
    }
}
