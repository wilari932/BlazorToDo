using BlazorAppz.Data;
using System.Net;
using System.Text;
using System.Text.Json;
using Task = BlazorAppz.Data.Task;

namespace BlazorAppz.Services
{
    public class ListHandler : IListHandler
    {
        private readonly HttpClientWrapperService _httpClientWrapper;

        public ListHandler(HttpClientWrapperService client)
        {
            _httpClientWrapper = client;
        }

        public async Task<IEnumerable<CreateToDoList>> GetCurrentUserListsAsync()  //Funkar
        {
            var path = "/GetCurrentUserLists";
            var result = await _httpClientWrapper.Get<IEnumerable<CreateToDoList>>(path);

            return result;
        }


        public async Task<CreateToDoList> CreateNewToDoList(CreateToDoList list)   //funkar
        {
            list.ThisWeek = false;
            list.Expired = false;
            list.Date = DateTime.Now.ToString("G");
            list.Id= Guid.NewGuid();

            list.Task = new List<Task>();
            var path = $"List/CreateNewToDoList";
            var stringContent = JsonSerializer.Serialize(list);
            var data = new StringContent(stringContent, Encoding.UTF8, "application/json");
            return await _httpClientWrapper.PostAsync<CreateToDoList>(path, data);

        }

        public async Task<Guid> GetRecentViewedList()  //funakr
        {
            var path = $"List/ViewSingleList";
            return await _httpClientWrapper.Get<Guid>(path);

        }

        public async Task<IEnumerable<CreateToDoList>> GetAllListsAsync()   //Funkar
        {
            var path = $"List/GetAllLists";
            var result = await _httpClientWrapper.Get<IEnumerable<CreateToDoList>>(path);
            return result;

        }

        //public void DeleteList(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        var listID = Guid.Parse(ListDictionary.id["ListId"]);
        //        var selectedList = _dbContext.ToDoLists.FirstOrDefault(x => x.Id == listID);
        //        _dbContext.ToDoLists.Remove(selectedList);
        //        _dbContext.SaveChanges();
        //        return;
        //    }
        //    else
        //    {
        //        var selectedList = _dbContext.ToDoLists.FirstOrDefault(x => x.Id == id);
        //        _dbContext.ToDoLists.Remove(selectedList);
        //        _dbContext.SaveChanges();
        //        return;
        //    }
        //}

        //public CreateToDoList ChangeListName(string listTitle)
        //{
        //    var listID = Guid.Parse(ListDictionary.id["ListId"]);
        //    var list = _dbContext.ToDoLists.FirstOrDefault(x => x.Id == listID);
        //    list.ListTitle = listTitle;            
        //    _dbContext.SaveChanges();
        //    return list;
        //}

        public async Task<CreateToDoList> ShowList(Guid id)
        {
            var path = $"List/ShowList/"+id.ToString();
            var result = await _httpClientWrapper.Get<CreateToDoList>(path);
            return result;
        }

            //public CreateToDoList WeeklyList(Guid? id)
            //{
            //    if(id == null)
            //    {
            //        id = Guid.Parse(ListDictionary.id["ListId"]);
            //    }
            //    var list = _dbContext.ToDoLists.FirstOrDefault(x => x.Id == id);
            //    list.ThisWeek = true;
            //    _dbContext.SaveChanges();
            //    return list;
            //}




    }
}
