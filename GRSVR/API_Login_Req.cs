using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRSVR
{
    [JsonObject(MemberSerialization.OptIn)]
    public class API_Login_Req
    {
        public API_Login_Req(string name, string pwd)
        {
            this.name = name;
            this.pwd = pwd;
        }
        [JsonProperty]
        public string name { get; set; }
        [JsonProperty]
        public string pwd { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class API_ResetPwd_Req
    {
        public API_ResetPwd_Req(string id, string oldPwd, string newPwd)
        {
            this.Id = id;
            this.OldPwd = oldPwd;
            this.NewPwd = newPwd;
        }
        [JsonProperty]
        public string Id { get; set; }
        [JsonProperty]
        public string OldPwd { get; set; }
        [JsonProperty]
        public string NewPwd { get; set; }
    }
}
