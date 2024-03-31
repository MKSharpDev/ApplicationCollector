using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCollector.Application
{
    public class ConfApplicationDraftDTO
    {
        public Guid Id { get; set; }

        public Guid Author { get; set; }

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
