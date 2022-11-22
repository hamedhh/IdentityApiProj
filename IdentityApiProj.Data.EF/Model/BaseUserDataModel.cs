using IdentityApiProj.Data.EF.Model;

namespace IdentityApiProj.Data.EF.DbContext
{
    public class BaseUserDataModel : BaseModel
    {
        public int UserId { get; set; }
    }
}