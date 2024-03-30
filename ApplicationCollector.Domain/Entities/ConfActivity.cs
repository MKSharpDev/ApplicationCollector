using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCollector.Domain.Entities
{
    public class ConfActivity : BaseEntity<int>
    {
        public string activity {get; set;}
        public string description { get; set;}
        public List<Speaker>? Speakers { get; set; }
    }
}
