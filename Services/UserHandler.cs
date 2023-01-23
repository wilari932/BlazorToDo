using BlazorAppz.Data;
using BlazorAppz.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text;

namespace BlazorAppz
{
    public class UserHandler : IUserHandler
    {

        private readonly HttpClientWrapperService _httpClientWrapper;

        public UserHandler(HttpClientWrapperService client)
        {
            _httpClientWrapper = client;
        }

        //public CreateUser CreateUser(string FirstName, string LastName, string UserName, string Email, string Password)
        //{
        //    var user = new CreateUser()
        //    {
        //        Id = Guid.NewGuid(),
        //        FirstName = FirstName,
        //        LastName = LastName,
        //        UserName = UserName,
        //        Email = Email,
        //        Password = Password,
        //        Access = Access.User,
        //        ToDoList = new List<CreateToDoList>()
        //    };

        //    _dbContext.Add(user);
        //    _dbContext.SaveChanges();
        //    return user;
        //}


        //public void DeleteUser(Guid? id)
        //{
        //    var user = _dbContext.User.FirstOrDefault(x => x.Id == id);
        //    _dbContext.User.Remove(user);
        //    _dbContext.SaveChanges();
        //}

        //public CreateUser GetOneUser(Guid id)
        //{
        //    var user = _dbContext.User.FirstOrDefault(x => x.Id == id);
        //    return user;
        //}
        //public IEnumerable<CreateUser> GetUsers()
        //{
        //    return _dbContext.User.ToList();
        //}

        public async Task<IEnumerable<CreateUser>> GetAllUsersAsync()
        {
            var path = $"User/GetAllUsers";
            var result = await _httpClientWrapper.Get<IEnumerable<CreateUser>>(path);
            return result;

        }
        //public CreateUser EditProfile(Guid id, string? firstName, string? lastName, string? email, string? password)
        //{
        //    var user = _dbContext.User.FirstOrDefault(x => x.Id == id);
        //    user.FirstName = firstName == null ? user.FirstName : firstName;
        //    user.LastName = lastName == null ? user.LastName : lastName;
        //    user.Email = email == null ? user.Email : email;
        //    user.Password = password == null ? user.Password : password;
        //    _dbContext.SaveChanges();
        //    return user;
        //}


        public async Task<CreateUser> Authenticate(CreateUser user)
        {

            var path = $"User/LogIn";
            //var result = await _httpClientWrapper.Get<CreateUser>(path);
            //return result;
            var stringContent = JsonSerializer.Serialize(user);
            var data = new StringContent(stringContent, Encoding.UTF8, "application/json");
            return await _httpClientWrapper.PostAsync<CreateUser>(path, data);

            //var user = _dbContext.User.SingleOrDefault(x => x.UserName == username && x.Password == password);
            //return user;
        }

        //public CreateUser ChangeAccess(Guid id, Access access)
        //{
        //    var user = _dbContext.User.FirstOrDefault(x => x.Id == id);
        //    user.Access = access;
        //    _dbContext.SaveChanges();
        //    return user;
        //}




    }
}
