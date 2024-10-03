namespace StepIntoHelp.Models
{
    public class Organization
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string ServiceDescription { get; set; }
    }
}