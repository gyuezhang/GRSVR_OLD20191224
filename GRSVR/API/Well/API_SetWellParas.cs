using Db;
using Newtonsoft.Json;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;

namespace GRSVR
{
    public class API_SetWellParas : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_SetWellParas"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            try
            {
                string req = string.Join("", requestInfo.Parameters);

                WellParas a = JsonConvert.DeserializeObject<WellParas>(req);

                if (DbWell.SetWellParas(a))
                {
                    session.Send(API_ID.API_SetWellParas, RES_STATE.OK);
                }
                else
                {
                    session.Send(API_ID.API_SetWellParas, RES_STATE.FAILED);
                }

            }
            catch
            {
                return;
            }
        }
    }
}