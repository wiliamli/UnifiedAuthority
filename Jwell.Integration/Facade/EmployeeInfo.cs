using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Integration
{
    [Serializable]
    public class EmployeeInfo
    {
        [JsonProperty("UserID")]
        public long UserID { get; set; }

        /// <summary>
        /// 员工工号
        /// </summary>
        [JsonProperty("EmployeeID")]
        public string EmployeeID { get; set; }

        /// <summary>
        /// 员工姓名
        /// </summary>
        [JsonProperty("UserName")]
        public string UserName { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        [JsonProperty("Department")]
        public string Department { get; set; }

        /// <summary>
        /// 是否已关联
        /// </summary>
        [JsonProperty]
        public bool IsChecked { get; set; }

        /// <summary>
        /// 对应的角色
        /// </summary>
        [JsonProperty]
        public long RoleID { get; set; }

        /// <summary>
        /// 唯一账户分组
        /// </summary>
        [JsonProperty]
        public string Account { get; set; }
    }
}
