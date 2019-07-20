using Taspin.Api.Services.Dtos;

namespace Taspin.Api.Services
{
    public interface IUserService
    {
        User Get(string userName);
    }
}
