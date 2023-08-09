using Umbraco.Cms.Core.Services;
using JuulTimesedler_BE.Interfaces;

namespace JuulTimesedler_BE.Services;

public class WorkersService : IWorkersService
{
    private IUserService _userService;
    private IContentService _contentService;

    public WorkersService(IUserService userService, IContentService contentService)
    {
        _userService = userService;
        _contentService = contentService;
    }

    public string GetWorkerKey(int workerId)
    {
        string parsedWorkerKey = _contentService.GetById(workerId)?.Key.ToString().Replace("-", "");
        return parsedWorkerKey;
    }
}
