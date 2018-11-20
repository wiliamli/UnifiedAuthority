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
    public class AuthSysAccountRepository : RepositoryBase<AuthSysAccount, JwellDbContext, long>, IAuthSysAccountRepository
    {
        public AuthSysAccountRepository(IDbContextResolver dbContextResolver) : base(dbContextResolver)
        {
        }

        /// <summary>
        /// 新增权限账户
        /// </summary>
        /// <param name="entity">权限账户实体</param>
        /// <returns></returns>
        public override int Add(AuthSysAccount entity)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(" SELECT COUNT(1) FROM \"JWELL_AUTHORITY\".\"AuthSysAccount\" ");
            sql.Append(" WHERE ");
            sql.Append(" \"TeamLeader\" = :TeamLeader ");
            sql.Append(" AND \"ServiceSign\" = :ServiceSign ");
            sql.Append(" AND \"IsDelete\" = 0 ");

            int? count = base.SqlQuery<int>(sql.ToString(),
                new object[] { entity.TeamLeader,
                    entity.ServiceSign }).FirstOrDefault();

            if (count != null && count > 0)
            {
                throw new Exception("该账户已存在唯一账户");
            }

            return base.Add(entity);
        }
    }
}
