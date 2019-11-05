using Db;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace GRSVR
{
    public class API_Admin_CreateDept : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_Admin_CreateDept"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            if (DbDept.CreateDept(requestInfo.Parameters[0]))
            {
                session.Send(API_ID.API_Admin_CreateDept, RES_ID.OK);
            }
            else
            {
                session.Send(API_ID.API_Admin_CreateDept, RES_ID.FAILED);
            }
        }
    }
}
