using Db;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace GRSVR
{
    public class API_Admin_Login : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_Admin_Login"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            if (DbAdminUser.Login(requestInfo.Parameters[0], requestInfo.Parameters[1]))
            {
                session.Send(API_ID.API_Admin_Login, RES_ID.OK);
            }
            else
            {
                session.Send(API_ID.API_Admin_Login, RES_ID.FAILED);
            }
        }
    }
}
