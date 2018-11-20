using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jwell.Application.Services.Dtos;
using Jwell.Domain.Service.Dtos;
using Jwell.Framework.Application.Service;
using Jwell.Repository.Repositories;

namespace Jwell.Application.Services
{
    public class EmployeeRoleService : ApplicationService, IEmployeeRoleService
    {
        private IEmployeeRoleRepository EmployeeRoleRepository { get; set; }

        private IEmployeeRoleRelationRepository  EmployeeRoleRelationRepository { get; set; }

        private IEmployeeRoleAndMenuRepository EmployeeRoleAndMenuRepository { get; set; }


        public EmployeeRoleService(IEmployeeRoleRepository employeeRoleRepository,
            IEmployeeRoleRelationRepository employeeRoleRelationRepository,
            IEmployeeRoleAndMenuRepository employeeRoleAndMenuRepository)
        {
            this.EmployeeRoleRepository = employeeRoleRepository;
            this.EmployeeRoleRelationRepository = employeeRoleRelationRepository;
            this.EmployeeRoleAndMenuRepository = employeeRoleAndMenuRepository;
        }

        public IEnumerable<EmployeeRoleDto> GetEmployeeRolesByEmployeeID(string employeeID, string account, string serviceNumber)
        {
            var query = (from a in this.EmployeeRoleRepository.Queryable()
                         join b in this.EmployeeRoleRelationRepository.Queryable() on new { a.Account, RoleID = a.ID, a.ServiceNumber }
                             equals new { b.Account, b.RoleID, b.ServiceNumber }
                         where b.Account == account && b.EmployeeID == employeeID
                         select a).ToDtos().ToList();
            return query;
        }

        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="dto">角色对象</param>
        /// <returns></returns>
        public bool Save(EmployeeRoleDto dto)
        {
            bool success = false;
            if (dto.RoleName.ToLower().Contains("root"))
            {
                throw new Exception("角色不能包含root关键字");
            }

            if (!IsExist(dto))
            {
                success = EmployeeRoleRepository.Add(dto.ToEntity()) > 0;
            }
            else
            {
                throw new Exception("角色名已存在");
            }
            return success;
        }

        public bool Delete(EmployeeRoleDto dto)
        {
            bool success = false;
            if (dto.RoleName.ToLower().Contains("root"))
            {
                throw new Exception("角色不能包含root关键字");
            }

            success = EmployeeRoleRepository.Delete(dto.ToEntity()) > 0;

            return success;
        }

        /// <summary>
        /// 是否已存在角色
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        private bool IsExist(EmployeeRoleDto dto)
        {
            return EmployeeRoleRepository.Queryable().
                FirstOrDefault(m => m.RoleCode == dto.RoleCode && m.Account == dto.Account 
                && m.ServiceNumber == dto.ServiceNumber) != null;
        }

        /// <summary>
        /// 根据账户获取员工角色
        /// </summary>
        /// <param name="account">账户</param>
        /// <param name="serviceNumber">服务编号</param>
        /// <returns></returns>
        public IEnumerable<EmployeeRoleDto> GetEmployeeRolesByAccount(string account,string serviceNumber)
        {
            return EmployeeRoleRepository.Queryable().
                Where(m => m.Account == account && m.ServiceNumber== serviceNumber).ToDtos().ToList();
        }

        public IEnumerable<EmployeeRoleDto> GetEmployeeRolesByMenuID(string account, string serviceNumber, long menuID)
        {
            var roles = this.EmployeeRoleRepository.Queryable().Where(m => m.Account == account && m.ServiceNumber == serviceNumber);

            var roleAndMenu = this.EmployeeRoleAndMenuRepository.Queryable().Where(m => m.Account == account && m.ServiceNumber == serviceNumber);

            var query = (from a in roles
                         join b in roleAndMenu on new { RoleID = a.ID, MeunID = menuID }
                         equals new { b.RoleID, MeunID = b.MenuID } into temp1
                         from t in temp1.DefaultIfEmpty()
                         select new EmployeeRoleDto
                         {
                             Account = account,
                             CreatedBy = a.CreatedBy,
                             CreatedTime = a.CreatedTime,
                             ID = a.ID,
                             IsChecked = t != null,
                             MenuID = menuID,
                             ModifiedBy = a.ModifiedBy,
                             ModifiedTime = a.ModifiedTime,
                             RoleCode = a.RoleCode,
                             RoleName = a.RoleName,
                             ServiceNumber = a.ServiceNumber,
                             Remark = a.Remark,
                             RoleID = a.ID
                         }).ToList();

            return query;
        }


        /// <summary>
        /// 解除角色 与 用户关系
        /// </summary>
        /// <param name="employeeRoleAndMenuDto">角色与用户</param>
        /// <returns></returns>
        public bool Disengagement(EmployeeRoleAndMenuDto employeeRoleAndMenuDto)
        {
            return EmployeeRoleAndMenuRepository.Delete(employeeRoleAndMenuDto.ToEntity()) > 0;
        }

        /// <summary>
        /// 解除用户与角色的关系
        /// </summary>
        /// <param name="employeeRoleRelationDto"></param>
        /// <returns></returns>
        public bool DeleteEmployeeRoleRelation(EmployeeRoleRelationDto  employeeRoleRelationDto)
        {
            return EmployeeRoleRelationRepository.DeleteEmployeeRoleRelation(employeeRoleRelationDto.ToEntity()) > 0;
        }

        public bool DeleteRole(string account, string serviceNumber, string roleCode)
        {
            return EmployeeRoleRepository.Delete(new Domain.Entities.EmployeeRole()
            {
                Account = account,
                ServiceNumber = serviceNumber,
                RoleCode = roleCode,
                CreatedBy = account,
                ModifiedBy = account
            }) > 0;
        }

        public bool SaveEmployeeRole(IEnumerable<EmployeeRoleRelationDto> employeeRoleDto)
        {
            bool success = false;
            foreach (var item in employeeRoleDto)
            {
                success = EmployeeRoleRelationRepository.Add(item.ToEntity()) > 0;
            }
            return success;
        }
    }
}
