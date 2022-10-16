using System.Security.Claims;

using Microsoft.AspNetCore.Mvc;

using TaskBoardApp.Data;
using TaskBoardApp.Models.Tasks;

namespace TaskBoardApp.Controllers
{
    public class TasksController : Controller
    {
        private readonly TaskBoardAppDbContext data;

        public TasksController(TaskBoardAppDbContext context)
            => this.data = context;

        public async Task<IActionResult> Create()
        {
            TaskFormModel taskModel = new TaskFormModel()
            {
                Boards = GetBoards()
            };

            return View(taskModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel taskModel)
        {
            if (!GetBoards().Any(b => b.Id == taskModel.BoardId))
            {
                this.ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist.");
            }

            string currentUserId = GetUserId();

            Data.Entities.Task task = new Data.Entities.Task()
            {
                Title = taskModel.Title,
                Description = taskModel.Description,
                CreatedOn = DateTime.Now,
                BoardId = taskModel.BoardId,
                OwnerId = currentUserId
            };

            await this.data.Tasks.AddAsync(task);
            await this.data.SaveChangesAsync();

            var boards = this.data.Boards;

            return RedirectToAction("All", "Boards");
        }

        private IEnumerable<TaskBoardModel> GetBoards()
            => this.data
                .Boards
                .Select(b => new TaskBoardModel()
                {
                    Id = b.Id,
                    Name = b.Name
                });

        private string GetUserId()
            => this.User
                .FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
