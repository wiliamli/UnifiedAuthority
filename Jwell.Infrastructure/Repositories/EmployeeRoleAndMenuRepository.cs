using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jwell.Domain.Entities;
using Jwell.Modules.EntityFramework.Repositories;
using Jwell.Modules.EntityFramework.Uow;
using Jwell.Repository.Context;

namespace Jwell.Repository.Repositories
{
    public class EmployeeRoleAndMenuRepository :RepositoryBase<EmployeeRoleAndMenu, JwellDbContext, long>, IEmployeeRoleAndMenuRepository
    {
        public EmployeeRoleAndMenuRepository(IDbContextResolver dbContextResolver) : base(dbContextResolver)
        {
        }

        public override int Add(EmployeeRoleAndMenu entity)
        {
            return base.Add(entity);
        }

        public override int Delete(EmployeeRoleAndMenu entity)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(" DELETE FROM ");
            sql.Append(" \"JWELL_AUTHORITY\".\"EmployeeRoleAndMenu\" ");
            sql.Append(" WHERE ");
            sql.Append(" \"Account\" = :Account AND ");
            sql.Append(" \"ServiceNumber\"=:ServiceNumber AND ");
            sql.Append(" \"MenuID\"=:MenuID AND ");
            sql.Append(" \"RoleID\"=:RoleID ");

            return base.ExecuteSqlCommand(sql.ToString(), new object[]
            {
                entity.Account,
                entity.ServiceNumber,
                entity.MenuID,
                entity.RoleID
            });
        }

        public override int Update(EmployeeRoleAndMenu entity)
        {
            return base.Update(entity);
        }
    }
}
