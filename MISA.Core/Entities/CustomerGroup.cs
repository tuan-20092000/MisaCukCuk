using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    public class CustomerGroup
    {
        public Guid CustomerGroupId { get; set; }

        public string CustomerGroupName {get; set;}

        public string Description { get; set; }
    }
}
