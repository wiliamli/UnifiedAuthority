using Jwell.Application.Services;
using Jwell.Application.Services.Dtos;
using Jwell.Domain.Entities;
using Jwell.Framework.Domain.Repositories;
using Jwell.Framework.Application.Service;
using Jwell.Modules.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using Jwell.Repository.Repositories;

namespace Jwell.Application
{
    /// <summary>
    /// 
    /// </summary>
    public class ServiceMenuService : ApplicationService, IServiceMenuService
    {
        private IServiceMenuRepository Repository { get; set; }
        private ICacheClient CacheClient { get; set; }
        private IEmployeeRoleAndMenuRepository EmployeeRoleAndMenuRepository { get; set; }
        private IEnumerable<TreeMenuDto> Menus { get; set; } = new List<TreeMenuDto> ();

        private IEmployeeRoleRepository EmployeeRoleRepository { get; set; }

        private List<long> menuIds = new List<long>();

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="cacheClient"></param>
        public ServiceMenuService(IServiceMenuRepository repository,
            IEmployeeRoleAndMenuRepository employeeRoleAndMenuRepository
            , ICacheClient cacheClient,
            IEmployeeRoleRepository employeeRoleRepository)
        {
            Repository = repository;
            CacheClient = cacheClient;
            EmployeeRoleAndMenuRepository = employeeRoleAndMenuRepository;
            EmployeeRoleRepository = employeeRoleRepository;
        }

        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="serviceMenuDto"></param>
        /// <returns></returns>
        public bool Save(ServiceMenuDto serviceMenuDto)
        {
            bool success = false;

            if (serviceMenuDto.ID > 0)
            {
                serviceMenuDto.ModifiedTime = DateTime.Now;
                success = Repository.Update(serviceMenuDto.ToEntity()) > 0;
            }
            else
            {
                serviceMenuDto.CreatedTime = DateTime.Now;
                serviceMenuDto.ModifiedTime = DateTime.Now;

                success = Repository.Add(serviceMenuDto.ToEntity()) > 0;
            }
            return success;
        }

        public IEnumerable<ServiceMenuDto> GetServiceMenuDtos(string serviceNumber)
        {
            //TODO：所有菜单缓存应缓存？
            var serviceMenus = Repository.Queryable(serviceNumber);

            var query = (from a in serviceMenus
                         join b in EmployeeRoleAndMenuRepository.Queryable() on new { a.Account, MenuID = a.ID } equals new { b.Account, b.MenuID } into temp
                         from t in temp.DefaultIfEmpty()
                         join c in EmployeeRoleRepository.Queryable() on new { RoleID = t != null ? t.RoleID : 0 } equals new { RoleID = c.ID } into temp2
                         from t2 in temp2.DefaultIfEmpty()
                         select new ServiceMenuDto()
                         {
                             Account = a.ServiceNumber,
                             CreatedBy = a.CreatedBy,
                             CreatedTime = a.CreatedTime,
                             ID = a.ID,
                             MenuType = a.MenuType,
                             ModifiedBy = a.ModifiedBy,
                             ModifiedTime = a.ModifiedTime,
                             Name = a.Name,
                             EnName = a.EnName,
                             ServiceNumber = a.ServiceNumber,
                             ParentID = a.ParentID,
                             Remark = a.Remark,
                             RoleID = t != null ? t.RoleID : 0,
                             RoleName = t2 != null ? t2.RoleName : string.Empty,
                             Url = a.Url
                         }).ToList();
            return query;
        }

        public IEnumerable<TreeMenuDto> GetMenus(string account)
        {
            IEnumerable<ServiceMenuDto> menuDtos = GetServiceMenuDtos(account);

            GetParentNodes(menuDtos);

            return TreeMenus(Menus, menuDtos.ToTreeMenu());
        }

        /// <summary>
        /// 找出所有父节点
        /// </summary>
        /// <param name="menuDtos"></param>
        /// <returns></returns>
        public IEnumerable<TreeMenuDto> GetParentNodes(IEnumerable<ServiceMenuDto> menuDtos)
        {
            Menus = menuDtos.Where(m => m.ParentID == 0).ToTreeMenu();
            return Menus;
        }

        /// <summary>
        /// 构造树形菜单
        /// </summary>
        /// <param name="allParentNodes"></param>
        /// <param name="menuDtos"></param>
        /// <returns></returns>
        private IEnumerable<TreeMenuDto> TreeMenus(IEnumerable<TreeMenuDto> allParentNodes, 
            IEnumerable<TreeMenuDto> menuDtos)
        {
            //支持多级
            foreach (var item in allParentNodes)
            {
                ChildrenNodes(item, menuDtos);
            }
            return Menus;
        }

        /// <summary>
        /// 添加孩子节点
        /// </summary>
        /// <param name="curParentNode">当前父节点</param>
        /// <param name="menuDtos"></param>
        private void ChildrenNodes(TreeMenuDto curParentNode,
            IEnumerable<TreeMenuDto> menuDtos)
        {
            var childNodes = menuDtos.Where(m => m.ParentID == curParentNode.ID);

            curParentNode.ChildNodes.AddRange(childNodes);

            foreach (var item in childNodes)
            {
                ChildrenNodes(item, menuDtos);
            }
        }

        public bool DeleteMenus(string account, string serviceNumber, long menuId)
        {
            bool success = false;

            var query = Repository.Queryable(serviceNumber).Where(m => m.Account == account).ToDtos();

            if (query != null && query.Count() > 0)
            {
                IEnumerable<long> menuIds = GetMenuIds(menuId, query);

                success = Repository.DeleteMenus(serviceNumber, account, menuIds) > 0;
            }

            return success;
        }

        private List<long> GetMenuIds(long curMenuId,IEnumerable<ServiceMenuDto> serviceMenus)
        {
            IEnumerable<ServiceMenuDto> curMenus = serviceMenus.Where(m => m.ParentID == curMenuId);
            menuIds.Add(curMenuId);
            if (curMenus.Count() > 0)
            {
                foreach (var item in curMenus)
                {
                    GetMenuIds(item.ID,curMenus);
                }
            }
            return menuIds;
        }

        
    }
}
