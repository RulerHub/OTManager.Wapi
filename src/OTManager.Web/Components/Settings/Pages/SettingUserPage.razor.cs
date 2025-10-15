namespace OTManager.Web.Components.Settings.Pages;

public partial class SettingUserPage
{
    public IQueryable<string>? users;

    protected override async Task OnInitializedAsync()
    {
        // Simulate asynchronous loading to demonstrate a loading indicator
        await Task.Delay(500);
        GetAll();

    }

    private void GetAll()
    {
        //var response = await _user.Users.ToListAsync();
        //if (response is not null) users = response.AsQueryable();
    }
}
