using Util;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Model;

namespace GRSVR
{
    public class API_AdminLogin : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_AdminLogin"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            if (C_DbAdminUser.Login(requestInfo.Parameters[0]).Item1 == E_DbRState.Success)
            {
                session.Send(API_ID.API_AdminLogin, RES_STATE.OK);
            }
            else
            {
                session.Send(API_ID.API_AdminLogin, RES_STATE.FAILED);
            }
        }
    }
}
