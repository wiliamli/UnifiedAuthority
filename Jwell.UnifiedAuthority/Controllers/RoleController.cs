using Jwell.Application.Services;
using Jwell.Application.Services.Dtos;
using Jwell.Domain.Service.Dtos;
using Jwell.Framework.Mvc;
using Jwell.UnifiedAuthority.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Jwell.UnifiedAuthority.Controllers
{
    /// <summary>
    /// 角色
    /// </summary>
    [LoginFilter]
    public class RoleController : BaseApiController
    {
        private IEmployeeRoleService EmployeeRoleService { get; set; }

        /// <summary>
        /// 构造器
        /// </summary>
        public RoleController(IEmployeeRoleService employeeRoleService)
        {
            this.EmployeeRoleService = employeeRoleService;
        }

        /// <summary>
        /// 根据菜单获取角色
        /// </summary>
        /// <param name="serviceNumbner">账户</param>
        /// <param name="menuID">菜单ID</param>
        /// <returns></returns>
        [HttpGet]
        public StandardJsonResult<IEnumerable<EmployeeRoleDto>> GetEmployeeRolesByMenuID(string serviceNumbner, long menuID)
        {
            return base.StandardAction<IEnumerable<EmployeeRoleDto>>(() => {
                string account = UserInfo.Account;
                return this.EmployeeRoleService.GetEmployeeRolesByMenuID(account, serviceNumbner, menuID);
            });
        }

        /// <summary>
        /// 根据账户获取菜单
        /// </summary>
        /// <param name="serviceNumber">服务编号</param>
        /// <returns></returns>
        [HttpGet]
        public StandardJsonResult<IEnumerable<EmployeeRoleDto>> GetEmployeeRoles(string serviceNumber)
        {
            return base.StandardAction<IEnumerable<EmployeeRoleDto>>(() => {
                string account = UserInfo.Account;
                return this.EmployeeRoleService.GetEmployeeRolesByAccount(account, serviceNumber);
            });
        }

        /// <summary>
        /// 保存角色
        /// </summary>
        /// <param name="employeeRoleDto">角色信息</param>
        /// <returns></returns>
        [HttpPost]
        public StandardJsonResult<bool> Save(EmployeeRoleDto employeeRoleDto)
        {
            return base.StandardAction<bool>(() => {
                employeeRoleDto.Account = UserInfo.Account;
                employeeRoleDto.CreatedBy = employeeRoleDto.Account;
                employeeRoleDto.ModifiedBy = employeeRoleDto.Account;
                return this.EmployeeRoleService.Save(employeeRoleDto);
            });
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="serviceNumber">服务编号</param>
        /// <param name="roleCode">角色码</param>
        /// <returns></returns>
        [HttpGet]
        public StandardJsonResult<bool> DeleteRole(string serviceNumber, string roleCode)
        {
            return base.StandardAction<bool>(() => {
                string account = UserInfo.Account;
                return this.EmployeeRoleService.DeleteRole(account,serviceNumber,roleCode);
            });
        }

        /// <summary>
        /// 解除菜单与角色关系
        /// </summary>
        /// <param name="serviceNumber">服务编号</param>
        /// <param name="menuId">菜单Id</param>
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        [HttpGet]
        public StandardJsonResult<bool> Disengagement(string serviceNumber, int menuId, int roleId)
        {
            return base.StandardAction<bool>(() =>
            {
                return this.EmployeeRoleService.Disengagement(new EmployeeRoleAndMenuDto()
                {
                    Account = UserInfo.Account,
                    MenuID = menuId,
                    RoleID = roleId,
                    ServiceNumber = serviceNumber

                });
            });
        }

        /// <summary>
        /// 解除关系
        /// </summary>
        /// <param name="serviceNumber">服务编号</param>
        /// <param name="employeeID">员工ID</param>
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        [HttpGet]
        public StandardJsonResult<bool> DeleteEmployeeRoleRelation(string serviceNumber, string employeeID, int roleId)
        {
            return base.StandardAction<bool>(() =>
            {
                return this.EmployeeRoleService.DeleteEmployeeRoleRelation(new EmployeeRoleRelationDto()
                {
                    Account = UserInfo.Account,
                    EmployeeID = employeeID,
                    RoleID = roleId,
                    ServiceNumber = serviceNumber

                });
            });
        }

        /// <summary>
        /// 保存员工角色关系
        /// </summary>
        /// <param name="employeeRoleDto">员工角色关系</param>
        /// <returns></returns>
        [HttpPost]
        public StandardJsonResult<bool> SaveEmployeeRole(IEnumerable<EmployeeRoleRelationDto> employeeRoleDto)
        {
            return base.StandardAction<bool>(() =>
            {
                string account = UserInfo.Account;
                foreach (var item in employeeRoleDto)
                {
                    item.Account = account;
                }
                return this.EmployeeRoleService.SaveEmployeeRole(employeeRoleDto);
            });
        }
    }
}
