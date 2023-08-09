using SharedModels.Models;

namespace SharedModels.DTOs;

public class PutTimesheetDTO
{
    public int WorkerId { get; set; }
    public int WeekNumber { get; set; }
    public List<Workday>? Workdays { get; set; }
}