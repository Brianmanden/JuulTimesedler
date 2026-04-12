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
        return GenerateTimesheet(weekNumber, workerId);
    }

    public Timesheet GetTimesheetForCurrentWeek(int workerId)
    {
        int weekNumber = _timeService.GetCurrentWeekNumber();
        return GenerateTimesheet(weekNumber, workerId);
    }

    private Timesheet GenerateTimesheet(int weekNumber, int workerId)
    {
        //TODO: Should fetch timesheet from persistance layer (Umb DB)
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
                SelectedTasks = new HashSet<string>(),
                WorkdayComments = "test 1",
                StartTime = new TimeSpan(7, 45, 0),
                EndTime = new TimeSpan(16, 15, 0),
            },
            new Workday
            {
                WeekDay = WeekDays.Tuesday,
                WeekDate = weekDates[1],
                SelectedProjectId = 1104,
                SelectedTasks = new HashSet<string>(),
                WorkdayComments = "test 2",
                StartTime = new TimeSpan(8, 0, 0),
                EndTime = new TimeSpan(15, 45, 0),
            },
            new Workday
            {
                WeekDay = WeekDays.Wednesday,
                WeekDate = weekDates[2],
                SelectedProjectId = 1113,
                SelectedTasks = new HashSet<string>(),
                WorkdayComments = "test 3",
                StartTime = new TimeSpan(),
                EndTime = new TimeSpan(),
            },
            new Workday
            {
                WeekDay = WeekDays.Thursday,
                WeekDate = weekDates[3],
                SelectedProjectId = 1104,
                SelectedTasks = new HashSet<string>(),
                WorkdayComments = "test 4",
                StartTime = new TimeSpan(),
                EndTime = new TimeSpan(),
            },
            new Workday
            {
                WeekDay = WeekDays.Friday,
                WeekDate = weekDates[4],
                SelectedProjectId = 1113,
                SelectedTasks = new HashSet<string>(),
                WorkdayComments = "test 5",
                StartTime = new TimeSpan(),
                EndTime = new TimeSpan(),
            },
            new Workday
            {
                WeekDay = WeekDays.Saturday,
                WeekDate = weekDates[5],
                SelectedProjectId = 1104,
                SelectedTasks = new HashSet<string>(),
                WorkdayComments = "test 6",
                StartTime = new TimeSpan(),
                EndTime = new TimeSpan(),
            },
            new Workday
            {
                WeekDay = WeekDays.Sunday,
                WeekDate = weekDates[6],
                SelectedProjectId = 1113,
                SelectedTasks = new HashSet<string>(),
                WorkdayComments = "test 7",
                StartTime = new TimeSpan(),
                EndTime = new TimeSpan(),
            },
        };

        return currentTimesheetWeek;
    }
}