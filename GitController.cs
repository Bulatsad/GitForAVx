using System;
using System.Collections.Generic;
using System.Linq;
using GitAPI.Context;
using System.Text;
using System.Threading.Tasks;

namespace GitAPI
{
    public class GitController : IGitController
    {
        public GitController() { }

        public Account Account { get; set; }

        public bool AddDeveloper(Developer developer)
        {
            using (var context = new GitContext())
            {
                context.Developers.Add(developer);
                context.SaveChanges();
            }
            return true;
        }

        public bool Commit(Commit commit, int accountId, int projectId)
        {
            using (var commitContext = new GitContext())
            {
                if (commit.DeveloperId == 0)
                {
                    commit.DeveloperId = GetDeveloper(accountId, projectId).Id;
                }
                commitContext.Commits.Add(commit);
                commitContext.SaveChanges();
            }
            return true;
        }

        public bool CreateProject(Project project)
        {
            using (var context = new GitContext())
            {
                context.Projects.Add(project);
                context.Developers.Add(new Developer {
                    AccountId = project.AccountId,
                    ProjectId = project.Id
                });
                context.SaveChanges();
            }
            return true;
        }

        public bool DeleteDeveloper(Developer developer)
        {
            throw new NotImplementedException();
        }

        public Account GetAccount(string nickName)
        {
            using (var accountContext = new GitContext())
            {
                return accountContext.Accounts
                    .Where(q => q.NickName == nickName)
                    .FirstOrDefault();
            }
        }

        public List<Commit> GetCommits(int idProject)
        {
            using (var context = new GitContext())
            {
                return context.Developers
                    .Where(q => q.ProjectId == idProject)
                    .SelectMany(q => q.Commits)
                    .ToList();
            }
        }

        public Developer GetDeveloper(int accountId, int projectId)
        {
            using (var context = new GitContext())
            {
                var developer = context.Developers
                    .Where(q => q.ProjectId == projectId && q.AccountId == accountId)
                    .FirstOrDefault();

                if (developer == null)
                {
                    developer = new Developer
                    {
                        AccountId = accountId,
                        ProjectId = projectId
                    };
                    developer = context.Developers.Add(developer);
                    context.SaveChanges();
                }
                return developer;
            }
        }

        public Project GetProject(string nameProject, string nickNameAutor)
        {
            using (var context = new GitContext())
            {
                return context.Accounts
                    .Where(q => q.NickName == nickNameAutor)
                    .FirstOrDefault()
                    .Projects
                    .Where(q => q.Name == nameProject)
                    .FirstOrDefault();
            }
        }

        public List<Project> GetProjects()
        {
            if (Account != null)
                using (var context = new GitContext())
                {
                    return context.Projects
                        .Where(q => q.AccountId == Account.Id)
                        .ToList();
                }
            else return null;
        }

        public List<Project> GetProjects(string nickName)
        {
            using (var context = new GitContext())
            {
                return context.Accounts
                    .Where(q => q.NickName == nickName)
                    .FirstOrDefault()
                    .Projects
                    .ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="project"></param>
        /// <returns>Возвращает дату коммитов, версию и описание</returns>
        public List<CommitInformation> GetVersionList(Project project)
        {
            using (var projectContext = new GitContext())
            {
                return projectContext.Projects
                    .Where(q => q.Id == project.Id)
                    .FirstOrDefault()
                    .Developers
                    .SelectMany(q => q.Commits)
                    .Select(q => new CommitInformation(new Version(q.Number, q.Article), q.Date, q.Description))
                    .ToList();
            }
        }

        public Commit Pull(Project project, string version)
        {
            using (var commitContext = new GitContext())
            {
                return commitContext.Commits
                    .Where(q => q.Number == version)
                    .FirstOrDefault();
            }
        }

        public bool ResetCommitVersion(string nameProject, string nickNameAutor, Version curr_version, Version new_version)
        {
            throw new NotImplementedException();
        }

        public Account SignIn(string login, string password)
        {
            var account = new Account();

            using (var accountContext = new GitContext())
            {
                var result = accountContext.Accounts
                    .Where(q => q.Login == login && q.Password == password)
                    .FirstOrDefault();

                this.Account = result;

                return result;
            }
        }

        public bool SignUp(Account account)
        {
            using (var accountContext = new GitContext())
            {
                var accountExists = accountContext.Accounts
                    .Where(q => q.Login == account.Login || q.NickName == account.NickName)
                    .FirstOrDefault() != null;

                if (accountExists)
                    return false;

                accountContext.Accounts.Add(account);
                accountContext.SaveChanges();
            }
            return true;
        }
    }
}