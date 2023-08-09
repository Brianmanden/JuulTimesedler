using System.Net.Http.Json;
using SharedModels.DTOs;

namespace JuulTimesedler_FE.Services;

public class TasksService
{
    private HttpClient _http;
    private const string _baseUri = "https://localhost:44388/api";
    private const string _tasksEndpoint = _baseUri + "/tasks";

    public TasksService(HttpClient http)
    {
        _http = http;
    }

    public async Task<TasksGroupDTO[]> GetTasks()
    {
        return await _http.GetFromJsonAsync<TasksGroupDTO[]>(_tasksEndpoint);
    }
}
