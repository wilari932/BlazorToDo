using BlazorAppz.Data;
using Task = System.Threading.Tasks.Task;

namespace BlazorAppz.Services
{
    public interface IListHandler 
    {
        //CreateToDoList CreateNewToDoList(string id, string listTitle);
        Task <CreateToDoList> CreateNewToDoList(CreateToDoList list);
        Task <Guid> GetRecentViewedList();
        Task<IEnumerable<CreateToDoList>> GetAllListsAsync();
        //void DeleteList(Guid? id);
        //CreateToDoList ChangeListName(string value);
        Task<CreateToDoList> ShowList(Guid id);
        //CreateToDoList WeeklyList(Guid? id);
        Task<IEnumerable<CreateToDoList>> GetCurrentUserListsAsync();
    }
}
