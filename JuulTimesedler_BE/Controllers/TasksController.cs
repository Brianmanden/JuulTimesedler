﻿using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.Common;
using SharedModels.DTOs;

namespace JuulTimesedler_BE.Controllers;

public class TasksController : Controller
{
    private readonly UmbracoHelper _umbracoHelper;
    private IContentService _contentService;

    public TasksController(UmbracoHelper umbracoHelper, IContentService contentService)
    {
        _umbracoHelper = umbracoHelper;
        _contentService = contentService;
    }

    [HttpGet("api/tasks/")]
    public async Task<List<TasksGroupDTO>> GetAllTasks()
    {
        List<TasksGroupDTO> groupedTasks = new List<TasksGroupDTO>();

        IPublishedContent? rootNode = await Task.Run(() => _umbracoHelper.ContentAtRoot().DescendantsOrSelfOfType("tasks").FirstOrDefault());
        if (rootNode == null)
        {
            return new List<TasksGroupDTO>();
        }


        IList<IPublishedContent> tasksGroup = await Task.Run(() => rootNode.Children().DescendantsOrSelfOfType("tasksGroup").ToList());

        if (tasksGroup.Count < 1) {
            return groupedTasks;
        }

        foreach (var taskGroup in tasksGroup) {
            var currentTaskGroup = new TasksGroupDTO();

            currentTaskGroup.TaskGroupName = taskGroup.Name!;

            foreach (string taskName in taskGroup.GetProperty("TaskList").GetValue().ToString().Split("\n"))
            {
                currentTaskGroup.TaskNames.Add(taskName);
            }

            groupedTasks.Add(currentTaskGroup);
        }

        return groupedTasks;
    }
}
