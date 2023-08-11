using SharedModels.DTOs;
using JuulTimesedler_BE.Interfaces;
using SharedModels.Enums;

namespace JuulTimesedler_BE.Services;

public class TimesheetService : ITimesheetService
{
    private ITimeService _timeService;
    public TimesheetService(ITimeService timeService)
    {
        _timeService = timeService;
    }

    public Timesheet GetTimesheetByWeekNumber(int weekNumber, int workerId)
    {
        int internalWeekNumber = weekNumber;
        List<Timesheet> demoTimesheets = new List<Timesheet>();

        Timesheet demoTimesheet1 = GetTimesheetForCurrentWeek(workerId);
        demoTimesheet1.WeekNumber = internalWeekNumber;
        demoTimesheets.Add(demoTimesheet1);

        Timesheet demoTimesheet2 = GetTimesheetForCurrentWeek(workerId);
        demoTimesheet2.WeekNumber = internalWeekNumber - 1;
        demoTimesheets.Add(demoTimesheet2);

        Timesheet demoTimesheet3 = GetTimesheetForCurrentWeek(workerId);
        demoTimesheet3.WeekNumber = internalWeekNumber - 2;
        demoTimesheets.Add(demoTimesheet3);

        var result = demoTimesheets.Where(sheet => sheet.WeekNumber == weekNumber).SingleOrDefault();

        return result;
    }

    public Timesheet GetTimesheetForCurrentWeek(int workerId)
    {
        //TODO: Should fetch timesheet from persistance layer (Umb DB)
        int weekNumber = _timeService.GetCurrentWeekNumber();
        Timesheet currentTimesheetWeek = new();
        currentTimesheetWeek.WeekNumber = weekNumber;

        currentTimesheetWeek.WeekDays = Enum.GetValues(typeof(WeekDays)).Cast<WeekDays>().ToList();

        currentTimesheetWeek.WeekDates = _timeService.GetCurrentWeekDates(weekNumber);

        return currentTimesheetWeek;
    }
}