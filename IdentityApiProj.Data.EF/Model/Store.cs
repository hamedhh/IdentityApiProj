using IdentityApiProj.Data.EF.DbContext;

namespace IdentityApiProj.Data.EF.Model
{
    public class Store : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
    }
}