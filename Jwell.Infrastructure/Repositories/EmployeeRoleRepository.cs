using Jwell.Domain.Entities;
using Jwell.Modules.EntityFramework.Repositories;
using Jwell.Modules.EntityFramework.Uow;
using Jwell.Repository.Context;
using System.Text;

namespace Jwell.Repository.Repositories
{
    public  class EmployeeRoleRepository : RepositoryBase<EmployeeRole, JwellDbContext, long>, IEmployeeRoleRepository
    {
        public EmployeeRoleRepository(IDbContextResolver dbContextResolver) : base(dbContextResolver)
        {
        }

        public override int Add(EmployeeRole entity)
        {
            return base.Add(entity);
        }

        public override int Delete(EmployeeRole entity)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(" DELETE FROM \"JWELL_AUTHORITY\".\"EmployeeRole\" ");
            sql.Append($" WHERE \"Account\"=:account AND \"RoleCode\"=:roleCode AND \"ServiceNumber\"=:serviceNumber ");

            return base.ExecuteSqlCommand(sql.ToString(), new object[]
            {
                entity.Account,
                entity.RoleCode,
                entity.ServiceNumber
            });
        }

        public override int Update(EmployeeRole entity)
        {
            return base.Update(entity);
        }
    }
}
