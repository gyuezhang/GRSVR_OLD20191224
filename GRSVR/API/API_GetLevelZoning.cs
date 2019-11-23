using Db;
using Newtonsoft.Json;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System.Collections.Generic;

namespace GRSVR
{
    public class API_GetLevelZoning : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_GetLevelZoning"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            try
            {
                string filter = requestInfo.Parameters[0];
                int iLevel = int.Parse(filter);
                List<ZoningNode> zones = DBZones.GetLevelNode(iLevel);
                string res = JsonConvert.SerializeObject(zones);

                session.Send(API_ID.API_GetLevelZoning, RES_STATE.OK, res);

            }
            catch
            {
                session.Send(API_ID.API_GetLevelZoning, RES_STATE.FAILED);
            }
        }
    }
}