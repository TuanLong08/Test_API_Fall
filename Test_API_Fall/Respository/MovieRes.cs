using Microsoft.EntityFrameworkCore;
using Test_API.Data;
using Test_API.Models;
using Test_API_Fall.Dtos;
using Test_API_Fall.Models;

namespace Test_API_Fall.Respository
{
    public class MovieRes : IMovieRes
    {
        private MyDbContext _context;

        public MovieRes(MyDbContext context)
        {
            _context = context;
        }
        public MovieDto Add(MovieVM movieDto)
        {
            var _movie = new Movie
            {
                Name = movieDto.Name,
                Decsription = movieDto.Decsription,
                Time = movieDto.Time,

            };
            _context.Add(_movie);
            _context.SaveChanges();
            return new MovieDto
            {
                Id = _movie.Id,
                Name = _movie.Name,
                Decsription = _movie.Decsription,
            };
        }

        public void delete(Guid Id)
        {
            var movie = _context.movies.SingleOrDefault(c => c.Id == Id);
            if (movie != null)
            {
                _context.movies.Remove(movie);
                _context.SaveChanges();
            }
        }

        public List<MovieDto> GetAll()
        {
            var movie = _context.movies.Select(c => new MovieDto
            {
                Id = c.Id,
                ActorId = c.ActorId,
                GenreId = c.GenreId,
                Name = c.Name,
                Decsription = c.Decsription,
                Time = c.Time
            });
            return movie.ToList();
        }

        public MovieDto GetbyId(Guid Id)
        {
            var movie = _context.movies.SingleOrDefault(c => c.Id == Id);
            if (movie != null)
            {
                return new MovieDto
                {
                    Id = movie.Id,
                    ActorId = movie.ActorId,
                    GenreId = movie.GenreId,
                    Name = movie.Name,
                    Decsription = movie.Decsription,
                    Time = movie.Time
                };
            };
            return null;
        }

        public void update(MovieDto movieDto)
        {
            var _movie = _context.movies.SingleOrDefault(c => c.Id == movieDto.Id);
            _movie.Name = movieDto.Name;
            _movie.Decsription = movieDto.Decsription;
            _movie.Time = movieDto.Time;
            _context.SaveChanges();
        }
    }
}
