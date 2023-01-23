using BlazorAppz.Data;

namespace BlazorAppz
{
    public interface IUserHandler
    {
        //CreateUser CreateUser(string FirstName, string LastName, string UserName, string Email, string Password);
        //void DeleteUser(Guid? id);
        //CreateUser GetOneUser(Guid id);
        Task<IEnumerable<CreateUser>> GetAllUsersAsync();

        //CreateUser ChangeAccess(Guid id, Access access);

        //CreateUser EditProfile(Guid id, string? firstName, string? lastName, string? email, string? password);

        Task<CreateUser> Authenticate(CreateUser user);
    }
}
