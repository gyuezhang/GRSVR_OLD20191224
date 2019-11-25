using Db;
using Newtonsoft.Json;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;

namespace GRSVR
{
    public class API_CreateWell : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_CreateWell"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            try
            {
                string req = string.Join("", requestInfo.Parameters);
                
                List<Well> a = JsonConvert.DeserializeObject<List<Well>>(req);

                if (DbWell.CreateWell(a))
                {
                    session.Send(API_ID.API_CreateWell, RES_STATE.OK);
                }
                else
                {
                    session.Send(API_ID.API_CreateWell, RES_STATE.FAILED);
                }

            }
            catch
            {
                return;
            }
        }
    }
}