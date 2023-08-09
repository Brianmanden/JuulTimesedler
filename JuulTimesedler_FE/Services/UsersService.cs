using SharedModels.Models;

namespace JuulTimesedler_FE.Services;

public class UsersService
{
    public async Task<User> GetUser()
    {
        return new User { UserId = 10, UserName = "Wilfred Holm" };
    }
}