using Db;
using Newtonsoft.Json;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;

namespace GRSVR
{
    public class GetWellParas : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "GetWellParas"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            try
            {
                string req = string.Join("", requestInfo.Parameters);

                WellParas a = JsonConvert.DeserializeObject<WellParas>(req);

                if (DbWell.SetWellParas(a))
                {
                    session.Send(API_ID.API_GetWellParas, RES_STATE.OK);
                }
                else
                {
                    session.Send(API_ID.API_GetWellParas, RES_STATE.FAILED);
                }

            }
            catch
            {
                return;
            }
        }
    }
}