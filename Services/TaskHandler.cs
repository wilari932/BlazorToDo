using BlazorAppz.Data;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text;
using Task = BlazorAppz.Data.Task;

namespace BlazorAppz.Services
{
    public class TaskHandler : ITaskHandler
    {

        private readonly HttpClientWrapperService _httpClientWrapper;

        public TaskHandler(HttpClientWrapperService client)
        {
            _httpClientWrapper = client;
        }

        public async Task<CreateToDoList> AddTask(Data.Task task)   //Funkar. Om jag fyller i alla fält i taksen här, så ser jag allt.
                                                                    //Om jag gör det i api:et så får jag ej se de?

        {
            task.Completed = false;
            var path = $"Task/AddTask";
            var stringContent = JsonSerializer.Serialize(task);
            var data = new StringContent(stringContent, Encoding.UTF8, "application/json");
            return await _httpClientWrapper.PostAsync<CreateToDoList>(path, data);
        }


        //    public IEnumerable<Task> GetTasks(Guid id)
        //    {
        //        var tasks = _dbContext.Task.Where(x => x.CreateToDoListId == id);
        //        return tasks;
        //    }

        //    public Task EditTaskName(string taskTitle)
        //    {
        //        var taskId = Guid.Parse(ListDictionary.id["TaskId"]);
        //        var task = _dbContext.Task.FirstOrDefault(x => x.Id == taskId);
        //        task.TaskTitle = taskTitle;
        //        _dbContext.SaveChanges();
        //        return task;
        //    }

        public async Task<Task> DeleteTask(Data.Task task)   
        {
            var path = $"Task/DeleteTask/" + task.Id.ToString();
            return await _httpClientWrapper.DeleteAsync<Task>(path);
        }

        //public void DeleteTask()
        //{
        //    var taskId = Guid.Parse(ListDictionary.id["TaskId"]);
        //    var task = _dbContext.Task.FirstOrDefault(x => x.Id == taskId);
        //    _dbContext.Remove(task);
        //    _dbContext.SaveChanges();
        //}

        //    public Task GetSingelTask(Guid id)
        //    {
        //        ListDictionary.id["TaskId"] = id.ToString();
        //        var task = _dbContext.Task.FirstOrDefault(x => x.Id == id);
        //        return task;
        //    }


        //    public Task MarkAsComplete(bool completed)
        //    {
        //        var taskId = Guid.Parse(ListDictionary.id["TaskId"]);
        //        var task = _dbContext.Task.FirstOrDefault(x => x.Id == taskId);
        //        task.Completed = !task.Completed;
        //        _dbContext.SaveChanges();
        //        return task;
        //    }




    }

}



