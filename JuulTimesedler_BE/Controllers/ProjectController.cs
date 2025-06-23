using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common;
using SharedModels.DTOs;

namespace JuulTimesedler_BE.Controllers;

public class ProjectController : Controller
{
    private readonly UmbracoHelper _umbracoHelper;

    public ProjectController(UmbracoHelper umbracoHelper)
    {
        _umbracoHelper = umbracoHelper;
    }
        
    [HttpGet("api/projects/")]
	public async Task<List<GetProjectDTO>> GetCurrentProjects()
	{
		IPublishedContent? rootNode = await Task.Run(() => _umbracoHelper.ContentAtRoot().FirstOrDefault());
		if (rootNode == null)
		{
			return new List<GetProjectDTO>();
		}

		IEnumerable<IPublishedContent> projects = await Task.Run(() => rootNode.Children().DescendantsOrSelfOfType("project").ToList());

		List<GetProjectDTO> allProjectsList = new();

		foreach (var project in projects)
		{
			allProjectsList.Add(new GetProjectDTO
			{
				ProjectId = project.Id,
				ProjectName = project.Name,
				ProjectFullName = project.Value("fullName")?.ToString(),
			});
		}

		return allProjectsList;
	}
}
