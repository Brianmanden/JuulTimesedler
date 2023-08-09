namespace SharedModels.Models;

public class Workday
{
    public int WeekDay { get; set; }
    public int? SelectedProjectId { get; set; }
    public HashSet<string>? SelectedTasks { get; set; }
    public string? StartTime { get; set; }
    public string? EndTime { get; set; }
    public string? WorkdayComments { get; set; }
}