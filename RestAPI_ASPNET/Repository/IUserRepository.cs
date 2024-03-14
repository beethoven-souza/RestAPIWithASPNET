using RestAPI_ASPNET.Data.VO;
using RestAPI_ASPNET.Model;

namespace RestAPI_ASPNET.Repository
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user); 
    }
}
