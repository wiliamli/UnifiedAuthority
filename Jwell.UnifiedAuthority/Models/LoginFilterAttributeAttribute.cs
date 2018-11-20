using Jwell.Modules.Configure;
using Jwell.UnifiedAuthority.Common;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace Jwell.UnifiedAuthority.Models
{
    /// <summary>
    /// 登录验证
    /// </summary>
    public class LoginFilterAttribute : AuthorizationFilterAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(HttpActionContext filterContext)
        {
            base.OnAuthorization(filterContext);

            if (HttpContext.Current.Session["userinfo"] == null)
            {
                throw new System.UnauthorizedAccessException("未登录");
            }
        }
    }
}