using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PostProject.Data;
using PostProject.Models;
using PostProject.ViewModel;

namespace PostProject.Controllers;

public class HomeController : Controller
{
    

   static List<Post> Posts = new List<Post>();


    private readonly PostDB _postDB;

    public HomeController(PostDB postDB)
    {
        _postDB = postDB;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult About_()
    {
        ViewBag.Name = "Noor";
        ViewData["Name"] = "Yasser";


        List<Category> categories = _postDB.Categories.Include(x=>x.Posts).ToList();


        AboutVM AboutVM = new AboutVM
        {
            Posts = _postDB.Posts.Include(x=>x.Category).ToList(),
            categories = categories
        };

        return View("About", AboutVM);
    }

    [HttpPost]
    public IActionResult AddPost(Post  post)
    {
        //Posts.Add(post);

        _postDB.Posts.Add(post);
        _postDB.SaveChanges();
        return RedirectToAction(nameof(About_));

    }

    [HttpPost]
    public IActionResult AddCategory(Category category)
    {
        //Posts.Add(post);

        _postDB.Categories.Add(category);
        _postDB.SaveChanges();
        return RedirectToAction(nameof(About_));

    }

    [HttpGet]
    public IActionResult Edit(int Id)
    {

        Post post = _postDB.Posts.Find(Id);
        AboutVM AboutVM = new AboutVM
        {
      post = post
        };

        return View(AboutVM);
    }


    [HttpPost]
    public IActionResult Edit(int Id, Post post)
    {

     var _post=    _postDB.Posts.Find(Id);
        _post.Title = post.Title;
        _post.Body = post.Body;
        _postDB.SaveChanges();


        return RedirectToAction(nameof(About_));
    }

    [HttpGet]
    public IActionResult Delete(int Id)
    {

       var post=  _postDB.Posts.Find(Id);
        _postDB.Posts.Remove(post);

        _postDB.SaveChanges();
        return RedirectToAction(nameof(About_));
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

