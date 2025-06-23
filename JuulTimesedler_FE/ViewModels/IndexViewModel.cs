using JuulTimesedler_FE.Services;

using SharedModels.DTOs;
using SharedModels.Enums;
using SharedModels.Models;

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

		// Initialize non-nullable properties with default values
		User = new User(){ UserId = 123, UserName = "John Doe"};
		SelectedProject = new GetProjectDTO();
		SelectedTasks = new HashSet<string>();
		Timesheet = new Timesheet();
	}

	public async Task ClearProject() {
		await Task.Run(() => SelectedProject = null!);
	}

	public async Task<IEnumerable<GetProjectDTO>> ChooseProject(string project)
	{
		if (!string.IsNullOrEmpty(project))
		{
			return await Task.Run(()=> Projects!.Where(p => p.ProjectName!.Contains(project, StringComparison.InvariantCultureIgnoreCase)));
		}

		return Projects!;
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
		using var cts = new CancellationTokenSource();
		CancellationToken token = cts.Token;

		#region USER
		try
		{
			User = await _userService.GetUser();
			Console.WriteLine("Fetched User.");
		}
		catch (Exception ex)
		{
			Console.WriteLine($"USER: {ex.GetBaseException().Message}");
		}
		#endregion

		#region PROJECTS 
		try
		{
			Projects = await _projectsService.GetProjects();
			Console.WriteLine("Fetched Projects.");
		}
		catch (Exception ex)
		{
			Console.WriteLine($"PROJECTS: {ex.GetBaseException().Message}");
		}
		#endregion

		#region TASKS
		try
		{
			GroupedTasks = await _tasksService.GetTasks();
			Console.WriteLine("Fetched Grouped Tasks.");
		}
		catch (Exception ex)
		{
			Console.WriteLine($"GROUPED TASKS: {ex.GetBaseException().Message}");
		}
		#endregion

		#region TIMESHEET
		try
		{
			Timesheet = await _timesheetsService.GetCurrentTimesheetWeek(User.UserId);
			Console.WriteLine("Fetched Timesheet.");
		}
		catch (Exception ex)
		{
			Console.WriteLine($"TIMESHEET: {ex.GetBaseException().Message}");
		}
		#endregion
	}
}