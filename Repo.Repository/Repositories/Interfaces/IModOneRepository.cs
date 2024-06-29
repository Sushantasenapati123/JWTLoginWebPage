using System.Collections.Generic;

using Repo.Repository.USP_Customer;
namespace Repo.Repository.Repositories.Interfaces
{
  public interface IModOneRepository
  {
  	 Task<int> I_USP_Customer(USP_Customer_Model TBL);
	
	 Task<int> U_USP_Customer(USP_Customer_Model TBL);
	
	 Task<int> D_USP_Customer(USP_Customer_Model TBL);
	
	 Task<List<VUSP_Customer>> V_USP_Customer(USP_Customer_Model TBL);
	
	 Task<List<EUSP_Customer>> E_USP_Customer(USP_Customer_Model TBL);
	
}
}
