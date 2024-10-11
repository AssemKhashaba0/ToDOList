using Microsoft.AspNetCore.Mvc;
using ToDOList.Data;

namespace ToDOList.Controllers
{
    public class ToDoItemsController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string username)
        {
           
                var cookieOptions = new CookieOptions
                {
                    Expires = DateTimeOffset.Now.AddDays(1) 
                };
                Response.Cookies.Append("username", username, cookieOptions);
            

            return RedirectToAction("items");
        }

        public IActionResult items()
        {
            var allitem = dbContext.ToDoListEfs.ToList();
            var username = Request.Cookies["username"];
            ViewBag.Username = username;
            return View(allitem);
        }

    }
}
