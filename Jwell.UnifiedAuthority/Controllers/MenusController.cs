using Jwell.Application.Services;
using Jwell.Application.Services.Dtos;
using Jwell.Framework.Mvc;
using Jwell.UnifiedAuthority.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Jwell.UnifiedAuthority.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [LoginFilter]
    public class MenusController : BaseApiController
    {
        private IServiceMenuService ServiceMenuService { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceMenuService"></param>
        public MenusController(IServiceMenuService serviceMenuService)
        {
            this.ServiceMenuService = serviceMenuService;
        }

        /// <summary>
        /// 新增菜单
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public StandardJsonResult Save(ServiceMenuDto dto)
        {
            return base.StandardAction(() => {
                dto.Account = UserInfo.Account;
                ServiceMenuService.Save(dto);
            });
        }

        /// <summary>
        /// 菜单列表
        /// </summary>
        /// <param name="serviceNumber">服务编号</param>
        /// <returns></returns>
        [HttpGet]
        public StandardJsonResult<IEnumerable<TreeMenuDto>> GetAllMenus(string serviceNumber)
        {
            return base.StandardAction<IEnumerable<TreeMenuDto>>(() => {
                return ServiceMenuService.GetMenus(serviceNumber);
            });
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="serviceNumber"></param>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public StandardJsonResult<bool> DeleteMenus( string serviceNumber, long menuId)
        {
            return base.StandardAction<bool>(() =>
            {
                 string account = UserInfo.Account;
                return ServiceMenuService.DeleteMenus(account, serviceNumber, menuId);
            });
        }
    }
}