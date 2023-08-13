namespace WebApp5CoreWebAPI.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }

        /// <summary>
        /// Secret for admins
        /// </summary>
        public string? Secret { get; set; }
    }
}