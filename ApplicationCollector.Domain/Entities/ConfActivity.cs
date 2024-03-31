using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCollector.Domain.Entities
{
    public class ConfActivity : BaseEntity<Guid>
    {
        public string Activity {get; set;}
        public string Description { get; set;}
        public List<Speaker>? Speakers { get; set; }
    }
}
