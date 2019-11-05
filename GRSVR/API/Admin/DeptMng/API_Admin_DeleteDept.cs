﻿using Db;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace GRSVR
{
    public class API_Admin_DeleteDept : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_Admin_DeleteDept"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            if (DbDept.DeleteDept(requestInfo.Parameters[0]))
            {
                session.Send(API_ADMIN_ID.API_Admin_DeleteDept, RES_ID.OK);
            }
            else
            {
                session.Send(API_ADMIN_ID.API_Admin_DeleteDept, RES_ID.FAILED);
            }
        }
    }
}