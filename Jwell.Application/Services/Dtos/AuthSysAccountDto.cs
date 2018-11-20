using Jwell.Domain.Entities;
using Jwell.Framework.Paging;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace Jwell.Domain.Service.Dtos
{
    public class AuthSysAccountDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        [JsonIgnore]
        public long ID { get; set; }

        /// <summary>
        /// 小组leader工号
        /// </summary>
        [JsonIgnore]
        public string TeamLeader { get; set; }

        /// <summary>
        /// 服务编号
        /// </summary>
        [JsonIgnore]
        public string ServiceNumber { get; set; }

        /// <summary>
        /// 服务标识
        /// </summary>
        [JsonIgnore]
        public string ServiceSign { get; set; }

        /// <summary>
        /// 账户
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonIgnore]
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [JsonIgnore]
        public string CreatedBy { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [JsonIgnore]
        public DateTime ModifiedTime { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        [JsonIgnore]
        public string ModifiedBy { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [JsonIgnore]
        public bool IsDelete { get; set; }
        
    }

    /// <summary>
    /// Mapper
    /// </summary>
    public static class AuthSysAccountDtoExt
    {

        public static IQueryable<AuthSysAccountDto> ToDtos(this IQueryable<AuthSysAccount> query)
        {
            return from a in query
                   select new AuthSysAccountDto()
                   {
                       ID = a.ID,
                       CreatedBy = a.CreatedBy,
                       CreatedTime = a.CreatedTime,
                       ModifiedBy = a.ModifiedBy,
                       ModifiedTime = a.ModifiedTime,
                       Account = a.Account,
                       Password = a.Password,
                       TeamLeader = a.TeamLeader,
                       ServiceNumber = a.ServiceNumber,
                       ServiceSign = a.ServiceSign,
                       IsDelete = a.IsDelete
                   };
        }

        public static PageResult<AuthSysAccountDto> ToDtos(this PageResult<AuthSysAccount> query)
        {
            var queryDto = (from a in query.Pager
                            select new AuthSysAccountDto()
                            {
                                ID = a.ID,
                                CreatedBy = a.CreatedBy,
                                CreatedTime = a.CreatedTime,
                                ModifiedBy = a.ModifiedBy,
                                ModifiedTime = a.ModifiedTime,
                                Account = a.Account,
                                Password = a.Password,
                                TeamLeader = a.TeamLeader,
                                IsDelete = a.IsDelete,
                                ServiceSign = a.ServiceSign,
                                ServiceNumber = a.ServiceNumber
                            }).ToList();

            return new PageResult<AuthSysAccountDto>(queryDto, query.PageIndex, query.PageSize, query.TotalCount);
        }

        public static AuthSysAccountDto ToDto(this AuthSysAccount entity)
        {
            AuthSysAccountDto dto = null;
            if (entity != null)
            {
                dto = new AuthSysAccountDto()
                {
                    ID = entity.ID,
                    CreatedBy = entity.CreatedBy,
                    CreatedTime = entity.CreatedTime,
                    ModifiedBy = entity.ModifiedBy,
                    ModifiedTime = entity.ModifiedTime,
                    Account = entity.Account,
                    Password = entity.Password,
                    TeamLeader = entity.TeamLeader,
                    IsDelete = entity.IsDelete,
                    ServiceSign = entity.ServiceSign,
                    ServiceNumber = entity.ServiceNumber
                };
            }
            return dto;
        }

        public static AuthSysAccount ToEntity(this AuthSysAccountDto dto)
        {
            AuthSysAccount entity = null;
            if (dto != null)
            {
                entity = new AuthSysAccount()
                {
                    ID = dto.ID,
                    CreatedBy = dto.CreatedBy,
                    CreatedTime = dto.CreatedTime,
                    ModifiedBy = dto.ModifiedBy,
                    ModifiedTime = dto.ModifiedTime,
                    Account = dto.Account,
                    Password = dto.Password,
                    TeamLeader = dto.TeamLeader,
                    ServiceNumber = dto.ServiceNumber,
                    ServiceSign = dto.ServiceSign,
                    IsDelete = dto.IsDelete
                };
            }
            return entity;
        }
    }
}
