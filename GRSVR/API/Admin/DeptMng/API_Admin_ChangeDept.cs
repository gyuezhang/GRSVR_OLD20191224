using Db;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace GRSVR
{
    public class API_Admin_ChangeDept : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_Admin_ChangeDept"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            if (DbDept.ChangeDept(requestInfo.Parameters[0], requestInfo.Parameters[1]))
            {
                session.Send(API_ID.API_Admin_ChangeDept, RES_ID.OK);
            }
            else
            {
                session.Send(API_ID.API_Admin_ChangeDept, RES_ID.FAILED);
            }
        }
    }
}
