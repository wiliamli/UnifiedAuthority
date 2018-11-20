using Jwell.Domain.Entities;
using Jwell.Framework.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Repository.Repositories
{
    public interface IAuthSysAccountRepository : IRepository<AuthSysAccount, long>
    {
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns>登录成功，返回账户对象；否则返回null</returns>
        //AuthSysAccount LoginValidate(string account, string password);
    }
}
