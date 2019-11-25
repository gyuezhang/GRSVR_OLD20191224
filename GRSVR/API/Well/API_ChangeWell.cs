using Db;
using Newtonsoft.Json;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;

namespace GRSVR
{
    public class API_ChangeWell : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_ChangeWell"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            try
            {
                string req = string.Join("", requestInfo.Parameters);

                Well a = JsonConvert.DeserializeObject<Well>(req);


                if (DbWell.ChangeWell(a))
                {
                    session.Send(API_ID.API_ChangeWell, RES_STATE.OK);
                }
                else
                {
                    session.Send(API_ID.API_ChangeWell, RES_STATE.FAILED);
                }

            }
            catch
            {
                return;
            }
        }
    }
}