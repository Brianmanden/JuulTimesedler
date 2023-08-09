using SharedModels.DTOs;

namespace JuulTimesedler_BE.Interfaces;

public interface ITimesheetService
{
    public GetTimesheetDTO GetTimesheetForCurrentWeek(int workerId);

    public GetTimesheetDTO GetTimesheetByWeekNumber(int weekNumber, int workerId);
}
