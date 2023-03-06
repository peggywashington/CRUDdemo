using CRUDDemo.Data;
using CRUDDemo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
    
namespace CRUDDemo.Controllers
{
    public class MoviesController : Controller
    {
        private DoujiaEntitiesDbContext ctx = new DoujiaEntitiesDbContext();

        // GET: Movies
        public ActionResult Index()
        {
            using (ctx)
            {
                Movies[] moviesList = new Movies[16];
                int count = 0;
                foreach (var movie in ctx.Movies)
                {
                    moviesList[count] = movie;
                    ViewBag.moviesList = moviesList;
                    /*                    Debug.WriteLine(moviesList[count].MovieName);*/
                    count++;
                }
            }
            return View();
        }

        [Route("Movies/Detail/{MovieName}")]
        public ActionResult Detail(string MovieName)
        {
            var movieThis = new Movies();
            using (ctx)
            {
                foreach (var movie in ctx.Movies)
                { 
                    if (string.Equals(movie.MovieName.Trim(), MovieName.Trim()))
                    {
                        movieThis = movie;
                        break;
                    }
                }
            }
            return View(movieThis);
        }

        [HttpPost]
        [Route("Movies/Detail/{MovieName}")]
        public ActionResult Submit(Movies request,HttpPostedFileBase file)
        {
            var entity = ctx.Movies.FirstOrDefault(item => item.MovieName == request.MovieName);
            Console.WriteLine(entity);
            if (entity != null)
            {
                entity.Rate = request.Rate;
                entity.Comment = request.Comment;
                entity.Picture = request.Picture;
            }
            else ctx.Movies.Add(request);
            ctx.SaveChanges();
            // return RedirectToAction("Detail", "Movies", new { MovieName = request.MovieName });
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Delete(string MovieName)
        {
            var entity = ctx.Movies.FirstOrDefault(item => item.MovieName == MovieName);
            if (entity != null)
                ctx.Movies.Remove(entity);
            ctx.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
    }
}