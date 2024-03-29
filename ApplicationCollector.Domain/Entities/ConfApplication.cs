namespace ApplicationCollector.Domain.Entities
{
    public class ConfApplication
    {
        public Guid Id { get; set; }
        public Guid Author { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Outline { get; set; }
        public Speaker? Speaker { get; set; }

    }
}
