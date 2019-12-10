using Util;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Model;
using Newtonsoft.Json;

namespace GRSVR
{
    public class API_GetEntWells : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_GetEntWells"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            if (requestInfo.Parameters == null || requestInfo.Parameters.Length == 0)
                session.Send(API_ID.API_GetEntWells, RES_STATE.FAILED, JsonConvert.SerializeObject(C_DbTabEntWell.Get(null)));
            else
                session.Send(API_ID.API_GetEntWells, RES_STATE.FAILED, JsonConvert.SerializeObject(C_DbTabEntWell.Get(requestInfo.Parameters[0])));

        }
    }
}
