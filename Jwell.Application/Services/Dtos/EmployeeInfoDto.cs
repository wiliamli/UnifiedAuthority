namespace Jwell.Application.Services.Dtos
{
    public class EmployeeInfoDto
    {
        /// <summary>
        /// 工号
        /// </summary>
        public string EmployeeID { get; set; }

        /// <summary>
        /// 员工姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 是否已关联
        /// </summary>
        public bool IsChecked { get; set; }

        /// <summary>
        /// 对应的角色
        /// </summary>
        public long RoleID { get; set; }

        /// <summary>
        /// 唯一账户分组
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 菜单ID
        /// </summary>
        public long MenuID { get; set; }

        /// <summary>
        /// 服务编号
        /// </summary>
        public string ServiceNumber { get; set; }
    }
}
