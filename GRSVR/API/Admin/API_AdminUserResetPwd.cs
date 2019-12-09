using Util;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Model;
using Newtonsoft.Json;

namespace GRSVR
{
    public class API_AdminUserResetPwd : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_AdminUserResetPwd"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            string req = string.Join("", requestInfo.Parameters);
            C_DbAdminUser.ResetPwd(requestInfo.Parameters[0], requestInfo.Parameters[1]);

            //  session.Send(API_ID.API_DeleteAreaCode, RES_STATE.FAILED);

        }
    }
}
