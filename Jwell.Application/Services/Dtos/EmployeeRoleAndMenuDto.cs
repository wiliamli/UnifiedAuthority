using Jwell.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Application.Services.Dtos
{
    public class EmployeeRoleAndMenuDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        [JsonIgnore]
        public long ID { get; set; }

        /// <summary>
        /// 菜单ID
        /// </summary>
        public long MenuID { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public long RoleID { get; set; }

        /// <summary>
        /// 账户，唯一分组
        /// </summary>
        [JsonIgnore]
        public string Account { get; set; }

        public string ServiceNumber { get; set; }

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
    public static class EmployeeRoleAndMenuDtoExt
    {
        public static EmployeeRoleAndMenu ToEntity(this EmployeeRoleAndMenuDto dto)
        {
            EmployeeRoleAndMenu entity = null;
            if (dto != null)
            {
                entity = new EmployeeRoleAndMenu()
                {
                    ID = dto.ID,
                    CreatedBy = dto.CreatedBy,
                    CreatedTime = dto.CreatedTime,
                    ModifiedBy = dto.ModifiedBy,
                    ModifiedTime = dto.ModifiedTime,
                    Account = dto.Account,
                    ServiceNumber = dto.ServiceNumber,
                    MenuID = dto.MenuID,
                    RoleID = dto.RoleID
                };
            }
            return entity;
        }
    }
}
