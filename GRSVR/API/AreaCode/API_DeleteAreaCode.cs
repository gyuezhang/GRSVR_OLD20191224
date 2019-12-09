using Util;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Model;
using Newtonsoft.Json;

namespace GRSVR
{
    public class API_DeleteAreaCode : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_DeleteAreaCode"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            string req = string.Join("", requestInfo.Parameters);

            C_DbAreaCode.Delete(int.Parse(req));

          //  session.Send(API_ID.API_DeleteAreaCode, RES_STATE.FAILED);

        }
    }
}
