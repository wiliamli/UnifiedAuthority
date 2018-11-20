using Jwell.Application.Services;
using Jwell.Application.Services.Dtos;
using Jwell.Framework.Mvc;
using Jwell.UnifiedAuthority.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Jwell.UnifiedAuthority.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [LoginFilter]
    public class ServiceInfoController : BaseApiController
    {
        private IServiceInfoesService ServiceInfoesService { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ServiceInfoController(IServiceInfoesService serviceInfoesService)
        {
            this.ServiceInfoesService = serviceInfoesService;
        }

        /// <summary>
        /// 当前账户下的系统列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public StandardJsonResult<IEnumerable<ServiceInfoDto>> SysList()
        {
            StandardJsonResult<IEnumerable<ServiceInfoDto>> result = base.StandardAction<IEnumerable<ServiceInfoDto>>(() =>
            {
                return ServiceInfoesService.GetTeamInfoDtos(UserInfo.Account);
            });
          
            return result;
        }
    }
}
