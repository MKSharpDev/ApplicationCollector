using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCollector.Application
{
    public class ConfApplicationDraftDTO
    {
        public Guid Id { get; set; }

        public Guid Author { get; set; }
        public string? Name { get; set; }
        public string? Activity { get; set; }
        public string? Description { get; set; }
        public string? Outline { get; set; }
    }
}
