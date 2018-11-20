using Jwell.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Domain.Entities
{
    [Table("AuthSysAccount")]
    public class AuthSysAccount : BaseEntity
    {
        /// <summary>
        /// 小组leader工号
        /// </summary>
        public string TeamLeader { get; set; }

        /// <summary>
        /// 服务编号
        /// </summary>
        public string ServiceNumber { get; set; }

        /// <summary>
        /// 服务标识
        /// </summary>
        public string ServiceSign { get; set; }

        /// <summary>
        /// 账户
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { get; set; }

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
                    createTime = value;
            }
        }

        private string createBy = "SysAdmin";
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreatedBy
        {
            get
            {
                return createBy;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    createBy = value;
            }
        }


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
                    modifiedTime = value;
            }
        }

        private string modifiedBy = "SysAdmin";
        /// <summary>
        /// 修改人
        /// </summary>
        public string ModifiedBy
        {
            get
            {
                return modifiedBy;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    modifiedBy = value;
            }
        }
    }
}
