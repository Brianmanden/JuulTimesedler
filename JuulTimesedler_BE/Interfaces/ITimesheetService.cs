using SharedModels.Models;

namespace JuulTimesedler_BE.Interfaces;

public interface ITimesheetService
{
    public Timesheet GetTimesheetForCurrentWeek(int workerId);

    public Timesheet GetTimesheetByWeekNumber(int weekNumber, int workerId);
}
