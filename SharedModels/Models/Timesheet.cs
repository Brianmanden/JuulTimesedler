using SharedModels.Enums;

namespace SharedModels.DTOs;

public class Timesheet
{
    public int WeekNumber { get; set; }
    public List<WeekDays> WeekDays { get; set; }
    public int[] WeekDates { get; set; }
}
