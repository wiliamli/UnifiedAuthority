using System;
using System.Collections.Generic;
using System.Linq;
using Jwell.Domain.Entities;
using Jwell.Framework.Paging;
using Newtonsoft.Json;

namespace Jwell.Application.Services.Dtos
{
    public class ServiceMenuDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// 账户
        /// </summary>
        [JsonIgnore]
        public string Account { get; set; }

        /// <summary>
        /// 服务编号
        /// </summary>
        public string ServiceNumber { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public long RoleID { get; set; }

        public string RoleName { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 英文名称
        /// </summary>
        public string EnName { get; set; }

        /// <summary>
        /// 员工编号
        /// </summary>
        public long ParentID { get; set; }

        private string url = "无";
        /// <summary>
        /// Url
        /// </summary>
        public string Url
        {
            get
            {
                return url;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    //TODO:Url的验证
                    url = value;
                }
            }
        }

        /// <summary>
        /// 手机号
        /// </summary>
        public string MenuType { get; set; }

        /// <summary>
        /// 手机号验证码
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime
        {
            get;set;
        }

        /// <summary>
        /// 修改人
        /// </summary>
        public string ModifiedBy { get; set; }


        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModifiedTime
        {
            get;set;
        }
    }

    /// <summary>
    /// Mapper
    /// </summary>
    public static class ServiceMenuDtoExt
    {
        public static IEnumerable<ServiceMenuDto> ToDtos(this IEnumerable<ServiceMenu> query)
        {
            return from a in query
                   select new ServiceMenuDto()
                   {
                       ID = a.ID,
                       CreatedBy = a.CreatedBy,
                       CreatedTime = a.CreatedTime,
                       MenuType = a.MenuType,
                       ModifiedBy = a.ModifiedBy,
                       ModifiedTime = a.ModifiedTime,
                       Name = a.Name,
                       ParentID = a.ParentID,
                       Remark = a.Remark,
                       RoleID = a.RoleID,
                       Url = a.Url,
                       Account = a.Account,
                       ServiceNumber = a.ServiceNumber,
                       EnName = a.EnName
                   };
        }

        public static PageResult<ServiceMenuDto> ToDtos(this PageResult<ServiceMenu> query)
        {
            var queryDto = (from a in query.Pager
                            select new ServiceMenuDto()
                            {
                                ID = a.ID,
                                CreatedBy = a.CreatedBy,
                                CreatedTime = a.CreatedTime,
                                MenuType = a.MenuType,
                                Url = a.Url,
                                RoleID = a.RoleID,
                                Remark = a.Remark,
                                ParentID = a.ParentID,
                                ModifiedBy = a.ModifiedBy,
                                ModifiedTime = a.ModifiedTime,
                                Name = a.Name,
                                Account = a.Account,
                                ServiceNumber = a.ServiceNumber,
                                EnName = a.EnName
                            }).ToList();

            return new PageResult<ServiceMenuDto>(queryDto, query.PageIndex, query.PageSize, query.TotalCount);
        }

        public static ServiceMenuDto ToDto(this ServiceMenu entity)
        {
            ServiceMenuDto dto = null;
            if (entity != null)
            {
                dto = new ServiceMenuDto()
                {
                    ID = entity.ID,
                    CreatedBy = entity.CreatedBy,
                    CreatedTime = entity.CreatedTime,
                    MenuType = entity.MenuType,
                    Url = entity.Url,
                    RoleID = entity.RoleID,
                    Remark = entity.Remark,
                    ParentID = entity.ParentID,
                    ModifiedBy = entity.ModifiedBy,
                    ModifiedTime = entity.ModifiedTime,
                    Name = entity.Name,
                    Account = entity.Account,
                    ServiceNumber = entity.ServiceNumber,
                    EnName = entity.EnName
                };
            }
            return dto;
        }

        public static ServiceMenu ToEntity(this ServiceMenuDto dto)
        {
            ServiceMenu entity = null;
            if (dto != null)
            {
                entity = new ServiceMenu()
                {
                    ID = dto.ID,
                    CreatedBy = dto.CreatedBy,
                    CreatedTime = dto.CreatedTime,
                    MenuType = dto.MenuType,
                    Url = dto.Url,
                    RoleID = dto.RoleID,
                    Remark = dto.Remark,
                    ParentID = dto.ParentID,
                    ModifiedBy = dto.ModifiedBy,
                    ModifiedTime = dto.ModifiedTime,
                    Name = dto.Name,
                    Account = dto.Account,
                    ServiceNumber = dto.ServiceNumber,
                    EnName = dto.EnName
                };
            }
            return entity;
        }

        public static IEnumerable<TreeMenuDto> ToTreeMenu(this IEnumerable<ServiceMenuDto> dto)
        {
            List<TreeMenuDto> list = new List<TreeMenuDto>();

            foreach (var item in dto)
            {
                list.Add(new TreeMenuDto()
                {
                    ID = item.ID,
                    MenuType = item.MenuType,
                    Name = item.Name,
                    ParentID = item.ParentID,
                    Remark = item.Remark,
                    Url = item.Url,
                    RoleID = item.RoleID,
                    EnName = item.EnName,
                    RoleName = item.RoleName
                });
            }
            return list;
        }
    }
}