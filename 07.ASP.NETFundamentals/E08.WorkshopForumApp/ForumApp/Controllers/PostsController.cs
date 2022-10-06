namespace ForumApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Data;
    using Models;
    using Data.Entities;

    public class PostsController : Controller
    {
        private readonly ForumAppDbContext db;

        public PostsController(ForumAppDbContext _db)
        {
            this.db = _db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult All()
        {
            var posts = this.db.Posts
                .Select(p => new PostViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content
                })
                .ToList();

            return View(posts);
        }

        public IActionResult Add()
            => View();

        [HttpPost]
        public async Task<IActionResult> Add(PostFormModel model)
        {
            var post = new Post()
            {
                Title = model.Title,
                Content = model.Content
            };

            await this.db.Posts.AddAsync(post);
            await this.db.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        public IActionResult Edit(int id)
        {
            var post = this.db.Posts.Find(id);

            return View(new PostFormModel()
            {
                Title = post.Title,
                Content = post.Content
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(
            int id, PostFormModel model)
        {
            var post = this.db.Posts.Find(id);
            post.Title = model.Title;
            post.Content = model.Content;

            await this.db.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var post = this.db.Posts.Find(id);

            this.db.Posts.Remove(post);
            await this.db.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }
    }
}
