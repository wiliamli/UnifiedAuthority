using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Jwell.Domain.Entities.Base;

namespace Jwell.Domain.Entities
{
    [Table("ServiceMenu")]
    public class ServiceMenu : BaseEntity
    {
        
        [Column("ServiceNumber")]
        public string ServiceNumber { get; set; }

        /// <summary>
        /// 权限账户ID
        /// </summary>
        [Column("Account")]
        public string Account { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        [NotMapped]
        public long RoleID { get; set; }

        /// <summary>
        /// 中文名称
        /// </summary>
        [Column("Name")]
        public string Name { get; set; }

        /// <summary>
        /// 英文名称
        /// </summary>
        [Column("EnName")]
        public string EnName { get; set; }

        /// <summary>
        /// 员工编号
        /// </summary>
        [Column("ParentID")]
        public long ParentID { get; set; }

        /// <summary>
        /// Url
        /// </summary>
        [Column("Url")]
        public string Url { get; set; }

        /// <summary>
        /// 菜单类型
        /// </summary>
        [Column("MenuType")]
        public string MenuType { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Column("Remark")]
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

        public static string SQL()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT \"ID\",");
            sql.Append(" \"ParentID\",");
            sql.Append(" \"Account\",");
            sql.Append(" \"ServiceNumber\",");
            sql.Append(" \"Name\",");
            sql.Append(" \"EnName\",");
            sql.Append(" \"Url\",");
            sql.Append("  0 \"RoleID\",");
            sql.Append(" \"MenuType\",");
            sql.Append(" \"Remark\",");
            sql.Append(" \"CreatedBy\",");
            sql.Append(" \"CreatedTime\",");
            sql.Append(" \"ModifiedBy\",");
            sql.Append(" \"ModifiedTime\" ");
            sql.Append(" FROM \"JWELL_AUTHORITY\".\"ServiceMenu\" ");
            sql.Append(" WHERE 1=1 ");
            return sql.ToString();
        }
    }
}
