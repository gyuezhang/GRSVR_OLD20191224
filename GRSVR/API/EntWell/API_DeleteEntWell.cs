using Util;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Model;
using Newtonsoft.Json;

namespace GRSVR
{
    public class API_DeleteEntWell : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_DeleteEntWell"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            string req = string.Join("", requestInfo.Parameters);
            C_EntWell ac = JsonConvert.DeserializeObject<C_EntWell>(req);
            C_DbTabEntWell.Delete(ac);
        }
    }
}
