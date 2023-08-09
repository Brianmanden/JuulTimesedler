using SharedModels.DTOs;
using JuulTimesedler_BE.Interfaces;

namespace JuulTimesedler_BE.Services;

public class TimesheetService : ITimesheetService
{
    private ITimeService _timeService;
    public TimesheetService(ITimeService timeService)
    {
        _timeService = timeService;
    }

    public GetTimesheetDTO GetTimesheetByWeekNumber(int weekNumber, int workerId)
    {
        int internalWeekNumber = weekNumber;
        List<GetTimesheetDTO> demoTimesheets = new List<GetTimesheetDTO>();

        GetTimesheetDTO demoTimesheet1 = GetTimesheetForCurrentWeek(workerId);
        demoTimesheet1.WeekNumber = internalWeekNumber;
        demoTimesheets.Add(demoTimesheet1);

        GetTimesheetDTO demoTimesheet2 = GetTimesheetForCurrentWeek(workerId);
        demoTimesheet2.WeekNumber = internalWeekNumber - 1;
        demoTimesheets.Add(demoTimesheet2);

        GetTimesheetDTO demoTimesheet3 = GetTimesheetForCurrentWeek(workerId);
        demoTimesheet3.WeekNumber = internalWeekNumber - 2;
        demoTimesheets.Add(demoTimesheet3);

        var result = demoTimesheets.Where(sheet => sheet.WeekNumber == weekNumber).SingleOrDefault();

        return result;
    }

    public GetTimesheetDTO GetTimesheetForCurrentWeek(int workerId)
    {
        //TODO: Should fetch timesheet from persistance layer (Umb DB)
        int weekNumber = _timeService.GetCurrentWeekNumber();
        GetTimesheetDTO currentTimesheetWeek = new();
        currentTimesheetWeek.WeekNumber = weekNumber;
        currentTimesheetWeek.WeekDays = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        currentTimesheetWeek.WeekDates = _timeService.GetCurrentWeekDates(weekNumber);

        return currentTimesheetWeek;
    }
}