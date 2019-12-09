using Util;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Model;
using Newtonsoft.Json;

namespace GRSVR
{
    public class API_AdminUserLogin : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_AdminUserLogin"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            string req = string.Join("", requestInfo.Parameters);

            C_DbAdminUser.Login(req);

            //  session.Send(API_ID.API_DeleteAreaCode, RES_STATE.FAILED);

        }
    }
}
