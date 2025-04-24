using SharedModels.Models;

namespace JuulTimesedler_FE.Services;

public class UsersService
{

	public async Task<User> GetUser()
	{
		await Task.Delay(1); // Simulate an asynchronous operation
		return new User { UserId = 10, UserName = "Wilfred Holm" };
	}

}