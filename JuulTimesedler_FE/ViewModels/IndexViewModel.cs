using SharedModels.Enums;
using SharedModels.Models;
using SharedModels.DTOs;
using JuulTimesedler_FE.Services;

namespace JuulTimesedler_FE.ViewModels;

public class IndexViewModel
{
    private UsersService _userService;
    private ProjectsService _projectsService;
    private TasksService _tasksService;
    private TimesheetsService _timesheetsService;

    public User User { get; set; }

    public int ActiveDayIndex = 0;

    public GetProjectDTO[]? Projects;
    public GetProjectDTO SelectedProject { get; set; }
    public TasksGroupDTO[]? GroupedTasks;
    public HashSet<string> SelectedTasks { get; set; }
    public string? Comments { get; set; }

    public string? TasksSearchText { get; set; }
    public Timesheet Timesheet { get; set; }
    public TimeSpan? StartingTime { get; set; } // = new TimeSpan(02, 35, 00);
    public TimeSpan? EndingTime { get; set; } // = new TimeSpan(02, 35, 00);

    public IndexViewModel(UsersService usersService, ProjectsService projectsService, TasksService tasksService, TimesheetsService timesheetsService)
    {
        _userService = usersService;
        _projectsService = projectsService;
        _tasksService = tasksService;
        _timesheetsService = timesheetsService;
    }

    public async Task ClearProject() { SelectedProject = null; }

    public async Task<IEnumerable<GetProjectDTO>> ChooseProject(string project)
    {
        if (string.IsNullOrEmpty(project))
        {
            return Projects;
        }
        return Projects.Where(p => p.ProjectName.Contains(project, StringComparison.InvariantCultureIgnoreCase));
    }

    public async void GetTimesheetPrevWeek()
    {
        int localPrevWeek = Timesheet.WeekNumber - 1;
        Timesheet = await _timesheetsService.GetTimesheetForWeekNumber(localPrevWeek, User.UserId);
    }

    public async void GetTimesheetNextWeek()
    {
        int localNextWeek = Timesheet.WeekNumber + 1;
        Timesheet = await _timesheetsService.GetTimesheetForWeekNumber(localNextWeek, User.UserId);
    }

    public async Task SendForm()
    {
        PutTimesheetDTO currentWeekTimesheet = new PutTimesheetDTO();
        currentWeekTimesheet.WorkerId = User.UserId;
        currentWeekTimesheet.WeekNumber = Timesheet.WeekNumber;

        List<Workday> workDays = new List<Workday>
        {
            new Workday
            {
                SelectedProjectId = SelectedProject?.ProjectId ?? null,
                StartTime = StartingTime ?? new TimeSpan(),
                EndTime = EndingTime ?? new TimeSpan(),
                WorkdayComments = Comments,
                SelectedTasks = SelectedTasks,
                WeekDay = WeekDays.Wednesday,
                WeekDate = 9,
            },
            new Workday
            {
                SelectedProjectId = SelectedProject?.ProjectId ?? null,
                StartTime = StartingTime ?? new TimeSpan(),
                EndTime = EndingTime ?? new TimeSpan(),
                WorkdayComments = Comments,
                SelectedTasks = SelectedTasks,
                WeekDay = WeekDays.Thursday,
                WeekDate = 10,
            },
        };

        foreach (Workday workday in Timesheet.Workdays)
        {
            workDays.Add(workday);
        }

        currentWeekTimesheet.Workdays = workDays;

        await _timesheetsService.PutCurrentTimesheetWeek(currentWeekTimesheet);
    }

    public string FormattedWeekDate(int i)
    {
        string shortFormattedWeekdate = $"{Timesheet.WeekDays[i].ToString().Substring(0, 3)}-{Timesheet.WeekDates[i]}.";
        string fullFormattedWeekdate = $"{Timesheet.WeekDays[i]} - {Timesheet.WeekDates[i]}";

        return shortFormattedWeekdate;
        //return fullFormattedWeekdate;
    }

    public async Task Initialize()
    {
        User = await _userService.GetUser();
        Projects = await _projectsService.GetProjects();
        GroupedTasks = await _tasksService.GetTasks();
        Timesheet = await _timesheetsService.GetCurrentTimesheetWeek(User.UserId);
    }

}