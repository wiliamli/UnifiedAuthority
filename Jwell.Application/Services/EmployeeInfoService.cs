using Jwell.Application.Services.Constant;
using Jwell.Application.Services.Dtos;
using Jwell.Application.Services.Params;
using Jwell.Framework.Application.Service;
using Jwell.Framework.Paging;
using Jwell.Integration.Services.EmployeeInfoIntegration;
using Jwell.Modules.Cache;
using Jwell.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Application.Services
{
    public class EmployeeInfoService: ApplicationService, IEmployeeInfoService
    {
        private IEmployeeInfoIntegration EmployeeInfoIntegration { get; set; }

        private IEmployeeRoleAndMenuRepository EmployeeRoleAndMenuRepository { get; set; }

        private IEmployeeRoleRelationRepository EmployeeRoleRelationRepository { get; set; }

        private IEmployeeRoleRepository EmployeeRoleRepository { get; set; }

        private ICacheClient CacheClient { get; set; }

        public EmployeeInfoService(IEmployeeInfoIntegration employeeInfoIntegration,
            IEmployeeRoleAndMenuRepository employeeRoleAndMenuRepository,
            IEmployeeRoleRelationRepository employeeRoleRelationRepository,
            IEmployeeRoleRepository employeeRoleRepository,
            ICacheClient cacheClient)
        {
            this.EmployeeInfoIntegration = employeeInfoIntegration;
            this.EmployeeRoleAndMenuRepository = employeeRoleAndMenuRepository;
            this.EmployeeRoleRelationRepository = employeeRoleRelationRepository;
            this.EmployeeRoleRepository = employeeRoleRepository;
            this.CacheClient = cacheClient;
        }

        public PageResult<EmployeeInfoDto> EmployeeInfoWithRole(SearchEmployeeInfoParam searchEmployeeInfoParam)
        {
            var employees = this.EmployeeInfoIntegration.GetEmployeeInfos(searchEmployeeInfoParam.Name,
                searchEmployeeInfoParam.EmployeeID,searchEmployeeInfoParam.Department);

            var roleAndMenus = this.EmployeeRoleAndMenuRepository.Queryable().Where(m => m.Account == searchEmployeeInfoParam.Account && m.ServiceNumber==searchEmployeeInfoParam.ServiceNumber);

            var employeeRoleRel = this.EmployeeRoleRelationRepository.Queryable().Where(m => m.Account == searchEmployeeInfoParam.Account && m.ServiceNumber == searchEmployeeInfoParam.ServiceNumber);

            var employeeRole = this.EmployeeRoleRepository.Queryable().Where(m => m.Account == searchEmployeeInfoParam.Account && m.ServiceNumber == searchEmployeeInfoParam.ServiceNumber
            && m.RoleCode == searchEmployeeInfoParam.RoleCode);

            var query = (from a in employees
                         join b in employeeRoleRel on a.EmployeeID equals b.EmployeeID into temp1
                         from t1 in temp1.DefaultIfEmpty()
                         join c in employeeRole on (t1 != null ? t1.RoleID : 0) equals c.ID into temp2
                         from t2 in temp2.DefaultIfEmpty()
                         join d in roleAndMenus on (t2 != null ? t2.ID : 0) equals d.RoleID into temp3
                         from t3 in temp3.DefaultIfEmpty()
                         select new EmployeeInfoDto()
                         {
                             Account = searchEmployeeInfoParam.Account,
                             Department = a.Department,
                             EmployeeID = a.EmployeeID,
                             IsChecked = t1 != null,
                             Name = a.UserName,
                             RoleID = t1 != null ? t1.RoleID : 0,
                             MenuID = t3 != null ? t3.MenuID : 0
                         }).DistinctBy(m=>m.EmployeeID);

            return query.ToPageResult(searchEmployeeInfoParam.PageIndex, searchEmployeeInfoParam.PageSize);
        }

        public bool DeleteRole(string account, string serviceNumber, string roleCode)
        {
            return EmployeeRoleRepository.Delete(new Domain.Entities.EmployeeRole()
            {
                Account = account,
                ServiceNumber = serviceNumber,
                RoleCode = roleCode
            }) > 0;
        }
    }
}
