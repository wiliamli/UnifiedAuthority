using Jwell.Application.Services;
using Jwell.Application.Services.Dtos;
using Jwell.Application.Services.Params;
using Jwell.Framework.Mvc;
using Jwell.Framework.Paging;
using System.Web.Http;

namespace Jwell.UnifiedAuthority.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class EmployeeInfoController : BaseApiController
    {
        private IEmployeeInfoService EmployeeInfoService { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="employeeInfoService"></param>
        public EmployeeInfoController(IEmployeeInfoService employeeInfoService)
        {
            this.EmployeeInfoService = employeeInfoService;
        }

        /// <summary>
        /// 获取待角色的员工信息
        /// </summary>
        /// <param name="searchEmployeeInfo">查询参数</param>
        /// <returns></returns>
        [HttpPost]
        public StandardJsonResult<PageResult<EmployeeInfoDto>> GetEmployeeInfoWithRole(SearchEmployeeInfoParam searchEmployeeInfo)
        {
            StandardJsonResult<PageResult<EmployeeInfoDto>> result = base.StandardAction<PageResult<EmployeeInfoDto>>(() =>
            {
                searchEmployeeInfo.Account = UserInfo.Account;
                PageResult<EmployeeInfoDto> pageResult = EmployeeInfoService.EmployeeInfoWithRole(searchEmployeeInfo);
                return pageResult;
            });
            return result;
        }
    }
}
