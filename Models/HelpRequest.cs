namespace StepIntoHelp.Models
{
    public class HelpRequest
    {
        public required int Id { get; set; }
        public required int UserId { get; set; }
        public required User User { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public required string Details { get; set; }
        public DateTime CreatedAt { get; set; }
        public HelpRequestStatus Status { get; set; }
    }

    public enum HelpRequestStatus
    {
        Pending,
        InProgress,
        Completed
    }
}