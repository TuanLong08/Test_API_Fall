namespace Test_API_Fall.Dtos
{
    public class ActorDto
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Decsription { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CareerStartYear { get; set; }
    }
}
