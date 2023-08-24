using Test_API.Models;
using Test_API_Fall.Dtos;

namespace Test_API_Fall.Respository
{
    public interface IGenreRes
    {
        GenreDto Add(GenreDto genre);
        void update(GenreDto genre);
        void delete(Guid Id);
        List<GenreDto> GetAll();
        GenreDto GetbyId(Guid Id);
    }
}
