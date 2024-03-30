namespace ApplicationCollector.Domain.Entities
{
    public class Speaker : BaseEntity<Guid>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Outline { get; set; }
        public Guid ApplicationDraftId { get; set; }
        public ConfApplicationDraft? ApplicationDraft { get; set; }
        public List<ConfApplication>? Applications { get; set; }
        public int? ActivityId { get; set; }
        public ConfActivity? Activity { get; set; }

    }
}
