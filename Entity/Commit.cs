using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitAPI
{
    public class Commit
    {
        public Commit() { }
        public Commit(string code, DateTime date, string version)
        {
            this.Code = code;
            this.Date = date;
            this.Number = version;
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public string Code { get; set; }
        public string Number { get; set; }
        public string Article { get; set; }

        // Связи
        public int DeveloperId { get; set; }
        public virtual Developer Developer { get; set; }

        public override string ToString()
        {
            return $@"date : {Date.ToString()}\n\nVersion : {Code.ToString()}\nDescription : {Description}";
        }
    }
}