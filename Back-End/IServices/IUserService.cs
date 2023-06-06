using Back_End.Models;

namespace Back_End.IServices
{
    public interface IUserService
    {
        Task ActivateUser(int id);
        Task AddActivatedAccount(ActivatedUser user);
        Task DeleteActivatedAccount(int id);
        Task<ActivatedUser> GetActivatedUser(string url);
        Task<User> GetUser(int userId);
        
        Task RegisterUser(User user, ActivatedUser activatedUser);
        Task<bool> VerifyUserActivated(int id);
    }
}
