using Db;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace GRSVR
{
    public class API_Admin_ChangeUser : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_Admin_ChangeUser"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            STR_User user = new STR_User();
            user.Id = int.Parse(requestInfo.Parameters[0]);
            user.Name = requestInfo.Parameters[1];
            user.Pwd = requestInfo.Parameters[2];
            user.DeptId = int.Parse(requestInfo.Parameters[3]);
            user.Tel = requestInfo.Parameters[4];
            user.Email = requestInfo.Parameters[5];

            if (DbUser.ChangeUser(user))
            {
                session.Send(API_ADMIN_ID.API_Admin_ChangeUser, RES_ID.OK);
            }
            else
            {
                session.Send(API_ADMIN_ID.API_Admin_ChangeUser, RES_ID.FAILED);
            }
        }
    }
}
