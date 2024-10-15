using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDOList.Data;
using ToDOList.Models;

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

        [HttpGet]
        public IActionResult CreateNew()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateNew(ToDoListEf toDOList, IFormFile fileName)
        {
            if (fileName.Length > 0) 
            {
                var FileName = Guid.NewGuid().ToString() + Path.GetExtension(fileName.FileName);
                var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//File", FileName);

                using(var stream = System.IO.File.Create(filepath))
                {
                    fileName.CopyTo(stream);
                }
                toDOList.fileName = FileName;
            }
            dbContext.ToDoListEfs.Add(toDOList);
            dbContext.SaveChanges();
            TempData["success"] = "تم اضافه المهمه بنجاح";
            return RedirectToAction("items");
        }

        public IActionResult Delete(int id) 
        {

            ToDoListEf todolistef = new ToDoListEf() { Id = id };
            dbContext.ToDoListEfs.Remove(todolistef);
            dbContext.SaveChanges();   
            
            return RedirectToAction("items");

        }

    }
}
