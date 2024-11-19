namespace CafeOrderManagementSystem.Domain.Entities
{
    public class Log
    {
        public int Id { get; set; }
        public string Application { get; set; }
        public string? Detail { get; set; }
        public string? Error { get; set; }
        public int? UserId { get; set; }
        public DateTime LogDate { get; set; }
    }
}
