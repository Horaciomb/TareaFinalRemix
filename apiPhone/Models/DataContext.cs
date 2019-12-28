using System.Data.Entity;

namespace apiPhone.Models
{
    public class DataContext:DbContext
    {
        public DataContext():base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<apiPhone.Models.Phone> Phones { get; set; }
    }
}