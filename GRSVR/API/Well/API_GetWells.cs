using System;
using System.Collections.Generic;
using Util;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Model;
using Newtonsoft.Json;

namespace GRSVR
{
    public class API_GetWells : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_GetWells"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            if(requestInfo.Parameters == null || requestInfo.Parameters.Length == 0)
                session.Send(API_ID.API_GetWells, RES_STATE.FAILED, JsonConvert.SerializeObject(C_DbTabWell.Get(null)));
            else
                session.Send(API_ID.API_GetWells, RES_STATE.FAILED, JsonConvert.SerializeObject(C_DbTabWell.Get(requestInfo.Parameters[0])));
        }
    }
}
