using System.Collections.Generic;
using Jwell.Application.Services.Params;
using Jwell.Domain.Service.Dtos;
using Jwell.Framework.Application.Service;
using Jwell.Framework.Paging;

namespace Jwell.Application.Services
{
    public interface IAuthSysAccountService : IApplicationService
    {
        /// <summary>
        /// 登录返回账户
        /// </summary>
        /// <param name="account">账户名</param>
        /// <param name="password">密码</param>
        /// <returns>登录成功，返回账户对象；否则返回null</returns>
        AuthSysAccountDto LoginValidate(string account,string password);

        /// <summary>
        /// 根据账户获取系统列表
        /// </summary>
        /// <param name="accountParams">账户</param>
        /// <returns></returns>
        PageResult<AuthSysAccountDto> SysList(AuthSysAccountParams accountParams);

        /// <summary>
        /// 保存权限账户信息
        /// </summary>
        /// <param name="authSysAccount">权限账户数据</param>
        /// <returns></returns>
        bool Save(AuthSysAccountDto authSysAccount);
    }
}
