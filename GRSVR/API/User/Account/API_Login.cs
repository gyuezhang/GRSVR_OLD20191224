using Db;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace GRSVR
{
    public class API_Login : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_Login"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            if (DbUser.Login(requestInfo.Parameters[0], requestInfo.Parameters[1]))
            {
                session.Send(API_ID.API_Login, RES_STATE.OK);
            }
            else
            {
                session.Send(API_ID.API_Login, RES_STATE.FAILED);
            }
        }
    }
}
