using Jwell.Framework.Ioc;
using Jwell.Integration.Constant;
using Jwell.Modules.Cache;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Jwell.Integration.Services.EmployeeInfoIntegration 
{
    [Transient]
    public class EmployeeInfoIntegration : IEmployeeInfoIntegration
    {
        private ICacheClient CacheClient { get; set; }

        public EmployeeInfoIntegration(ICacheClient cacheClient)
        {
            this.CacheClient = cacheClient;
        }

        public IEnumerable<EmployeeInfo> GetEmployeeInfos()
        {
            this.CacheClient.DB= IntegrationConstant.EMPLOYEECACHEDB;
            if (this.CacheClient.IsExist(IntegrationConstant.EMPLOYEEKEY))
            {
                return this.CacheClient.GetCache<IEnumerable<EmployeeInfo>>(IntegrationConstant.EMPLOYEEKEY);
            }
            else
            {
                //TODO:应该走接口拿数据
                return new List<EmployeeInfo>();
            }
        }

        public IEnumerable<EmployeeInfo> GetEmployeeInfos(string name, string employeeId, string department)
        {
            IEnumerable<EmployeeInfo> list = GetEmployeeInfos();
            if (!string.IsNullOrWhiteSpace(name))
            {
                list = list.Where(m => m.UserName == name);
            }
            if (!string.IsNullOrWhiteSpace(department))
            {
                list = list.Where(m => m.Department == department);
            }
            if (!string.IsNullOrWhiteSpace(employeeId))
            {
                list = list.Where(m => m.EmployeeID == employeeId);
            }
            return list;
        }
    }
}