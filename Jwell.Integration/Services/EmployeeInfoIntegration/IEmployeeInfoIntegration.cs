using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Integration.Services.EmployeeInfoIntegration
{
    public interface IEmployeeInfoIntegration
    {
        /// <summary>
        /// 获取所有员工信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<EmployeeInfo> GetEmployeeInfos();

        /// <summary>
        /// 根据条件获取员工信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="employeeId"></param>
        /// <param name="department"></param>
        /// <returns></returns>
        IEnumerable<EmployeeInfo> GetEmployeeInfos(string name, string employeeId, string department);
    }
}
