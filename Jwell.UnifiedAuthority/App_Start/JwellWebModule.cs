using Jwell.Application;
using Jwell.Framework.Modules;
using Jwell.Modules.WebApi;
using Jwell.Modules.MVC;
using Jwell.Repository;
using Jwell.Modules.Cache;
using Jwell.Integration;

namespace Jwell.UnifiedAuthority
{
    /// <summary>
    /// 模块加载
    /// </summary>
    [DependOn(typeof(MvcModule),typeof(WebApiModule),typeof(JwellApplicationModule),typeof(JwellRepositoryModule),
        typeof(JwellCacheModule),typeof(JwellIntegrationModule))]
    public class JwellWebModule : JwellModule
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }
    }
}