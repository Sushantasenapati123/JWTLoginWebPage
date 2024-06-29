using System.Collections.Generic;
using Repo.Repository.Factory;
using Repo.Repository.BaseRepository;
using Repo.Repository.Repositories.Interfaces;
using Repo.Repository;

using Repo.Repository.USP_DIST_NoUpdate;
using Dapper;
using System.Data;
namespace Repo.Repository.Repository
{
	public class ModTwoRepository:WizTestRepositoryBase,IModTwoRepository
	{
		public ModTwoRepository(IWizTestConnectionFactory WizTestConnectionFactory) : base(WizTestConnectionFactory)
        {

        }
		 public async Task<int> I_USP_DIST_NoUpdate(USP_DIST_NoUpdate_Model TBL)
	{
				var p = new DynamicParameters();
		p.Add("@P_Action ", "I");
		p.Add("@P_DistId", TBL.P_DistId);
		p.Add("@P_StateName", TBL.P_StateName);
		p.Add("@P_DistName", TBL.P_DistName);
		var results = await Connection.ExecuteAsync("USP_DIST_NoUpdate", p, commandType: CommandType.StoredProcedure);
		return 1;

		}
	 public async Task<int> D_USP_DIST_NoUpdate(USP_DIST_NoUpdate_Model TBL)
	{
				var p = new DynamicParameters();
		p.Add("@P_Action ", "D");
		p.Add("@P_DistId", TBL.P_DistId);
		p.Add("@P_StateName", TBL.P_StateName);
		p.Add("@P_DistName", TBL.P_DistName);
		var results = await Connection.ExecuteAsync("USP_DIST_NoUpdate", p, commandType: CommandType.StoredProcedure);
		return 1;

		}
	 public async Task<List<VUSP_DIST_NoUpdate>> V_USP_DIST_NoUpdate(USP_DIST_NoUpdate_Model TBL)
	{
				var p = new DynamicParameters();
		p.Add("@P_Action ", "V");
		p.Add("@P_DistId", TBL.P_DistId);
		p.Add("@P_StateName", TBL.P_StateName);
		p.Add("@P_DistName", TBL.P_DistName);
		var results = await Connection.QueryAsync<VUSP_DIST_NoUpdate>("USP_DIST_NoUpdate", p, commandType: CommandType.StoredProcedure);
		return results.ToList();

		}
	 public async Task<List<EUSP_DIST_NoUpdate>> E_USP_DIST_NoUpdate(USP_DIST_NoUpdate_Model TBL)
	{
				var p = new DynamicParameters();
		p.Add("@P_Action ", "E");
		p.Add("@P_DistId", TBL.P_DistId);
		p.Add("@P_StateName", TBL.P_StateName);
		p.Add("@P_DistName", TBL.P_DistName);
		var results = await Connection.QueryAsync<EUSP_DIST_NoUpdate>("USP_DIST_NoUpdate", p, commandType: CommandType.StoredProcedure);
		return results.ToList();

		}
	 public async Task<List<SUSP_DIST_NoUpdate>> S_USP_DIST_NoUpdate(USP_DIST_NoUpdate_Model TBL)
	{
				var p = new DynamicParameters();
		p.Add("@P_Action ", "S");
		p.Add("@P_DistId", TBL.P_DistId);
		p.Add("@P_StateName", TBL.P_StateName);
		p.Add("@P_DistName", TBL.P_DistName);
		var results = await Connection.QueryAsync<SUSP_DIST_NoUpdate>("USP_DIST_NoUpdate", p, commandType: CommandType.StoredProcedure);
		return results.ToList();

		}
}
}
