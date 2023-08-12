using SharedModels.Enums;

namespace SharedModels.Models;

public class Timesheet
{
    public int WeekNumber { get; set; }
    public List<WeekDays> WeekDays { get; set; }
    public int[] WeekDates { get; set; }
    public List<Workday> Workdays { get; set; }
}
