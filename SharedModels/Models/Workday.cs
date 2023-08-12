using SharedModels.Enums;

namespace SharedModels.Models;

public class Workday
{
    public WeekDays WeekDay { get; set; }
    public int WeekDate { get; set; }
    public int? SelectedProjectId { get; set; }
    public HashSet<string>? SelectedTasks { get; set; }
    public TimeSpan? StartTime { get; set; }
    public TimeSpan? EndTime { get; set; }
    public string? WorkdayComments { get; set; }
}