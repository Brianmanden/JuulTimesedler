# Umbraco 13+ Patterns for JuulTimesedler

## 1. UmbracoApiController (REST API)
Use this for building headless or internal APIs for the Blazor front-end.

```csharp
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.Controllers;

namespace JuulTimesedler_BE.Controllers
{
    public class ProjectController : UmbracoApiController
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public IActionResult GetAllProjects()
        {
            var projects = _projectService.GetActiveProjects();
            return Ok(projects);
        }
    }
}
```

## 2. Using IContentService (Write Operations)
For programmatic content management (e.g., creating a new timesheet entry).

```csharp
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Models;

public void CreateTimesheetEntry(int parentId, TimesheetDto dto)
{
    var content = _contentService.Create(dto.Name, parentId, "timesheetEntry");
    content.SetValue("workDate", dto.Date);
    content.SetValue("hoursWorked", dto.Hours);
    
    _contentService.SaveAndPublish(content);
}
```

## 3. Querying with IPublishedContentQuery (Read Operations)
Optimized for performance using the content cache.

```csharp
using Umbraco.Cms.Web.Common;

public class MyService {
    private readonly UmbracoHelper _umbracoHelper;

    public MyService(UmbracoHelper umbracoHelper) {
        _umbracoHelper = umbracoHelper;
    }

    public IEnumerable<IPublishedContent> GetProjects() {
        var root = _umbracoHelper.ContentAtRoot().FirstOrDefault();
        return root?.Children(x => x.ContentType.Alias == "project") ?? Enumerable.Empty<IPublishedContent>();
    }
}
```

## 4. ModelsBuilder (Strongly-Typed)
Ensure the `appsettings.json` is configured correctly for ModelsBuilder to enable strongly-typed model usage.

```json
"Umbraco": {
  "Cms": {
    "ModelsBuilder": {
      "ModelsMode": "InMemoryAuto",
      "AcceptUnsafeModelsDirectory": true
    }
  }
}
```
