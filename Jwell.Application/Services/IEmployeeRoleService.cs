using Jwell.Application.Services.Dtos;
using Jwell.Domain.Service.Dtos;
using Jwell.Framework.Application.Service;
using System.Collections.Generic;

namespace Jwell.Application.Services
{
    public interface IEmployeeRoleService : IApplicationService
    {
        /// <summary>
        /// 根据员工编号获取角色信息
        /// </summary>
        /// <param name="employeeID">员工编号</param>
        /// <param name="account">账户</param>
        /// <returns>角色信息</returns>
        IEnumerable<EmployeeRoleDto> GetEmployeeRolesByEmployeeID(string employeeID, string account, string serviceNumber);

        /// <summary>
        /// 根据登录账户获取角色信息
        /// </summary>
        /// <param name="account">账户</param>
        /// <returns>角色信息</returns>
        IEnumerable<EmployeeRoleDto> GetEmployeeRolesByAccount(string account, string serviceNumber);

        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="dto">角色对象</param>
        /// <returns></returns>
        bool Save(EmployeeRoleDto dto);

        /// <summary>
        /// 根据菜单ID获取角色信息
        /// </summary>
        /// <param name="account">账户</param>
        /// <param name="serviceNumber">服务编号</param>
        /// <param name="menuID">菜单ID</param>
        /// <returns></returns>
        IEnumerable<EmployeeRoleDto> GetEmployeeRolesByMenuID(string account, string serviceNumber, long menuID);

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="account">账户</param>
        /// <param name="serviceNumber">服务编号</param>
        /// <param name="roleCode">角色码</param>
        bool DeleteRole(string account, string serviceNumber, string roleCode);

        /// <summary>
        /// 解除角色 与 菜单关系
        /// </summary>
        /// <param name="employeeRoleAndMenuDto">角色与菜单</param>
        /// <returns></returns>
        bool Disengagement(EmployeeRoleAndMenuDto employeeRoleAndMenuDto);

        /// <summary>
        /// 解除角色与用户的关系
        /// </summary>
        /// <param name="employeeRoleRelationDto">用户与角色</param>
        /// <returns></returns>
        bool DeleteEmployeeRoleRelation(EmployeeRoleRelationDto employeeRoleRelationDto);

        /// <summary>
        /// 保存员工角色关系
        /// </summary>
        /// <param name="employeeRoleDto">员工角色关系</param>
        /// <returns></returns>
        bool SaveEmployeeRole(IEnumerable<EmployeeRoleRelationDto> employeeRoleDto);
    }
}
