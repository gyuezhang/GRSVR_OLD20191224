using Db;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System.Collections.Generic;

namespace GRSVR
{
    public class API_Admin_DeleteUsers : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_Admin_DeleteUsers"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            List<int> UserIds = new List<int>();
            
            foreach(string para in requestInfo.Parameters)
            {
                UserIds.Add(int.Parse(para));
            }

            if (DbUser.DeleteUser(UserIds))
            {
                session.Send(API_ID.API_Admin_DeleteUsers, RES_ID.OK);
            }
            else
            {
                session.Send(API_ID.API_Admin_DeleteUsers, RES_ID.FAILED);
            }
        }
    }
}
