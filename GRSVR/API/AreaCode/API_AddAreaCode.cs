using Util;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Model;
using Newtonsoft.Json;

namespace GRSVR
{
    public class API_AddAreaCode : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_AddAreaCode"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            string req = string.Join("", requestInfo.Parameters);
            C_AreaCode ac = JsonConvert.DeserializeObject<C_AreaCode>(req);

            C_DbTabAreaCode.Add(ac);
            
            session.Send(API_ID.API_AddAreaCode, RES_STATE.FAILED);
            
        }
    }
}
