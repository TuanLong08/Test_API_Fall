using Test_API.Models;
using Test_API_Fall.Dtos;
using Test_API_Fall.Models;

namespace Test_API_Fall.Respository
{
    public interface IMovieRes
    {
        MovieDto Add(MovieVM movieDto);
        void update(MovieDto movieDto);
        void delete(Guid Id);
        List<MovieDto> GetAll();
        MovieDto GetbyId(Guid Id);
    }
}
