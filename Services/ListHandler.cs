using BlazorAppz.Data;

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

        public async Task<IEnumerable<CreateToDoList>> GetCurrentUserListsAsync()
        {
            var path = "/GetCurrentUserLists";
            var result = await _httpClientWrapper.Get<IEnumerable<CreateToDoList>>(path);

            return result;
        }


        //public async Task<CreateToDoList> CreateNewToDoList(HttpContent listItem)
        //{
        //    var path = "List/CreateNewList";
        //    var result = await _httpClientWrapper.PostAsync<CreateToDoList>(path, listItem);

        //    return result;

        //}

        public async Task<IEnumerable<CreateToDoList>> GetAllListsAsync()
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


        //public CreateToDoList ViewOneList(Guid id)
        //{
        //    ListDictionary.id["ListId"] = id.ToString();
        //    var list = _dbContext.ToDoLists.FirstOrDefault(x => x.Id == id);
        //    return list;
        //}

        //public IEnumerable<CreateToDoList> GetCurrentUsersLists(System.Security.Principal.IIdentity identity, string userId)
        //{
        //    var lists = _dbContext.ToDoLists.Where(x => x.CreateUserId == Guid.Parse(userId)).ToList();
        //    return lists;
        //}

        //public IEnumerable<CreateToDoList> SortLists(Sort option, string userId)
        //{
        //    var lists = _dbContext.ToDoLists.Where(x => x.CreateUserId == Guid.Parse(userId)).ToList().OrderBy(x => x.Date);  
        //    //if (option == Sort.Name) // Funkar, men toList?
        //    //{
        //    //    lists = _dbContext.ToDoLists.Where(x => x.CreateUserId == Guid.Parse(userId)).OrderBy(x => x.ListTitle);
        //    //}
        //    //if (option == Sort.Descending) 
        //    //{
        //    //    lists = _dbContext.ToDoLists.Where(x => x.CreateUserId == Guid.Parse(userId)).OrderBy(x => x.Date);
        //    //}  
        //    //if (option == Sort.Ascending)
        //    //{
        //    //    lists = _dbContext.ToDoLists.Where(x => x.CreateUserId == Guid.Parse(userId)).OrderByDescending(x => x.Date);
        //    //}
        //    _dbContext.SaveChanges();
        //    return lists;
        //}


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
