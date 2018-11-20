using Jwell.Framework.Paging;

namespace Jwell.Application.Services.Params
{
    public class SearchMenuParam : PageParam
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; }

        /// <summary>
        /// 服务名称
        /// </summary>
        public string ServiceNumber { get; set; }
    }
}
