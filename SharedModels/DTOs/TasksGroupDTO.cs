﻿namespace SharedModels.DTOs;

public class TasksGroupDTO
{
    public string TaskGroupName { get; set; }
    public List<string> TaskNames { get; set; } = new List<string>();
}
