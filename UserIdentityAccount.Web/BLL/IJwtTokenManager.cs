namespace UserIdentityAccount.Web.BLL;

public interface IJwtTokenManager
{
    string Authenticate(string userName, string password);
}