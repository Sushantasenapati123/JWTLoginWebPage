using CodeGen.Model.Set_Permission;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeGen.Repository.Repositories.Interfaces
{       
	 

    public interface ISetPermissionServiceProvider
    {
        Task<SetPermissionModel> GetAllPrimaryLinkByGlobalLink(SetPermissionModel objpermission);
        Task<SetPermissionModel> GetAllPrimaryLinkByGlobalLinkUserwise(SetPermissionModel objpermission);
        string SetPermissionLink_Designation(int designationId, int Plinkid, int Intaccess, int user, int projectId);
        string SetPermissionLink_User(int userId, int Plinkid, int Intaccess, int user, int projectId);
        string DeletePermissionLink_Designation(int DesignationId, int projectId);
        string DeletePermissionLink_User(int userId, int projectId);
        Task<SetPermissionModel> GetAllUser();
        string RemovePermissionList_User(int userId,int updatedby);
    }
}
