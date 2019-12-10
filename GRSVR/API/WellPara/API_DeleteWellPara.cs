using System;
using System.Collections.Generic;
using Util;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Model;
using Newtonsoft.Json;

namespace GRSVR
{
    public class API_DeleteWellPara : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_DeleteWellPara"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            string req = string.Join("", requestInfo.Parameters);
            C_User ac = JsonConvert.DeserializeObject<C_User>(req);

            C_DbUser.Add(ac);

            session.Send(API_ID.API_AddUser, RES_STATE.FAILED);
        }
    }
}
