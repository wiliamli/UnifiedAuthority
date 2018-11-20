using Jwell.Domain;
using Jwell.Domain.Entities;
using Jwell.Repository.Context;
using Jwell.Modules.EntityFramework.Repositories;
using Jwell.Modules.EntityFramework.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Repository.Repositories
{
    public class ServiceMenuRepository : RepositoryBase<ServiceMenu, JwellDbContext, long>, IServiceMenuRepository
    {
        public ServiceMenuRepository(IDbContextResolver dbContextResolver) : base(dbContextResolver)
        {
           
        }

        public override int Add(ServiceMenu entity)
        {
            int success = 0;

            using (var transaction = base.DbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
            {
                try
                {
                    var serviceMenu = base.DbContext.ServiceMenu.Add(entity);
                    success = base.DbContext.SaveChanges();
                    EmployeeRoleAndMenu roleAndMenu = new EmployeeRoleAndMenu()
                    {
                        ServiceNumber = serviceMenu.ServiceNumber,
                        Account = serviceMenu.Account,
                        MenuID = serviceMenu.ID,
                        RoleID = serviceMenu.RoleID,
                        CreatedBy = serviceMenu.CreatedBy,
                        CreatedTime = serviceMenu.CreatedTime,
                        ModifiedBy = serviceMenu.ModifiedBy,
                        ModifiedTime = serviceMenu.ModifiedTime
                    };
                    base.DbContext.EmployeeRoleAndMenu.Add(roleAndMenu);
                    success += base.DbContext.SaveChanges();
                    transaction.Commit();

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
            return success;
        }

        public override IQueryable<ServiceMenu> Queryable()
        {
            return base.SqlQuery<ServiceMenu>(ServiceMenu.SQL(), new object[] { }).AsQueryable();
        }

        public IEnumerable<ServiceMenu> Queryable(string serviceNumber)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("{0} AND \"ServiceNumber\"=:serviceNumber ", ServiceMenu.SQL());
            return base.SqlQuery<ServiceMenu>(sql.ToString(), new object[] { serviceNumber });
        }

        public int DeleteMenus(string serviceNumber, string account, IEnumerable<long> menuIds)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("DELETE FROM \"JWELL_AUTHORITY\".\"ServiceMenu\" ");
            sql.Append(" WHERE \"Account\"=:account AND \"ServiceNumber\"=:serviceNumber ");
            sql.Append(" AND \"ID\" IN (" + string.Join(", ", menuIds.Select(p => p)) + ") ");

            return base.ExecuteSqlCommand(sql.ToString(), new object[] { account ,serviceNumber });
        }

        public override int ExecuteSqlCommand(string sql)
        {
            return base.ExecuteSqlCommand(sql);
        }


        public override async Task<int> ExecuteSqlCommandAsync(string sql)
        {
            return await base.ExecuteSqlCommandAsync(sql);
        }

        public override int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return base.ExecuteSqlCommand(sql, parameters);
        }

        public override async Task<int> ExecuteSqlCommandAsync(string sql,  params object[] parameters)
        {
            return await base.ExecuteSqlCommandAsync(sql, parameters);
        }

        public override IEnumerable<TElement> SqlQuery<TElement>(string sql)
        { 
            return base.SqlQuery<TElement>(sql);
        }

        public override IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            return base.SqlQuery<TElement>(sql, parameters);
        }

        public override int Update(ServiceMenu entity)
        {
            int success = 0;

            using (var transaction = base.DbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
            {
                try
                {
                    base.DbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                    success = base.DbContext.SaveChanges();

                    StringBuilder sql = new StringBuilder();
                    sql.Append(" UPDATE \"JWELL_AUTHORITY\".\"EmployeeRoleAndMenu\" ");
                    sql.Append(" SET \"JWELL_AUTHORITY\".\"EmployeeRoleAndMenu\".\"RoleID\" = :RoleID ");
                    sql.Append(" WHERE \"JWELL_AUTHORITY\".\"EmployeeRoleAndMenu\".\"MenuID\"=:MenuID ");
                    sql.Append(" AND ");
                    sql.Append(" \"JWELL_AUTHORITY\".\"EmployeeRoleAndMenu\".\"Account\"=:Account AND \"ServiceNumber\"=:ServiceNumber ");
                    base.ExecuteSqlCommand(sql.ToString(),new object[] { entity.RoleID, entity.ID, entity.Account, entity.ServiceNumber });
                    transaction.Commit();

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
            return success;
        }

        public override int Delete(ServiceMenu entity)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(" DELETE FROM \"JWELL_AUTHORITY\".\"ServiceMenu\" ");
            sql.Append(" WHERE  \"Account\"=:Account AND \"ID\"=:ID AND \"ServiceNumber\"=:ServiceNumber ");
            return base.ExecuteSqlCommand(sql.ToString(), new object[] { entity.Account, entity.ID,entity.ServiceNumber });
        }
    }
}
