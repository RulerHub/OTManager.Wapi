namespace OTManager.Web.ClientServices.Clients;

public class ClientService(HttpClient httpClient)
{
    private readonly HttpClient _httpClient = httpClient;
}
