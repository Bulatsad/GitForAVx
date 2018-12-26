using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitAPI
{
    public class Developer
    {
        public int Id { get; set; }

        public int? AccountId { get; set; }
        public Account Account{ get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public List<Commit> Commits { get; set; }
    }
}