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
                res.Add(user.Id.ToString() + " ");
                res.Add(user.Name + " ");
                res.Add(user.Pwd + " ");
                res.Add(user.DeptId.ToString() + " ");
                res.Add(user.Tel + " ");
                res.Add(user.Email + " ");
            }
            session.Send(API_ADMIN_ID.API_Admin_GetAllUsers, RES_ID.OK, res);

        }
    }
}
