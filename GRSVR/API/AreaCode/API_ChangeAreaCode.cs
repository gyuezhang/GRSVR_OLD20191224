using Util;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Model;
using Newtonsoft.Json;

namespace GRSVR
{
    public class API_ChangeAreaCode : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_ChangeAreaCode"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            string req = string.Join("", requestInfo.Parameters);
            C_AreaCode ac = JsonConvert.DeserializeObject<C_AreaCode>(req);
            C_DbAreaCode.Change(ac);

            //  session.Send(API_ID.API_DeleteAreaCode, RES_STATE.FAILED);

        }
    }
}
