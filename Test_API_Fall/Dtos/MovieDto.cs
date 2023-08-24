using Test_API.Models;

namespace Test_API_Fall.Dtos
{
    public class MovieDto
    {
        public Guid Id { get; set; }
        public Guid GenreId { get; set; }
        public Guid ActorId { get; set; }
        public string Decsription { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
    }
}
