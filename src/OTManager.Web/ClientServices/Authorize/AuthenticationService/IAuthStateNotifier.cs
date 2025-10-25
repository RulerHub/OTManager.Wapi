namespace OTManager.Web.ClientServices.Authorize.AuthenticationService
{
    public interface IAuthStateNotifier
    {
        void NotifyUserAuthentication(string token);
        void NotifyUserLogout();
    }
}
