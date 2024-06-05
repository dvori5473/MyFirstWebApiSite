using Entities;
using MyFirstWebApiSite;
using Repositories; 
using Zxcvbn;
namespace Services
{

    public class UserService : IUserService
    {



        //UserRepository userRepositories = new UserRepository();
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetById(int id)
        {

            return await _userRepository.GetById(id);
        }
        public async Task<User> Login(User userLogin)
        {

            return await _userRepository.Login(userLogin);
        }
        public int CheckPassword(string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;
        }
        public async Task<User> Register(User user)
        {
            if (CheckPassword(user.Password) > 1)
                return await _userRepository.Register(user);
            return null;

        }
        public async Task<User> UpdateUser(int id, User user)
        {

            if (CheckPassword(user.Password) > 1)
                return await _userRepository.UpdateUser(id, user);
            return null;
        }

       
    }
}
