namespace ApplicationCollector.Domain.Entities
{
    public class ConfApplicationDraft: BaseEntity<Guid>
    {
        public Guid Author { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Outline { get; set; }
        public string? Activity { get; set; }

        public DateTime Time { get; set; }

        public Speaker? Speaker { get; set; }


    }
}
