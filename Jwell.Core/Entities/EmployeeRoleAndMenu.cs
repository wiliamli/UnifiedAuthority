﻿using Jwell.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Jwell.Domain.Entities
{
    [Table("EmployeeRoleAndMenu")]
    public class EmployeeRoleAndMenu:BaseEntity
    {
        [Column("ServiceNumber")]
        public string ServiceNumber { get; set; }

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
        public string Account { get; set;}

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

        public static string SQL()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT \"ID\",");
            sql.Append(" \"MenuID\",");
            sql.Append(" \"RoleID\",");
            sql.Append(" \"Account\",");
            sql.Append(" \"CreatedBy\",");
            sql.Append(" \"CreatedTime\",");
            sql.Append(" \"ModifiedBy\",");
            sql.Append(" \"ModifiedTime\" ");
            sql.Append(" FROM \"JWELL_AUTHORITY\".\"EmployeeRoleAndMenu\" ");
            sql.Append(" WHERE 1=1 ");
            return sql.ToString();
        }
    }
}
