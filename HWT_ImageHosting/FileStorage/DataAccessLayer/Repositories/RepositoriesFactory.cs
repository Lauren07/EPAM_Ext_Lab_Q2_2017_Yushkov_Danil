using System.Configuration;
using DataAccessLayer.Repositories.Interfaces;

namespace DataAccessLayer.Repositories
{
    public class RepositoriesFactory
    {
        private string connectionString;
        private const string connectionName = "FileStorageConnection";
        public IFileRepository FileRepository;
        public IUserRepository UserRepository;


        public RepositoriesFactory()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            this.FileRepository = new FileRepository(connectionString);
            this.UserRepository = new UserRepository(connectionString);
        }

    }
}
