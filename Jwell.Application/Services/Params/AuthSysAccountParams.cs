using Jwell.Framework.Paging;
using Newtonsoft.Json;

namespace Jwell.Application.Services.Params
{
    public class AuthSysAccountParams: PageParam
    {
        [JsonIgnore]
        public string Account { get; set; }
    }
}
