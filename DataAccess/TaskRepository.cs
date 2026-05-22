using System.Collections.Generic; 
using System.Linq; 
using NTierTodoApp.Models; 
 
namespace NTierTodoApp.DataAccess 
{ 
    /// <summary>  .مستودع البيانات إلدارة المهام باستخدام قائمة في الذاكرة ///   
 
    /// </summary> 
    public class TaskRepository 
    { 
        private List<TaskItem> tasks = new List<TaskItem> 
        { 
            new TaskItem { Id = 1, Title = "مهمة أولى", IsComplete = false }, 
            new TaskItem { Id = 2, Title = "مهمة ثانية", IsComplete = false } 
        }; 
 
        public List<TaskItem> GetAll() => tasks;
        public void Add(TaskItem task) 
        { 
            tasks.Add(task); 
        } 
 
        public TaskItem GetById(int id) 
        { 
            return tasks.FirstOrDefault(t => t.Id == id); 
        } 

        public void UpdateTitle(int id, string title)
        {
            var task = GetById(id);

            if (task != null)
            {
                task.Title = title;
            }
        }
 
        /// <summary>
        /// Deletes the task with the specified <paramref name="id"/> from the in-memory list.
        /// </summary>
        /// <param name="id">The identifier of the task to remove.</param>
        public void Delete(int id)
        {
            // Search for the task by id (reuses GetById which uses LINQ FirstOrDefault)
            var task = GetById(id);

            // If the task exists, remove it from the list. If not, do nothing.
            if (task != null)
            {
                tasks.Remove(task);
            }
        }
    } 
}