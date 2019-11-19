using Db;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System.Collections.Generic;

namespace GRSVR
{
    public class API_GetUserInfo : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_GetUserInfo"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            try
            {
                //STR_User user = DbUser.GetUserByUserName(requestInfo.Parameters[0]);
                //List<string> para = new List<string>();
                //para.Add(user.UsrToStr());
                //session.Send(API_ID.API_GetUserInfo, RES_STATE.OK, para);
            }
            catch
            {
                session.Send(API_ID.API_GetUserInfo, RES_STATE.FAILED);
            }
        }
    }
}
