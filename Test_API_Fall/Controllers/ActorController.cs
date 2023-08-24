using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_API_Fall.Dtos;
using Test_API_Fall.Models;
using Test_API_Fall.Respository;

namespace Test_API_Fall.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private IActorRes _iActorRes;

        public ActorController(IActorRes actorRes)
        {
            _iActorRes = actorRes;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_iActorRes.GetAll());
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
                var movie = _iActorRes.GetbyId(id);
                return Ok(movie);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Add(ActorVM actorDto)
        {
            try
            {
                return Ok(_iActorRes.Add(actorDto));
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
                _iActorRes.delete(id);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult update(Guid id, ActorDto actorDto)
        {
            if (id != id)
            {
                return NoContent();
            }
            try
            {
                _iActorRes.update(actorDto);
                return NoContent();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
