using Jwell.Application.Services.Dtos;
using Jwell.Framework.Application.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Application.Services
{
    public interface IServiceInfoesService : IApplicationService
    {
        IEnumerable<ServiceInfoDto> GetTeamInfoDtos(string teamLeader);
    }
}
