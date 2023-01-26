using BlazorAppz.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text;
using static System.Net.WebRequestMethods;

namespace BlazorAppz.Services
{
    public class UserHandler : IUserHandler
    {

        private readonly HttpClientWrapperService _httpClientWrapper;

        public UserHandler(HttpClientWrapperService client)
        {
            _httpClientWrapper = client;
        }



        public async Task<CreateUser> CreateUser(CreateUser user)
        {
            user.Access = Access.User;
            user.Id = Guid.NewGuid();
            var path = $"User/CreateUser";
            var stringContent = JsonSerializer.Serialize(user);
            var data = new StringContent(stringContent, Encoding.UTF8, "application/json");
            return await _httpClientWrapper.PostAsync<CreateUser>(path, data);
        }


        //public async Task<CreateUser> DeleteUser(CreateUser user)
        //{
        //var path = $"User/DeleteUser";
        //var stringContent = JsonSerializer.Serialize(user);
        //var data = new StringContent(stringContent, Encoding.UTF8, "application/json");
        //CancellationToken = new CancellationToken()
        //return await _httpClientWrapper.DeleteAsync<CreateUser>(path,cancellationToken);

        //var path = $"User/DeleteUser";
        //var stringContent = JsonSerializer.Serialize(user.UserName);
        //var data = new StringContent(stringContent, Encoding.UTF8, "application/json");

        //HttpResponseMessage response;

        //var path = $"User/CreateUser";
        //var request = new HttpRequestMessage(HttpMethod.Delete, path);

        //var stringContent = JsonSerializer.Serialize(user);
        //var data = new StringContent(stringContent, Encoding.UTF8, "application/json");

        //response = _httpClientWrapper.DeleteAsync($"api/products/{user}/headers").Result;

        //request.Content = new StringContent(JsonSerializer(user), Encoding.UTF8, "application/json");
        //return await _httpClientWrapper.SendAsync(request);

        // HTTP DELETE
        //response = _httpClientWrapper.DeleteAsync($"api/User/{user}").Result;



        //return await _httpClientWrapper.DeleteAsync<CreateUser>(path, data);
        //var user = _dbContext.User.FirstOrDefault(x => x.Id == id);
        //_dbContext.User.Remove(user);
        //_dbContext.SaveChanges();
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

        //public async Task<CreateUser> GetUserAsync(string firstName)
        //{
        //    var path = $"User/GetUser";
        //    var result = await _httpClientWrapper.Get<CreateUser>(path, firstName);
        //    return result;

        //}


        public async Task<CreateUser> EditProfile(CreateUser user)
        {

            var path = $"User/EditProfile";
            var stringContent = JsonSerializer.Serialize(user);
            var data = new StringContent(stringContent, Encoding.UTF8, "application/json");
            return await _httpClientWrapper.PutAsync<CreateUser>(path, data);

        }


        public async Task<CreateUser> Authenticate(CreateUser user)
        {
            var path = $"User/LogIn";
            var stringContent = JsonSerializer.Serialize(user);
            var data = new StringContent(stringContent, Encoding.UTF8, "application/json");
            return await _httpClientWrapper.PostAsync<CreateUser>(path, data);
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
