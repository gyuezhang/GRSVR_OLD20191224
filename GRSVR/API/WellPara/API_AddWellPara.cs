using System;
using System.Collections.Generic;
using Util;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Model;
using Newtonsoft.Json;

namespace GRSVR
{
    public class API_AddWellPara : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_AddWellPara"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            string req = string.Join("", requestInfo.Parameters);
            C_WellPara ac = JsonConvert.DeserializeObject<C_WellPara>(req);
            C_DbTabWellPara.Add(ac);

            //session.Send(API_ID.API_AddUser, RES_STATE.FAILED);
        }
    }
}
