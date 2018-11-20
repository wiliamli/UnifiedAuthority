using Jwell.Application.Services;
using Jwell.Domain.Service.Dtos;
using Jwell.Framework.Mvc;
using System;
using System.Web.Mvc;

namespace Jwell.UnifiedAuthority.Controllers
{

    /// <summary>
    /// 只能内网访问
    /// </summary>
    public class SignInController : BaseApiController
    {

        private IAuthSysAccountService AuthSysAccountService { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="authSysAccountService"></param>
        public SignInController(IAuthSysAccountService authSysAccountService)
        {
            this.AuthSysAccountService = authSysAccountService;
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="value">账户信息</param>
        /// <returns></returns>
        [HttpPost]
        public StandardJsonResult<bool> Login(AuthSysAccountDto value)
        {
            return base.StandardAction(() =>
            {
                var authSysAccountDto = this.AuthSysAccountService.LoginValidate(value.Account, value.Password);
                if (authSysAccountDto != null)
                {
                    //登录成功跳转到Home页
                    SetUserInfo(authSysAccountDto);
                    return true;
                }
                else
                {
                    return false;
                }
            });
        }
         
        /// <summary>
        /// 登出
        /// </summary>
        public void Logout()
        {
            System.Web.HttpContext.Current.Session["userinfo"] = null;
        }
    }
}