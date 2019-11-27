using Db;
using Newtonsoft.Json;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;

namespace GRSVR
{
    public class API_GetWellParas : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_GetWellParas"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            try
            {
                string p;
                WellParas wells = DbWell.GetWellParas();
                if (wells.AllParas.Count == 0)
                    p = "";
                else
                    p = JsonConvert.SerializeObject(wells);
          
                    session.Send(API_ID.API_GetWellParas, RES_STATE.OK,p);
         

            }
            catch
            {
                session.Send(API_ID.API_GetWellParas, RES_STATE.FAILED);
            }
        }
    }
}