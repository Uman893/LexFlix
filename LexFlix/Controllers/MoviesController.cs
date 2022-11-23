using LexFlix.Data;
using LexFlix.Helper;
using LexFlix.Models;
using LexFlix.Models.ViewModels; //This was incorrect
using LexFlix.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Drawing;

namespace LexFlix.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<MoviesController> _logger;
        private readonly IMovieServices _movieServices;

        public MoviesController(ApplicationDbContext context, ILogger<MoviesController> logger, IMovieServices movieServices)
        {
            _context = context;
            _logger = logger;
            _movieServices = movieServices;
        }

        public async Task<IActionResult> MovieAdmin()
        {
            return View(await _context.Movies.ToListAsync());
        }
        public async Task<IActionResult> Library()
        {
            return View(await _context.Movies.ToListAsync());
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        
        [HttpPost]        
        public IActionResult AddMovie([Bind("Id,Title,Director,ReleaseYear,Price,ImageURL")] Movies movies)
        {

            if (ModelState.IsValid)
            {
                _movieServices.AddMovie(movies);
                return RedirectToAction("MovieAdmin");
               

            }
            return View(movies);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movies = _movieServices.DeleteMovies(id);

            return View(movies);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movies = _movieServices.DeleteConfirmed(id);
           
            return RedirectToAction("MovieAdmin");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var movies = _movieServices.EditMovies(id);
            return View(movies);
        }

        [HttpPost]
        public ActionResult Edit(Movies Model)
        {
            _movieServices.EditMovies(Model);
            return RedirectToAction("MovieAdmin");
        }
    }
}


