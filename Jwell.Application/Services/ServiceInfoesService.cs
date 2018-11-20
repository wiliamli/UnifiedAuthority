using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jwell.Application.Services.Constant;
using Jwell.Application.Services.Dtos;
using Jwell.Framework.Application.Service;
using Jwell.Modules.Cache;

namespace Jwell.Application.Services
{
    public class ServiceInfoesService : ApplicationService,IServiceInfoesService
    {
        private ICacheClient CacheClient { get; set; }

        public ServiceInfoesService(ICacheClient cacheClient)
        {
            this.CacheClient = cacheClient;
        }

        public IEnumerable<ServiceInfoDto> GetTeamInfoDtos(string teamLeader)
        {
            this.CacheClient.DB = 3;
            IEnumerable<TeamInfoDto> list = this.CacheClient.GetCache<IEnumerable<TeamInfoDto>>(ApplicationConstant.SYNCALLTEAMINFO);

            IEnumerable<ServiceInfoDto> result = null;

            if (list != null) 
            {
                TeamInfoDto teamInfo = list.Where(m => m.LeaderId == teamLeader).FirstOrDefault();
                if (teamInfo != null)
                {
                    result = teamInfo.ServiceInfoes;
                }
            }

            return result;
        }
    }
}
