using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlazorAppz.Data
{
    public class CreateUser
    {

        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        [JsonPropertyName("userName")]
        public string UserName { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
        [JsonPropertyName("access")]
        public Access Access { get; set; }
        [JsonPropertyName("toDoList")]
        public List<CreateToDoList> ToDoList { get; set; }


    }
}
