using Util;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Model;
using Newtonsoft.Json;

namespace GRSVR
{
    public class API_ChangeDept : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_ChangeDept"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            //string req = string.Join("", requestInfo.Parameters);

            C_DbDept.Change(requestInfo.Parameters[0], requestInfo.Parameters[1]);
        }
    }
}
