using System.Net.Http.Json;
using SharedModels.DTOs;

namespace JuulTimesedler_FE.Services;

public class TimesheetsService
{
    private HttpClient _http;
    private const string _baseUri = "https://localhost:44388/api";
    private const string _getTimesheetCurrentWeekEndpoint = _baseUri + "/gettimesheetcurrentweek";
    private const string _getTimesheetForWeekEndpoint = _baseUri + "/gettimesheetforweek";
    private const string _putTimesheetsEndpoint = _baseUri + "/puttimesheetweek";

    public TimesheetsService(HttpClient http)
    {
        _http = http;
    }

    public async Task<GetTimesheetDTO> GetCurrentTimesheetWeek(int workerId)
    {
        return await _http.GetFromJsonAsync<GetTimesheetDTO>($"{_getTimesheetCurrentWeekEndpoint}/{workerId}");
    }

    public async Task<GetTimesheetDTO> GetTimesheetForWeekNumber(int weekNumber, int workerId)
    {
        //[HttpGet("api/gettimesheetforweek/{weekNumber}/{workerId}")]
        var tmp = $"{_getTimesheetForWeekEndpoint}/{weekNumber}/{workerId}";
        return await _http.GetFromJsonAsync<GetTimesheetDTO>($"{_getTimesheetForWeekEndpoint}/{weekNumber}/{workerId}");
    }

    public async Task PutCurrentTimesheetWeek(PutTimesheetDTO timesheetCurrentWeek)
    {
        CancellationToken cancellationToken = CancellationToken.None;
        await _http.PutAsJsonAsync(_putTimesheetsEndpoint, timesheetCurrentWeek, cancellationToken);
    }
}