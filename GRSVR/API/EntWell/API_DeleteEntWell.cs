using Db;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace GRSVR
{
    public class API_DeleteEntWell : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_DeleteEntWell"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            if (DbEntWell.DeleteEntWell(int.Parse(requestInfo.Parameters[0])))
            {
                session.Send(API_ID.API_DeleteEntWell, RES_ID.OK);
            }
            else
            {
                session.Send(API_ID.API_DeleteEntWell, RES_ID.FAILED);
            }
        }
    }
}