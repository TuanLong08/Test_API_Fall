namespace Test_API.Models
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Decsription { get; set; }
        public virtual IEnumerable<Movie> movies { get; set; }
    }
}
