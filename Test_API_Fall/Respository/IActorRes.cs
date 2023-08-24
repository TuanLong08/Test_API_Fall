using Test_API.Models;
using Test_API_Fall.Dtos;
using Test_API_Fall.Models;

namespace Test_API_Fall.Respository
{
    public interface IActorRes
    {
        ActorDto Add(ActorVM actor);
        void update(ActorDto actor);
        void delete(Guid Id);
        List<ActorDto> GetAll();
        ActorDto GetbyId(Guid Id);
    }
}
