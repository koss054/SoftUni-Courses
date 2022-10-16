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

        public IActionResult Details(int id)
        {
            var task = this.data
                .Tasks
                .Where(t => t.Id == id)
                .Select(t => new TaskDetailsViewModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    CreatedOn = t.CreatedOn.ToString("dd/MM/yyyy HH:mm"),
                    Board = t.Board.Name,
                    Owner = t.Owner.UserName
                })
                .FirstOrDefault();

            if (task == null)
            {
                return BadRequest();
            }

            return View(task);
        }

        public IActionResult Edit(int id)
        {
            var task = data.Tasks.Find(id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();

            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            TaskFormModel taskModel = new TaskFormModel()
            {
                Title = task.Title,
                Description = task.Description,
                BoardId = task.BoardId,
                Boards = GetBoards()
            };

            return View(taskModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TaskFormModel taskModel)
        {
            var task = data.Tasks.Find(id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();

            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            if (!GetBoards().Any(b => b.Id == taskModel.BoardId))
            {
                this.ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exists.");
            }

            task.Title = taskModel.Title;
            task.Description = taskModel.Description;
            task.BoardId = taskModel.BoardId;

            await this.data.SaveChangesAsync();

            return RedirectToAction("All", "Boards");
        }

        public IActionResult Delete(int id)
        {
            var task = data.Tasks.Find(id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();

            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            TaskViewModel taskModel = new TaskViewModel()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description
            };

            return View(taskModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TaskViewModel taskModel)
        {
            var task = data.Tasks.Find(taskModel.Id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();

            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            this.data.Tasks.Remove(task);
            await this.data.SaveChangesAsync();

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
