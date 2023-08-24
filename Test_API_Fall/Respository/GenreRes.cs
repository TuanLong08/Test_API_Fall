using Microsoft.EntityFrameworkCore;
using Test_API.Data;
using Test_API.Models;
using Test_API_Fall.Dtos;

namespace Test_API_Fall.Respository
{
    public class GenreRes : IGenreRes
    {
        private MyDbContext _context;
        //DbSet<Genre> genres;

        public GenreRes(MyDbContext context)
        {
            _context = context;
        }

        public GenreDto Add(GenreDto genre)
        {
            var _genre = new Genre 
            {
                Name = genre.Name,
                Decsription = genre.Decsription,
            };
            _context.Add(_genre);
            _context.SaveChanges();
            return new GenreDto
            {
                Id = _genre.Id,
                Name = _genre.Name,
                Decsription= _genre.Decsription,
            };
        }


        public List<GenreDto> GetAll()
        {
            var genre = _context.genres.Select(c => new GenreDto{
                Id = c.Id,
                Name  = c.Name,
                Decsription = c.Decsription,
            });
            return genre.ToList();
        }

        public GenreDto GetbyId(Guid Id)
        {
            var genre = _context.genres.SingleOrDefault(c => c.Id == Id);
            if (genre != null)
            {
                return new GenreDto
                {   
                    Id = Id,
                    Name = genre.Name,
                    Decsription = genre.Decsription
                };
            };
            return null;
        }

        public void update(GenreDto genre)
        {
            var _genre = _context.genres.SingleOrDefault(c => c.Id == genre.Id);
            _genre.Name = genre.Name;
            _genre.Decsription = genre.Decsription;
            _context.SaveChanges();
        }
        public void delete(Guid Id)
        {
            var genre = _context.genres.SingleOrDefault(c => c.Id == Id);
            if (genre != null) 
            {
                _context.genres.Remove(genre);
                _context.SaveChanges();
            }
        }
    }
}
