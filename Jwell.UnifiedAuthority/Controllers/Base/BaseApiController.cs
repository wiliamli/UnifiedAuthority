using Jwell.Domain.Service.Dtos;
using Jwell.Framework.Mvc;
using Jwell.Framework.Utilities;
using Jwell.UnifiedAuthority.Models;
using System;
using System.Web;
using System.Web.Http;

namespace Jwell.UnifiedAuthority.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseApiController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        [HttpPost]
        public StandardJsonResult StandardAction(Action action)
        {
            var result = new StandardJsonResult();
            result.StandardAction(action);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <returns></returns>
        [HttpPost]
        public StandardJsonResult<T> StandardAction<T>(Func<T> action)
        {
            var result = new StandardJsonResult<T>();
            result.StandardAction(() =>
            {
                result.Data = action();
            });
            return result;
        }

        /// <summary>
        /// 设置账户session
        /// </summary>
        /// <param name="value"></param>
        protected void SetUserInfo(AuthSysAccountDto value)
        {
            if (HttpContext.Current.Session["userinfo"] == null)
            {
                HttpContext.Current.Session["userinfo"] = Serializer.ToJson(value);
            }
        }

        /// <summary>
        /// 获取账户session
        /// </summary>
        /// <returns></returns>
        protected AuthSysAccountDto UserInfo
        {
            get
            {
                if (HttpContext.Current.Session["userinfo"] != null)
                {
                    return Serializer.FromJson<AuthSysAccountDto>(HttpContext.Current.Session["userinfo"].ToString());
                }
                else
                {
                    throw new NullReferenceException("会话失效，请重新登录");
                }
            }
        }
    }
}