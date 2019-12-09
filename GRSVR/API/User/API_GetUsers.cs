using Util;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Model;
using Newtonsoft.Json;

namespace GRSVR
{
    public class API_GetUsers : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_GetUsers"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            string req = string.Join("", requestInfo.Parameters);

            C_DbDept.Add(req);

            session.Send(API_ID.API_GetUsers, RES_STATE.FAILED);
        }
    }
}
