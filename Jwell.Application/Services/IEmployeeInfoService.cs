using Jwell.Application.Services.Dtos;
using Jwell.Application.Services.Params;
using Jwell.Framework.Application.Service;
using Jwell.Framework.Paging;
using System.Collections.Generic;

namespace Jwell.Application.Services
{
    public interface IEmployeeInfoService : IApplicationService
    {
        /// <summary>
        /// 根据账户获取对应员工角色
        /// </summary>
        /// <param name="searchEmployeeInfoParam">参数信息</param>
        /// <returns></returns>
        PageResult<EmployeeInfoDto> EmployeeInfoWithRole(SearchEmployeeInfoParam searchEmployeeInfoParam);

        /// <summary>
        /// 获取员工信息
        /// </summary>
        /// <param name="searchEmployee">参数信息</param>
        /// <returns></returns>
        //PageResult<EmployeeInfoDto> GetEmployeeInfoes(SearchEmployeeInfoParam searchEmployee);
    }
}
