using BlazorAppz.Data;
using Task = System.Threading.Tasks.Task;

namespace BlazorAppz.Services
{
    public interface IListHandler 
    {
        //CreateToDoList CreateNewToDoList(string id, string listTitle);
        Task<IEnumerable<CreateToDoList>> GetAllListsAsync();
        //void DeleteList(Guid? id);
        //CreateToDoList ChangeListName(string value);
        //CreateToDoList ViewOneList(Guid id);
        //CreateToDoList WeeklyList(Guid? id);
        //IEnumerable<CreateToDoList> SortLists(Sort option, string id);
        Task<IEnumerable<CreateToDoList>> GetCurrentUserListsAsync();
    }
}
