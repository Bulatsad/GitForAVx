using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitAPI
{
    public interface IGitController
    {
        Account SignIn(string login, string password);

        List<CommitInformation> GetVersionList(Project project); // Return date version description

        Commit Pull(Project project, string version);

        Project GetProject(string nameProject, string nickNameAutor);

        Account GetAccount(string nickName);

        List<Commit> GetCommits(int idProject);

        List<Project> GetProjects();

        List<Project> GetProjects(string nickName);

        bool AddDeveloper(Developer developer);

        bool SignUp(Account account);

        bool Commit(Commit commit, int accountId, int projectId);

        bool DeleteDeveloper(Developer developer);

        bool ResetCommitVersion(string nameProject, string nickNameAutor, Version curr_version, Version new_version);

        bool CreateProject(Project project);

        Developer GetDeveloper(int accountId, int projectId);
    }
}