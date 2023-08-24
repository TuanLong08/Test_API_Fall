namespace Test_API.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public Guid GenreId { get; set; }
        public Guid ActorId { get; set; }
        public string Decsription { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual IEnumerable<Actor> actors { get; set;}
    }
}
