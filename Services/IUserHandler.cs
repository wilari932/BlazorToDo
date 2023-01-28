using BlazorAppz.Data;

namespace BlazorAppz.Services
{
    public interface IUserHandler
    {
        Task<CreateUser> CreateUser(CreateUser user);
        //Task<CreateUser> DeleteUser(CreateUser user);

        Task<IEnumerable<CreateUser>> GetAllUsersAsync();

        //CreateUser ChangeAccess(Guid id, Access access);

        Task<CreateUser> EditProfile(CreateUser user);

        Task<CreateUser> Authenticate(CreateUser user);
    }
}
