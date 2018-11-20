using Jwell.Application.Services.Params;
using Jwell.Domain.Service.Dtos;
using Jwell.Framework.Application.Service;
using Jwell.Framework.Paging;
using Jwell.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Application.Services
{
    public class AuthSysAccountService : ApplicationService, IAuthSysAccountService
    {
        private IAuthSysAccountRepository AuthSysAccountRepository { get; set; }

        public AuthSysAccountService(IAuthSysAccountRepository authSysAccountRepository)
        {
            this.AuthSysAccountRepository = authSysAccountRepository;
        }


        public AuthSysAccountDto LoginValidate(string account, string password)
        {
            AuthSysAccountDto dto = null;
            var entity = this.AuthSysAccountRepository.Queryable().
                Where(m => m.Account == account && m.Password == password).FirstOrDefault();
            if (entity != null) dto = entity.ToDto();
            return dto;
        }


        /// <summary>
        /// 一个leader下面的系统只能对应一个账户,
        /// 如果记录存在，则账户存在
        /// </summary>
        /// <param name="serviceNumber"></param>
        /// <param name="teamLeader"></param>
        /// <returns></returns>
        private bool IsExistServiceAuth(string serviceNumber, string teamLeader)
        {
            return AuthSysAccountRepository.Queryable().
                 FirstOrDefault(m => m.ServiceNumber == serviceNumber && m.TeamLeader == teamLeader) != null;
        }

        public PageResult<AuthSysAccountDto> SysList(AuthSysAccountParams authSysAccountParams)
        {
            return AuthSysAccountRepository.Queryable().
                Where(m => m.Account == authSysAccountParams.Account).
                ToPageResult(authSysAccountParams).ToDtos();
        }

        public bool Save(AuthSysAccountDto authSysAccount)
        {
            return AuthSysAccountRepository.Add(authSysAccount.ToEntity()) > 0;
        }
    }
}
