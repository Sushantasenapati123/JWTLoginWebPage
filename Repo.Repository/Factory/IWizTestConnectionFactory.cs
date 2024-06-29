using System.Data;

namespace Repo.Repository.Factory
{
     public interface IWizTestConnectionFactory
    {
        /// <summary>
        /// Gets the get connection.
        /// </summary>
        /// <value>The get connection.</value>
        IDbConnection GetConnection { get; }
    }
}
