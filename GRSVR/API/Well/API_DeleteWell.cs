using Db;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace GRSVR
{
    public class API_DeleteWell : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_DeleteWell"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            if (DbWell.DeleteWell(int.Parse(requestInfo.Parameters[0])))
            {
                session.Send(API_ID.API_DeleteWell, RES_STATE.OK);
            }
            else
            {
                session.Send(API_ID.API_DeleteWell, RES_STATE.FAILED);
            }
        }
    }
}