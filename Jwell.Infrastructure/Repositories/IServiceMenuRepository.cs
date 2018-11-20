using Jwell.Domain.Entities;
using System.Collections.Generic;
using Jwell.Framework.Domain.Repositories;

namespace Jwell.Repository.Repositories
{
    public interface IServiceMenuRepository: IRepository<ServiceMenu, long>
    {
        /// <summary>
        /// 根据账户获取菜单列表
        /// </summary>
        /// <param name="serviceNumber">服务编号</param>
        /// <returns>菜单列表</returns>
        IEnumerable<ServiceMenu> Queryable(string serviceNumber);

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="menuIds">菜单数组</param>
        /// <param name="serviceNumber">服务编号</param>
        /// <param name="account">账户</param>
        /// <returns></returns>
        int DeleteMenus(string serviceNumber, string account, IEnumerable<long> menuIds);
    }
}
