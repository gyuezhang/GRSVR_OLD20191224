using Db;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace GRSVR
{
    public class API_Admin_ChangePwd : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_Admin_ChangePwd"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            if (DbAdminUser.ChangePwd(requestInfo.Parameters[0], requestInfo.Parameters[1]))
            {
                session.Send(API_ID.API_Admin_ChangePwd, RES_STATE.OK);
            }
            else
            {
                session.Send(API_ID.API_Admin_ChangePwd, RES_STATE.FAILED);
            }
        }
    }
}
