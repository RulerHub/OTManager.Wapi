using OTManager.Core.QueryParams;
using OTManager.Web.ClientServices.Materials.Records;

namespace OTManager.Web.ClientServices.Materials;

public class MaterialService(HttpClient httpClient)
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<List<MaterialReadDto>> GetFilteredAsync(MaterialQueryParams materialQuery)
    {
        var result = await _httpClient.PostAsJsonAsync($"material/filter", materialQuery);
        //var response = await _httpClient.GetFromJsonAsync<List<MaterialReadDto>>($"material");

        List<MaterialReadDto>? materials = [];

        if (result.IsSuccessStatusCode)
        {
            materials = await result.Content.ReadFromJsonAsync<List<MaterialReadDto>>();
        }

        return materials!;
    }
    public async Task<MaterialReadDto> GetByIdAsync(string id)
    {
        var response = await _httpClient.GetFromJsonAsync<MaterialReadDto>($"material/{id}");
        return response!;
    }
}
