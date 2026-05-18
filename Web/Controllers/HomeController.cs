using Microsoft.AspNetCore.Mvc; 
using NTierTodoApp.Business; 
 
namespace NTierTodoApp.Controllers 
{ 
    public class HomeController : Controller 
    { 
        private readonly TaskService taskService; 
 
        public HomeController(TaskService service) 
        { 
            taskService = service; 
        } 
 
        public IActionResult Index() 
        { 
            var tasks = taskService.GetTasks(); 
            return View(tasks); 
        } 
 
        [HttpPost] 
        public IActionResult AddTask(string title) 
        { 
            if (!string.IsNullOrWhiteSpace(title)) 
                taskService.AddTask(title); 
            return RedirectToAction("Index"); 
        } 
 
        [HttpPost] 
        public IActionResult CompleteTask(int id) 
        { 
            taskService.CompleteTask(id); 
            return RedirectToAction("Index"); 
        } 
 
        /// <summary>
        /// Receives a POST request to delete a task and delegates the
        /// deletion to the business layer (TaskService).
        /// </summary>
        /// <param name="id">The identifier of the task to delete.</param>
        [HttpPost]
        public IActionResult DeleteTask(int id)
        {
            // Controller responsibilities: handle the HTTP request and delegate
            // business logic to the service layer. The service will call into
            // the DataAccess layer to perform the actual deletion.
            taskService.DeleteTask(id);

            return RedirectToAction("Index");
        }
    } 
} 