namespace Test_API.Models
{
    public class Actor
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public string FirstName  { get; set; }
        public string LastName { get; set; }
        public string Decsription { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CareerStartYear { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
