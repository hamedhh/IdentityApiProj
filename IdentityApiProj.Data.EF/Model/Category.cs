using IdentityApiProj.Data.EF.DbContext;
using IdentityApiProj.Data.EF.Model;

namespace IdentityApiProj.Data.EF.Model
{
    public class Category :BaseModel
    {
        public int id { get; set; }

        public string Name { get; set; }

        public int? ParentID { get; set; }
        public IEnumerable<Category> Childs { get; set; }


        public IEnumerable<Store> stories { get; set; }

    }
}