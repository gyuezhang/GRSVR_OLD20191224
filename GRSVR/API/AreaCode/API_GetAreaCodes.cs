using Util;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Model;
using Newtonsoft.Json;

namespace GRSVR
{
    public class API_GetAreaCodes : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_GetAreaCodes"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            session.Send(API_ID.API_GetAreaCodes, RES_STATE.FAILED, JsonConvert.SerializeObject(C_DbAreaCode.Get()));

        }
    }
}
