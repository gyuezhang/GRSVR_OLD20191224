using Util;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Model;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GRSVR
{
    public class API_AddEntWell : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_AddEntWell"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            string req = string.Join("", requestInfo.Parameters);
            List<C_EntWell> wells = JsonConvert.DeserializeObject<List<C_EntWell>>(req);

            C_DbTabEntWell.Add(wells);
        }
    }
}
