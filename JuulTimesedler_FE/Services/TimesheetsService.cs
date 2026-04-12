using System.Net.Http.Json;
using SharedModels.DTOs;
using SharedModels.Models;

namespace JuulTimesedler_FE.Services;

public class TimesheetsService
{
    private HttpClient _http;
    private const string _getTimesheetCurrentWeekEndpoint = "api/gettimesheetcurrentweek";
    private const string _getTimesheetForWeekEndpoint = "api/gettimesheetforweek";
    private const string _putTimesheetsEndpoint = "api/puttimesheetweek";

    public TimesheetsService(HttpClient http)
    {
        _http = http;
    }

    public async Task<Timesheet> GetCurrentTimesheetWeek(int workerId)
    {
        return await _http.GetFromJsonAsync<Timesheet>($"{_getTimesheetCurrentWeekEndpoint}/{workerId}") ?? new Timesheet();
    }

    public async Task<Timesheet> GetTimesheetForWeekNumber(int weekNumber, int workerId)
    {
        return await _http.GetFromJsonAsync<Timesheet>($"{_getTimesheetForWeekEndpoint}/{weekNumber}/{workerId}") ?? new Timesheet();
    }

    public async Task PutCurrentTimesheetWeek(PutTimesheetDTO timesheetCurrentWeek)
    {
        var response = await _http.PutAsJsonAsync(_putTimesheetsEndpoint, timesheetCurrentWeek);
        response.EnsureSuccessStatusCode();
    }
}