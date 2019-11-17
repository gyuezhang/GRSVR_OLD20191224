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
            try
            {
                string name = requestInfo.Parameters[0];
                string pwd = requestInfo.Parameters[1];

                if (DbUser.Login(name, pwd))
                {
                    session.Send(API_ID.API_Login, RES_STATE.OK);
                }
                else
                {
                    session.Send(API_ID.API_Login, RES_STATE.FAILED);
                }
            }
            catch
            {
                session.Send(API_ID.API_Login, RES_STATE.BAD_REQUEST);
            }
        }
    }
}
