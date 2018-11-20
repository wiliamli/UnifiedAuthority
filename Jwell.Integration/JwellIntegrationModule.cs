using Autofac;
using Jwell.Framework.Ioc;
using Jwell.Framework.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Integration
{
    /// <summary>
    /// 
    /// </summary>
    public class JwellIntegrationModule : JwellModule
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
        }
    }
}
