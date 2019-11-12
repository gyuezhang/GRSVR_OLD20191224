using Db;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System.Collections.Generic;

namespace GRSVR
{
    public class API_Admin_GetAllUsers : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_Admin_GetAllUsers"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            List<STR_User> users = DbUser.GetAllUsers();
            List<string> res = new List<string>();
            foreach(STR_User user in users)
            {
                res.Add(user.UsrToStr());
            }
            session.Send(API_ID.API_Admin_GetAllUsers, RES_STATE.OK, res);

        }
    }
}
