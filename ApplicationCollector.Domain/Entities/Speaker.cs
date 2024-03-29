namespace ApplicationCollector.Domain.Entities
{
    public class Speaker
    {
        public Guid Author { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Outline { get; set; }
        public Guid ApplicationId { get; set; }
        public ConfApplication? Application { get; set; }
    }
}
