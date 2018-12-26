using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitAPI
{
    public class Project
    {
        public Project() { }
        public Project(
            string name,
            string description,
            int accountId)
        {
            this.Description = description;
            this.Name = name;
            this.AccountId = accountId;

            this.Developers = new List<Developer>();
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Связи
        public int AccountId { get; set; }
        public Account Account { get; set; }

        public virtual List<Developer> Developers { get; set; }

        public override string ToString() => $"name : {Name}";
    }
}
