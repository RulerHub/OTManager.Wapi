using OTManager.Web.ClientServices.DTOs.Identity;

namespace OTManager.Web.ClientServices.Authorize;

public class UserService(HttpClient httpClient)
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<IQueryable<UserReadDto>> GetAll()
    {
        var users = await _httpClient.GetFromJsonAsync<List<UserReadDto>>("user");
        return users!.AsQueryable();
    }
}
