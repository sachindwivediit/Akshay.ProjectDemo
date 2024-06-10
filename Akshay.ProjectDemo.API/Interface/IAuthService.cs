using Akshay.ProjectDemo.API.RequestModfels;
using Akshay.ProjectDemo.Entities;

namespace Akshay.ProjectDemo.API.Interface
{
    public interface IAuthService
    {
        User AddUser(User user);

        string Login(LoginRequest loginRequest);
    }
}
