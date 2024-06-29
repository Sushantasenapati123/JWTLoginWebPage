using System.Collections.Generic;

using Repo.Repository.USP_DIST_NoUpdate;
namespace Repo.Repository.Repositories.Interfaces
{
  public interface IModTwoRepository
  {
  	 Task<int> I_USP_DIST_NoUpdate(USP_DIST_NoUpdate_Model TBL);
	
	 Task<int> D_USP_DIST_NoUpdate(USP_DIST_NoUpdate_Model TBL);
	
	 Task<List<VUSP_DIST_NoUpdate>> V_USP_DIST_NoUpdate(USP_DIST_NoUpdate_Model TBL);
	
	 Task<List<EUSP_DIST_NoUpdate>> E_USP_DIST_NoUpdate(USP_DIST_NoUpdate_Model TBL);
	
	 Task<List<SUSP_DIST_NoUpdate>> S_USP_DIST_NoUpdate(USP_DIST_NoUpdate_Model TBL);
	
}
}
