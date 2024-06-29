using System.Data;
using JwtloginModel.Model.LoginEntity;


namespace JwtLogin.Repository.Repositories.Interfaces
{
	public interface IJwtRepository
    {
        /// <summary>
        /// Retrive User details against User Name
        /// </summary>
        /// <param name="uname"></param>
        /// <returns></returns>
        public Task<List<LoginEntity>> GetByUserIdAsync(string uname);
    }
}
