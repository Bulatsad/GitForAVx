using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitAPI.Context
{
    public class GitContext : DbContext
    {
        public GitContext() : base("DbConnection")
        { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Commit> Commits { get; set; }
        public DbSet<Developer> Developers { get; set; }
    }
}
