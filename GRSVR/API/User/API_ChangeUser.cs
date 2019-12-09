using Util;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Model;

namespace GRSVR
{
    public class API_ChangeUser : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_ChangeUser"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            string req = string.Join("", requestInfo.Parameters);

            C_DbDept.Add(req);

            session.Send(API_ID.API_ChangeUser, RES_STATE.FAILED);
        }
    }
}
