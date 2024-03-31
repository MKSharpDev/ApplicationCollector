namespace ApplicationCollector.Domain.Entities
{
    public class Speaker : BaseEntity<Guid>
    {
        public Guid ApplicationDraftInProgressId { get; set; }
        public List<ConfApplicationDraft>? ApplicationDraft { get; set; }
        public List<ConfApplication>? Applications { get; set; }
    }
}
