using Db;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System.Collections.Generic;

namespace GRSVR
{
    public class API_Admin_GetAllDepts : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_Admin_GetAllDepts"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            List<string>  res = DbDept.GetAllDepts();
            session.Send(API_ADMIN_ID.API_Admin_GetAllDepts, RES_ID.OK, res);
        }
    }
}
