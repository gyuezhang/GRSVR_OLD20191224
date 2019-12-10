using Util;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Model;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GRSVR
{
    public class API_AddWell : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_AddWell"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            string req = string.Join("", requestInfo.Parameters);
            List<C_Well> wells = JsonConvert.DeserializeObject<List<C_Well>>(req);

            C_DbTabWell.Add(wells);

            //session.Send(API_ID.API_AddUser, RES_STATE.FAILED);
        }
    }
}
