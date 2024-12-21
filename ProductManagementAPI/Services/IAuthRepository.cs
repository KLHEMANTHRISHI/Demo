namespace ProductManagementAPI.Services
{
    public interface IAuthRepository
    {
        string Authenticate(string username, string password);
    }
}
