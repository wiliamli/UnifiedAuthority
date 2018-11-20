using Jwell.Domain.Entities;
using Jwell.Framework.Paging;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace Jwell.Domain.Service.Dtos
{
    public class EmployeeRoleDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        [JsonIgnore]
        public long ID { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public long RoleID { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 角色码
        /// </summary>
        public string RoleCode { get; set; }

        /// <summary>
        /// 账户
        /// </summary>
        [JsonIgnore]
        public string Account { get; set; }

        /// <summary>
        /// 服务编号
        /// </summary>
        public string ServiceNumber { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreatedBy { get; set; }

        private DateTime createTime = DateTime.Now;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime
        {
            get
            {
                return createTime;
            }
            set
            {
                if (value != new DateTime(1, 1, 1))
                {
                    createTime = value;
                }
            }
        }

        /// <summary>
        /// 修改人
        /// </summary>
        public string ModifiedBy { get; set; }

        private DateTime modifiedTime = DateTime.Now;
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModifiedTime
        {
            get
            {
                return modifiedTime;
            }
            set
            {
                if (value != new DateTime(1, 1, 1))
                {
                    modifiedTime = value;
                }
            }
        }

        /// <summary>
        /// 是否关联
        /// </summary>
        public bool IsChecked { get; set; }

        /// <summary>
        /// 菜单ID
        /// </summary>
        public long MenuID { get; set; }
    }

    /// <summary>
    /// Mapper
    /// </summary>
    public static class ServiceMenuDtoExt
    {
        public static IQueryable<EmployeeRoleDto> ToDtos(this IQueryable<EmployeeRole> query)
        {
            return from a in query
                   select new EmployeeRoleDto()
                   {
                       ID = a.ID,
                       CreatedBy = a.CreatedBy,
                       CreatedTime = a.CreatedTime,
                       ModifiedBy = a.ModifiedBy,
                       ModifiedTime = a.ModifiedTime,
                       RoleName = a.RoleName,
                       RoleCode = a.RoleCode,
                       Account = a.Account,
                       Remark = a.Remark,
                       ServiceNumber = a.ServiceNumber
                   };
        }

        public static PageResult<EmployeeRoleDto> ToDtos(this PageResult<EmployeeRole> query)
        {
            var queryDto = (from a in query.Pager
                            select new EmployeeRoleDto()
                            {
                                ID = a.ID,
                                CreatedBy = a.CreatedBy,
                                CreatedTime = a.CreatedTime,
                                Account = a.Account,
                                ModifiedBy = a.ModifiedBy,
                                ModifiedTime = a.ModifiedTime,
                                RoleCode = a.RoleCode,
                                RoleName = a.RoleName,
                                Remark = a.Remark,
                                ServiceNumber = a.ServiceNumber
                            }).ToList();

            return new PageResult<EmployeeRoleDto>(queryDto, query.PageIndex, query.PageSize, query.TotalCount);
        }

        public static EmployeeRoleDto ToDto(this EmployeeRole entity)
        {
            EmployeeRoleDto dto = null;
            if (entity != null)
            {
                dto = new EmployeeRoleDto()
                {
                    ID = entity.ID,
                    CreatedBy = entity.CreatedBy,
                    CreatedTime = entity.CreatedTime,
                    Account = entity.Account,
                    ModifiedBy = entity.ModifiedBy,
                    ModifiedTime = entity.ModifiedTime,
                    RoleCode = entity.RoleCode,
                    RoleName = entity.RoleName,
                    Remark = entity.Remark,
                    ServiceNumber = entity.ServiceNumber
                };
            }
            return dto;
        }

        public static EmployeeRole ToEntity(this EmployeeRoleDto dto)
        {
            EmployeeRole entity = null;
            if (dto != null)
            {
                entity = new EmployeeRole()
                {
                    ID = dto.ID,
                    CreatedBy = dto.CreatedBy,
                    CreatedTime = dto.CreatedTime,
                    Account = dto.Account,
                    ModifiedBy = dto.ModifiedBy,
                    ModifiedTime = dto.ModifiedTime,
                    RoleCode = dto.RoleCode,
                    RoleName = dto.RoleName,
                    Remark = dto.Remark,
                    ServiceNumber = dto.ServiceNumber
                };
            }
            return entity;
        }
    }
}
