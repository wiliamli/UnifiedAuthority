using Jwell.Domain.Entities;
using Jwell.Modules.EntityFramework.Repositories;
using Jwell.Modules.EntityFramework.Uow;
using Jwell.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Repository.Repositories
{
    public class EmployeeRoleRelationRepository : RepositoryBase<EmployeeRoleRelation, JwellDbContext, long>, IEmployeeRoleRelationRepository
    {
        public EmployeeRoleRelationRepository(IDbContextResolver dbContextResolver) : base(dbContextResolver)
        {
            
        }

        public int DeleteEmployeeRoleRelation(EmployeeRoleRelation entity)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(" DELETE FROM \"JWELL_AUTHORITY\".\"EmployeeRoleRelation\" ");
            sql.Append(" WHERE ");
            sql.Append(" \"Account\" = :Account AND ");
            sql.Append(" \"ServiceNumber\"=:ServiceNumber AND ");
            sql.Append(" \"EmployeeID\"=:EmployeeID AND ");
            sql.Append(" \"RoleID\"=:RoleID ");

           return base.ExecuteSqlCommand(sql.ToString(), new object[]
           {
                entity.Account,
                entity.ServiceNumber,
                entity.EmployeeID,
                entity.RoleID
           });
        }
    }
}
