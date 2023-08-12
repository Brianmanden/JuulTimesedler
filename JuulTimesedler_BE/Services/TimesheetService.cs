using SharedModels.Models;
using JuulTimesedler_BE.Interfaces;
using SharedModels.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
        int[] weekDates = _timeService.GetCurrentWeekDates(weekNumber);

        Timesheet currentTimesheetWeek = new();
        currentTimesheetWeek.WeekNumber = weekNumber;
        currentTimesheetWeek.WeekDays = Enum.GetValues(typeof(WeekDays)).Cast<WeekDays>().ToList();
        currentTimesheetWeek.WeekDates = weekDates;

        currentTimesheetWeek.Workdays = new List<Workday>
        {
            //DEMO WORKDAYS
            new Workday
            {
                WeekDay = WeekDays.Monday,
                WeekDate = weekDates[0],
                SelectedProjectId = 1113,
                WorkdayComments = "test 1",
                StartTime = new TimeSpan(7, 45, 0),
                EndTime = new TimeSpan(16, 15, 0),
            },
            new Workday
            {
                WeekDay = WeekDays.Tuesday,
                WeekDate = weekDates[1],
                SelectedProjectId = 1104,
                WorkdayComments = "test 2",
                StartTime = new TimeSpan(8, 0, 0),
                EndTime = new TimeSpan(15, 45, 0),
            },
            new Workday
            {
                WeekDay = WeekDays.Wednesday,
                WeekDate = weekDates[2],
                SelectedProjectId = 1113,
                WorkdayComments = "test 3",
                StartTime = new TimeSpan(),
                EndTime = new TimeSpan(),
            },
            new Workday
            {
                WeekDay = WeekDays.Thursday,
                WeekDate = weekDates[3],
                SelectedProjectId = 1104,
                WorkdayComments = "test 4",
                StartTime = new TimeSpan(),
                EndTime = new TimeSpan(),
            },
            new Workday
            {
                WeekDay = WeekDays.Friday,
                WeekDate = weekDates[4],
                SelectedProjectId = 1113,
                WorkdayComments = "test 5",
                StartTime = new TimeSpan(),
                EndTime = new TimeSpan(),
            },
            new Workday
            {
                WeekDay = WeekDays.Sunday,
                WeekDate = weekDates[5],
                SelectedProjectId = 1104,
                WorkdayComments = "test 6",
                StartTime = new TimeSpan(),
                EndTime = new TimeSpan(),
            },
            new Workday
            {
                WeekDay = WeekDays.Sunday,
                WeekDate = weekDates[6],
                SelectedProjectId = 1113,
                WorkdayComments = "test 7",
                StartTime = new TimeSpan(),
                EndTime = new TimeSpan(),
            },
        };

        return currentTimesheetWeek;
    }
}