using Jwell.Application.Services;
using Jwell.Framework.Mvc;
using Jwell.Domain.Service.Dtos;
using System.Web.Http;
using Jwell.UnifiedAuthority.Models;
using Jwell.Framework.Paging;
using Jwell.Application.Services.Params;

namespace Jwell.UnifiedAuthority.Controllers
{
    /// <summary>
    ///  服务列表展示
    /// </summary>
    public class HomeController : BaseApiController
    {
        private IAuthSysAccountService AuthSysAccountService { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="authSysAccountService"></param>
        public HomeController(IAuthSysAccountService authSysAccountService)
        {
            this.AuthSysAccountService = authSysAccountService;
        }

        ///// <summary>
        ///// 当前账户下的系统列表
        ///// </summary>
        ///// <param name="accountParams">账户参数</param>
        ///// <returns></returns>
        //[HttpPost]
        //[LoginFilter]
        //public StandardJsonResult<PageResult<AuthSysAccountDto>> SysList(AuthSysAccountParams accountParams)
        //{
        //    return base.StandardAction<PageResult<AuthSysAccountDto>>(() =>
        //    {
        //        accountParams.Account = UserInfo.Account;

        //        return this.AuthSysAccountService.SysList (accountParams);
        //    });
        //}

        /// <summary>
        /// 添加管理员账户账户
        /// </summary>
        /// <param name="dto">账户数据</param>
        /// <returns></returns>
        [HttpPost]
        public StandardJsonResult Save(AuthSysAccountDto dto)
        {
            return base.StandardAction(() =>
            {
                return this.AuthSysAccountService.Save(dto);
            });
        }
    }
}
