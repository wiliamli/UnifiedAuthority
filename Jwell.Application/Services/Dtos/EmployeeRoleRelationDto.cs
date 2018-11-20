using Jwell.Domain.Entities;
using Newtonsoft.Json;
using System;

namespace Jwell.Application.Services.Dtos
{
    public class EmployeeRoleRelationDto
    {
        public string ServiceNumber { get; set; }

        /// <summary>
        /// 员工编号
        /// </summary>
        public string EmployeeID { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public long RoleID { get; set; }

        /// <summary>
        /// 账户，唯一分组
        /// </summary>
        [JsonIgnore]
        public string Account { get; set; }

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
    }

    /// <summary>
    /// Mapper
    /// </summary>
    public static class EmployeeRoleRelationDtoExt
    {
        public static EmployeeRoleRelation ToEntity(this EmployeeRoleRelationDto dto)
        {
            EmployeeRoleRelation entity = null;
            if (dto != null)
            {
                entity = new EmployeeRoleRelation()
                {
                    CreatedBy = dto.CreatedBy,
                    CreatedTime = dto.CreatedTime,
                    Account = dto.Account,
                    ModifiedBy = dto.ModifiedBy,
                    ModifiedTime = dto.ModifiedTime,
                    EmployeeID = dto.EmployeeID,
                    RoleID = dto.RoleID,
                    ServiceNumber = dto.ServiceNumber
                };
            }
            return entity;
        }
    }
}
