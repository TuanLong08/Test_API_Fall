using Test_API.Data;
using Test_API.Models;
using Test_API_Fall.Dtos;
using Test_API_Fall.Models;

namespace Test_API_Fall.Respository
{
    public class ActorRes : IActorRes
    {
        private MyDbContext _context;

        public ActorRes(MyDbContext context)
        {
            _context = context;
        }
        public ActorDto Add(ActorVM actor)
        {
            var _actor = new Actor
            {
                FirstName = actor.FirstName,
                LastName = actor.LastName,
                DateOfBirth = actor.DateOfBirth,
                Decsription = actor.Decsription,
                CareerStartYear = actor.CareerStartYear,
            };
            _context.Add(_actor);
            _context.SaveChanges();
            return new ActorDto
            {
                FirstName = _actor.FirstName,
                LastName = _actor.LastName,
                CareerStartYear = _actor.CareerStartYear,
                Id = _actor.Id,
                Decsription = _actor.Decsription,
                DateOfBirth= _actor.DateOfBirth,
                MovieId = _actor.MovieId
            };
        }

        public void delete(Guid Id)
        {
            var actor = _context.actors.SingleOrDefault(c => c.Id == Id);
            if (actor != null)
            {
                _context.actors.Remove(actor);
                _context.SaveChanges();
            }
        }

        public List<ActorDto> GetAll()
        {
            var actor = _context.actors.Select(c => new ActorDto
            {
                Id = c.Id,
                MovieId= c.MovieId,
                Decsription = c.Decsription,
                DateOfBirth = c.DateOfBirth,
                CareerStartYear= c.CareerStartYear,
                FirstName = c.FirstName,
                LastName = c.LastName,
            });
            return actor.ToList();
        }

        public ActorDto GetbyId(Guid Id)
        {
            var actor = _context.actors.SingleOrDefault(c => c.Id == Id);
            if (actor != null)
            {
                return new ActorDto
                {
                    Id = actor.Id,
                    LastName= actor.LastName,
                    FirstName= actor.FirstName,
                    CareerStartYear = actor.CareerStartYear,
                    DateOfBirth= actor.DateOfBirth,
                    MovieId = actor.Id,
                    Decsription = actor.Decsription
                };
            };
            return null;
        }

        public void update(ActorDto actor)
        {
            var _actor = _context.actors.SingleOrDefault(c => c.Id == actor.Id);
            _actor.DateOfBirth = actor.DateOfBirth;
            _actor.Decsription = actor.Decsription;
            _actor.CareerStartYear = actor.CareerStartYear;
            _actor.FirstName = actor.FirstName;
            _actor.LastName = actor.LastName;
            _context.SaveChanges();
        }
    }
}
