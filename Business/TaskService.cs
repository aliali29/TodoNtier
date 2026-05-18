using System.Collections.Generic; 
using System.Linq; 
using NTierTodoApp.DataAccess; 
using NTierTodoApp.Models; 
 
namespace NTierTodoApp.Business 
{ 
    /// <summary>  .طبقة المنطق التجاري إلدارة المهام ///   
 
    /// </summary> 
    public class TaskService 
    { 
        private readonly TaskRepository repository; 
 
        public TaskService(TaskRepository repo) 
        { 
            repository = repo; 
        } 
 
        public List<TaskItem> GetTasks() => repository.GetAll(); 
 
        public void AddTask(string title) 
        { 
            if (string.IsNullOrWhiteSpace(title)) 
                return; 
 var tasks = repository.GetAll(); 
            int newId = tasks.Any() ? tasks.Max(t => t.Id) + 1 : 1; 
            var newTask = new TaskItem { Id = newId, Title = title, IsComplete = false }; 
            repository.Add(newTask); 
        } 
 
        public void CompleteTask(int id) 
        { 
            var task = repository.GetById(id); 
            if (task != null) 
                task.IsComplete = true; 
        } 
 
        /// <summary>
        /// Deletes the task with the specified <paramref name="id"/> by delegating
        /// the operation to the DataAccess layer.
        /// </summary>
        /// <param name="id">The identifier of the task to delete.</param>
        public void DeleteTask(int id)
        {
            // This service method acts as a bridge between the presentation layer
            // and the DataAccess layer: it enforces business-layer responsibilities
            // (if any) and then calls the repository to perform the actual removal.
            repository.Delete(id);
        }
    } 
} 
