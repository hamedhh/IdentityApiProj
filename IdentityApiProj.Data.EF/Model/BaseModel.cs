using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityApiProj.Data.EF.Model
{
    public abstract class BaseModel
    {
        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset? LastUpdateDate { get; set; }

    }
}
