using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_API.Models;
using Test_API_Fall.Dtos;
using Test_API_Fall.Respository;

namespace Test_API_Fall.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private IGenreRes _IGenreRes;

        public GenreController(IGenreRes genreRes)
        {
            _IGenreRes = genreRes;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_IGenreRes.GetAll());
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var genre = _IGenreRes.GetbyId(id);
                return Ok(genre);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Add(GenreDto genre)
        {
            try
            {
                return Ok(_IGenreRes.Add(genre));
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _IGenreRes.delete(id);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult update(Guid id,GenreDto genre) 
        {
            if (id != genre.Id)
            {
                return NoContent();
            }
            try
            {
                _IGenreRes.update(genre);
                return NoContent();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
