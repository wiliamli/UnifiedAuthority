using Jwell.Framework.Paging;
using Newtonsoft.Json;

namespace Jwell.Application.Services.Params
{
    public class SearchEmployeeInfoParam : PageParam
    {
        [JsonIgnore]
        public string Account { get; set; }

        public string ServiceNumber { get; set; }

        public string RoleCode { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        public string EmployeeID { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public string Department { get; set; }


        /// <summary>
        /// 状态
        /// </summary>
        public byte Status { get; set; }

    }
}
