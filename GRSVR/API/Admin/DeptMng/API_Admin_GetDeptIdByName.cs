using Db;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System.Collections.Generic;

namespace GRSVR
{
    public class API_Admin_GetDeptIdByName : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_Admin_GetDeptIdByName"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            if (requestInfo.Parameters.Length == 0)
                return;
            List<string> res = new List<string>();
            res.Add(DbDept.GetDeptIdByName(requestInfo.Parameters[0]).ToString());
            session.Send(API_ID.API_Admin_GetDeptIdByName, RES_STATE.OK, res);
        }
    }
}
