using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using TaskBoardApp.Data;
using TaskBoardApp.Models;
using TaskBoardApp.Models.Tasks;

namespace TaskBoardApp.Controllers
{
    public class BoardsController : Controller
    {
        private readonly TaskBoardAppDbContext data;

        public BoardsController(TaskBoardAppDbContext context)
                => this.data = context;

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> All()
        {
            var boards = await this.data.Boards
                .Select(b => new BoardViewModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Tasks = b.Tasks.Select(t => new TaskViewModel()
                    {
                        Id = t.Id,
                        Title = t.Title,
                        Description = t.Description,
                        Owner = t.Owner.UserName
                    })
                })
                .ToListAsync();

            return View(boards);
        }
    }
}
