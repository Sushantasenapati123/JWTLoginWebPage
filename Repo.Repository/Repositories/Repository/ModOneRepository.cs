using System.Collections.Generic;
using Repo.Repository.Factory;
using Repo.Repository.BaseRepository;
using Repo.Repository.Repositories.Interfaces;
using Repo.Repository;

using Repo.Repository.USP_Customer;
using Dapper;
using System.Data;
namespace Repo.Repository.Repository
{
	public class ModOneRepository:WizTestRepositoryBase,IModOneRepository
	{
		public ModOneRepository(IWizTestConnectionFactory WizTestConnectionFactory) : base(WizTestConnectionFactory)
        {

        }
			 public async Task<int> I_USP_Customer(USP_Customer_Model TBL)
		{
					var p = new DynamicParameters();
			p.Add("@P_Action ", "I");
			p.Add("@P_CustID", TBL.P_CustID);
			p.Add("@P_CustomerName", TBL.P_CustomerName);
			p.Add("@P_CustomerEmail", TBL.P_CustomerEmail);
			p.Add("@P_CustomerMobile", TBL.P_CustomerMobile);
			p.Add("@P_CustomerDocument", TBL.P_CustomerDocument);
			var results = await Connection.ExecuteAsync("USP_Customer", p, commandType: CommandType.StoredProcedure);
			return 1;

			}
	 public async Task<int> U_USP_Customer(USP_Customer_Model TBL)
	{
				var p = new DynamicParameters();
		p.Add("@P_Action ", "U");
		p.Add("@P_CustID", TBL.P_CustID);
		p.Add("@P_CustomerName", TBL.P_CustomerName);
		p.Add("@P_CustomerEmail", TBL.P_CustomerEmail);
		p.Add("@P_CustomerMobile", TBL.P_CustomerMobile);
		p.Add("@P_CustomerDocument", TBL.P_CustomerDocument);
		var results = await Connection.ExecuteAsync("USP_Customer", p, commandType: CommandType.StoredProcedure);
		return 1;

		}
	 public async Task<int> D_USP_Customer(USP_Customer_Model TBL)
	{
				var p = new DynamicParameters();
		p.Add("@P_Action ", "D");
		p.Add("@P_CustID", TBL.P_CustID);
		p.Add("@P_CustomerName", TBL.P_CustomerName);
		p.Add("@P_CustomerEmail", TBL.P_CustomerEmail);
		p.Add("@P_CustomerMobile", TBL.P_CustomerMobile);
		p.Add("@P_CustomerDocument", TBL.P_CustomerDocument);
		var results = await Connection.ExecuteAsync("USP_Customer", p, commandType: CommandType.StoredProcedure);
		return 1;

		}
	 public async Task<List<VUSP_Customer>> V_USP_Customer(USP_Customer_Model TBL)
	{
				var p = new DynamicParameters();
		p.Add("@P_Action ", "V");
		p.Add("@P_CustID", TBL.P_CustID);
		p.Add("@P_CustomerName", TBL.P_CustomerName);
		p.Add("@P_CustomerEmail", TBL.P_CustomerEmail);
		p.Add("@P_CustomerMobile", TBL.P_CustomerMobile);
		p.Add("@P_CustomerDocument", TBL.P_CustomerDocument);
		var results = await Connection.QueryAsync<VUSP_Customer>("USP_Customer", p, commandType: CommandType.StoredProcedure);
		return results.ToList();

		}
	 public async Task<List<EUSP_Customer>> E_USP_Customer(USP_Customer_Model TBL)
	{
				var p = new DynamicParameters();
		p.Add("@P_Action ", "E");
		p.Add("@P_CustID", TBL.P_CustID);
		p.Add("@P_CustomerName", TBL.P_CustomerName);
		p.Add("@P_CustomerEmail", TBL.P_CustomerEmail);
		p.Add("@P_CustomerMobile", TBL.P_CustomerMobile);
		p.Add("@P_CustomerDocument", TBL.P_CustomerDocument);
		var results = await Connection.QueryAsync<EUSP_Customer>("USP_Customer", p, commandType: CommandType.StoredProcedure);
		return results.ToList();

		}
}
}
