using Util;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Model;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GRSVR
{
    public class API_ChangeEntWellPara : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_ChangeEntWellPara"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            string req = string.Join("", requestInfo.Parameters);
            List<C_WellPara> ac = JsonConvert.DeserializeObject<List<C_WellPara>>(req);

            C_DbTabEntWellPara.Change(ac[0],ac[1]);

            //session.Send(API_ID.API_AddUser, RES_STATE.FAILED);
        }
    }
}
