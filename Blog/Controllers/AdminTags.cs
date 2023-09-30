using Blog.Data;
using Blog.Models.Domain;
using Blog.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class AdminTags : Controller
    {
        private BlogDbContext db;
        public AdminTags(BlogDbContext dbContext)
        {

            this.db = dbContext; 
            
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        //[ActionName("Add")]
        public IActionResult Add(AddTagsRequest tag)
        {
            //mapping tag request to Tag domain model
            var tags = new Tag
            {
                Name = tag.Name,
                DisplayName = tag.DisplayName

            };
            db.Tags.Add(tags);
            db.SaveChanges();

            //var name = Request.Form["name"];
            //var displayName = Request.Form["displayName"];

            return View();
        }
    }
}
