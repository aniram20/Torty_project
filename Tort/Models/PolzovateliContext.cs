using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Tort.Models
{
    public class PolzovateliContext : DbContext
    {
        public PolzovateliContext() : base("DefaultConnection")
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
