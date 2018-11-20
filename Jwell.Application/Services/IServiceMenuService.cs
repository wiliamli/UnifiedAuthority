using Jwell.Application.Services.Dtos;
using Jwell.Framework.Application.Service;
using System.Collections.Generic;

namespace Jwell.Application.Services
{
    public interface IServiceMenuService: IApplicationService
    {
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="serviceMenuDto"></param>
        /// <returns></returns>
        bool Save(ServiceMenuDto serviceMenuDto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceNumber">服务编号</param>
        /// <returns></returns>
        IEnumerable<ServiceMenuDto> GetServiceMenuDtos(string serviceNumber);

        /// <summary>
        /// 根据账户主键获取
        /// </summary>
        /// <param name="serviceNumber"></param>
        /// <returns></returns>
        IEnumerable<TreeMenuDto> GetMenus(string serviceNumber);

        /// <summary>
        /// 查找所有父节点
        /// </summary>
        /// <param name="menuDtos"></param>
        /// <returns></returns>
        IEnumerable<TreeMenuDto> GetParentNodes(IEnumerable<ServiceMenuDto> menuDtos);

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="account">账户</param>
        /// <param name="serviceNumber">服务编号</param>
        /// <param name="menuId">菜单Id</param>
        /// <returns></returns>
        bool DeleteMenus(string account,string serviceNumber, long menuId);
    }
}
