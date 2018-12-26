using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitAPI
{
    public class Account
    {
        public Account() { }
        public Account(
            string userNickName,
            string userLogin,
            string userPassword,
            string userEmail,
            int userId,
            List<Project> projects)
        {
            this.NickName = userNickName;
            this.Login = userLogin;
            this.Password = userPassword;
            this.Email = userEmail;
            this.Projects = projects;
        }

        public int Id { get; set; }
        public string NickName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        // Связи
        public virtual List<Project> Projects { get; set; }

        public override string ToString()
        {
            return
                $@"Nick : {NickName}\n 
                Login : {Login}\n
                Email : {Email}\n
                ID : {Id}";
        }

    }
}
