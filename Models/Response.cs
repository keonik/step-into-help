namespace StepIntoHelp.Models
{
    public class Response
    {
        public int Id { get; set; }
        public required HelpRequest HelpRequest { get; set; }
        public required int HelpRequestId { get; set; }
        public required Organization Organization { get; set; }
        public required string Outcome { get; set; }
        public DateTime RespondedAt { get; set; }
    }
}