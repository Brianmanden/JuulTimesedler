namespace SharedModels.DTOs;

public class GetTimesheetDTO
{
    public int WeekNumber { get; set; }
    public string[] WeekDays { get; set; }
    public int[] WeekDates { get; set; }
}
