using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Services;
using SharedModels.Models;
using SharedModels.DTOs;
using JuulTimesedler_BE.Interfaces;
using JuulTimesedler_BE.Services;

namespace JuulTimesedler_BE.Controllers;

[EnableCors("AllowAll")]
public class TimesheetController : Controller
{
	private IContentService _contentService;
	private ITimesheetService _timesheetService;
	private ITimeService _timeService;

	public TimesheetController(IContentService _contentService, ITimesheetService timesheetService, ITimeService timeService)
	{
		this._contentService = _contentService;
		_timesheetService = timesheetService;
		_timeService = timeService;
	}

	[HttpGet("api/gettimesheetcurrentweek/{WorkerId}")]
	public async Task<Timesheet> GetCurrentTimesheetWeek(int WorkerId)
	{
		Timesheet timesheetWeek = await Task.Run(() => _timesheetService.GetTimesheetForCurrentWeek(WorkerId));
		if (timesheetWeek is null)
		{
			return new Timesheet();
		}

		return timesheetWeek;
	}

	[HttpGet("api/gettimesheetforweek/{WeekNumber}/{WorkerId}")]
	public async Task<Timesheet> GetTimesheetByWeekNumber(int WeekNumber, int WorkerId)
	{
		Timesheet timesheet = await Task.Run(() => _timesheetService.GetTimesheetByWeekNumber(WeekNumber, WorkerId));
		if (timesheet is null)
		{
			return new Timesheet();
		}

		return timesheet;
	}

	[HttpPut("api/puttimesheetweek")]
	public async Task<PutTimesheetDTO> PutTimesheet([FromBody] PutTimesheetDTO weekTimesheet)
	{
		TimeService timeService = new();
		string formattedYearAndWeek = await Task.Run(() => timeService.FormattedCurrentYearAndWeek());

		// TODO BJA - Check for workdays, maybe refactor into service ?

		//var currentProject = _contentService.GetById(timesheet.SelectedProjectId);
		////currentProject.SetValue("fullName", "new fullname value");
		//currentProject.SetValue("fullName", formattedYearAndWeek + " - new fullname value");
		//currentProject.SetValue("address", "new address value");

		//_contentService.SaveAndPublish(currentProject);
		return weekTimesheet;
	}
}