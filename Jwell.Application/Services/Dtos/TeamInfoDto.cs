using Jwell.Domain.Entities;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Jwell.Application.Services.Dtos
{
    public class ServiceInfoDto
    {
        public string ServiceNumber { get; set; }

        public string ServiceName { get; set; }

        public string ServiceSign { get; set; }

        public string OwnerId { get; set; }

        public string OwnerName { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime ModifiedTime { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }
    }

    public class TeamInfoDto
    {     
        public string LeaderId { get; set; }

        public string LeaderName { get; set; }

        public string TeamCode { get; set; }    

        public List<ServiceInfoDto> ServiceInfoes { get; set; }

        public TeamInfoDto()
        {
            ServiceInfoes = new List<ServiceInfoDto>();
        }
    }
}
