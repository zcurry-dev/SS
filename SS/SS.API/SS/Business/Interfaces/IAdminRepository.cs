using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SS.Business.Dtos.Accept;
using SS.Business.Dtos.Return;
using SS.Helpers.Pagination.PagedParams;

namespace SS.Business.Interfaces
{
    public interface IAdminRepository
    {
        Task<UserListForAdminReturnDto> GetAllUsersWithRoles(AdminUsersParams adminUsersParams);
        Task<List<RolesToReturnDto>> GetAllAvailibleRoles();
        Task<IdentityResult> UpdateRolesForUser(string userName, RoleEditDto roleEditDto);
        Task<IList<string>> GetRolesForUser(string userName);
    }
}