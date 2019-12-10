using Util;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Model;
using Newtonsoft.Json;

namespace GRSVR
{
    public class API_DeleteWell : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_DeleteWell"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            string req = string.Join("", requestInfo.Parameters);
            C_Well ac = JsonConvert.DeserializeObject<C_Well>(req);
            C_DbTabWell.Delete(ac);
        }
    }
}
