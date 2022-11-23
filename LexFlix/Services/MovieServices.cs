using LexFlix.Data;
using LexFlix.Models;
using LexFlix.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LexFlix.Services
{
    public class MovieServices : IMovieServices
    {
        private readonly ApplicationDbContext _context;
        public MovieServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task AddMovie(Movies movies)
        {
            
                _context.Movies.Add(movies);
                _context.SaveChanges();
                return null;
            
        }
        public Task DeleteMovies(int id)
        {           
            var movies = _context.Movies.Where(x => x.Id == id).FirstOrDefault();
            _context.Movies.Remove(movies);
            _context.SaveChanges();
            return null;
        }
        public Task DeleteConfirmed(int id)
        {
            if (_context.Movies == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Movies'  is null.");
            }
            var movies = _context.Movies.Find(id);
            if (movies != null)
            {
                _context.Movies.Remove(movies);
            }

            _context.SaveChangesAsync();
            return null;
        }
        public Task EditMovies(int id )
        {
            var movies = _context.Movies.Where(x => x.Id == id).FirstOrDefault();
            
            return null;
        }
        public Task EditMovies(Movies Model)
        {
            var movies = _context.Movies.Where(m => m.Id == Model.Id).FirstOrDefault();
            if (movies != null)
            {
                movies.Title = Model.Title;
                movies.ReleaseYear = Model.ReleaseYear;
                movies.Director = Model.Director;
                movies.Price = Model.Price;
                movies.ImageURL = Model.ImageURL;
                _context.SaveChanges();
            }
            return null;
        }
        private Task Problem(string v)
        {
            throw new NotImplementedException();
        }
    }
}
