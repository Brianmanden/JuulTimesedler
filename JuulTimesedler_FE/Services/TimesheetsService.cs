using System.Net.Http.Json;
using SharedModels.DTOs;
using SharedModels.Models;

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

    public async Task<Timesheet> GetCurrentTimesheetWeek(int workerId)
    {
        return await _http.GetFromJsonAsync<Timesheet>($"{_getTimesheetCurrentWeekEndpoint}/{workerId}");
    }

    public async Task<Timesheet> GetTimesheetForWeekNumber(int weekNumber, int workerId)
    {
        return await _http.GetFromJsonAsync<Timesheet>($"{_getTimesheetForWeekEndpoint}/{weekNumber}/{workerId}");
    }

    public async Task PutCurrentTimesheetWeek(PutTimesheetDTO timesheetCurrentWeek)
    {
        CancellationToken cancellationToken = CancellationToken.None;
        await _http.PutAsJsonAsync(_putTimesheetsEndpoint, timesheetCurrentWeek, cancellationToken);
    }
}