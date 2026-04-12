using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common;
using SharedModels.DTOs;

namespace JuulTimesedler_BE.Controllers;

[EnableCors("AllowAll")]
public class ProjectController : Controller
{
    private readonly UmbracoHelper _umbracoHelper;

    public ProjectController(UmbracoHelper umbracoHelper)
    {
        _umbracoHelper = umbracoHelper;
    }
        
    [HttpGet("api/projects")]
	public async Task<List<GetProjectDTO>> GetCurrentProjects()
	{
		IPublishedContent? rootNode = await Task.Run(() => _umbracoHelper.ContentAtRoot().FirstOrDefault());
		if (rootNode == null)
		{
			return GetDemoProjects();
		}

		IEnumerable<IPublishedContent> projects = await Task.Run(() => rootNode.Children().DescendantsOrSelfOfType("project").ToList());

		if (!projects.Any())
		{
			return GetDemoProjects();
		}

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

	private List<GetProjectDTO> GetDemoProjects()
	{
		return new List<GetProjectDTO>
		{
			new GetProjectDTO { ProjectId = 1113, ProjectName = "Demo Project Alpha", ProjectFullName = "Demo Project Alpha - Full Name" },
			new GetProjectDTO { ProjectId = 1104, ProjectName = "Demo Project Beta", ProjectFullName = "Demo Project Beta - Full Name" },
			new GetProjectDTO { ProjectId = 1234, ProjectName = "Internal Work", ProjectFullName = "Internal Work - Admin" }
		};
	}
}
