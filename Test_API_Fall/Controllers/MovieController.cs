using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_API_Fall.Dtos;
using Test_API_Fall.Models;
using Test_API_Fall.Respository;

namespace Test_API_Fall.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovieRes _iMovieRes;

        public MovieController(IMovieRes movieRes)
        {
            _iMovieRes = movieRes;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_iMovieRes.GetAll());
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
                var movie = _iMovieRes.GetbyId(id);
                return Ok(movie);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Add(MovieVM movieDto)
        {
            try
            {
                return Ok(_iMovieRes.Add(movieDto));
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
                _iMovieRes.delete(id);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult update(Guid id, MovieDto movieDto)
        {
            if (id != id)
            {
                return NoContent();
            }
            try
            {
                _iMovieRes.update(movieDto);
                return NoContent();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
