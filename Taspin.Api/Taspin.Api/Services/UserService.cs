using Taspin.Api.Services.Dtos;
using Taspin.Data.Dac;

namespace Taspin.Api.Services
{
    public class UserService : IUserService
    {
        private readonly UsersDac _dac;

        public UserService(UsersDac dac)
        {
            _dac = dac;
        }

        public User Get(string userName)
        {
            var model = _dac.SelectUser(userName);

            return new User
            {
                //Email = model.Email,
                Id = model.user_id,
                //Name = model.Name,
                //Password = model.Password,
                //Surname = model.Surname,
                Username = model.username
            };
        }
    }
}
