using Jwell.Domain.Service.Dtos;
using Jwell.Framework.Mvc;
using Jwell.Framework.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jwell.UnifiedAuthority.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseController : Controller
    {
        // GET: Base

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        protected StandardJsonResult StandardAction(Action action)
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
        protected StandardJsonResult<T> StandardAction<T>(Func<T> action)
        {
            var result = new StandardJsonResult<T>();
            result.StandardAction(() =>
            {
                result.Data = action();
            });
            return result;
        }

        /// <summary>
        /// 流文件下载
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="fileStream">文件流</param>
        protected void DownloadFile(string fileName, byte[] fileStream)
        {
            Response.ContentType = "application/ms-excel";
            Response.AddHeader(@"Content-Disposition", string.Format("attachment; filename={0}",
                System.Web.HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8)));
            Response.BinaryWrite(fileStream);
            Response.Flush();
            Response.End();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        protected void SetUserInfo(AuthSysAccountDto value)
        {
            if (Session["userinfo"] == null)
            {
                Session["userinfo"] = Serializer.ToJson(value);
            }
        }

        /// <summary>
        /// 获取账户session
        /// </summary>
        /// <returns></returns>
        protected AuthSysAccountDto GetUserInfo()
        {
            if (Session["userinfo"] != null)
            {
                return Serializer.FromJson<AuthSysAccountDto>(Session["userinfo"].ToString());
            }
            else
            {
                throw new NullReferenceException("会话失效，请重新登录");
            }
        }
    }
}