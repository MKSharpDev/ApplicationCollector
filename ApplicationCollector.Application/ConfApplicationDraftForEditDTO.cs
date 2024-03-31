using System.ComponentModel.DataAnnotations;

namespace ApplicationCollector.Application
{
    public class ConfApplicationDraftForEditDTO
    {
        [StringLength(100)]
        public string? Name { get; set; }

        [StringLength(20)]
        public string? Activity { get; set; }

        [StringLength(300)]
        public string? Description { get; set; }

        [StringLength(1000)]
        public string? Outline { get; set; }
    }
}
