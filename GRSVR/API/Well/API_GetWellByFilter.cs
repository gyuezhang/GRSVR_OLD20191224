﻿using Db;
using Newtonsoft.Json;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System.Collections.Generic;

namespace GRSVR
{
    public class API_GetWellByFilter : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_GetWellByFilter"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            try
            {
                string filter;
                if (requestInfo.Parameters.Length > 0)
                    filter = requestInfo.Parameters[0];
                else
                    filter = "";

                List<Well> wells = DbWell.GetWellByFilter(filter);
                string p = JsonConvert.SerializeObject(wells);

                session.Send(API_ID.API_GetWellByFilter, RES_STATE.OK, p);

            }
            catch
            {
                session.Send(API_ID.API_GetWellByFilter, RES_STATE.FAILED);
            }
        }
    }
}