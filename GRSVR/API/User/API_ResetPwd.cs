using Util;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Model;
using System.Collections.Generic;

namespace GRSVR
{
    public class API_ResetPwd : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_ResetPwd"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            string req = string.Join("", requestInfo.Parameters);

            List<C_User> res = C_DbTabUser.Get().Item2;
            foreach (C_User usr in res)
            {
                if (requestInfo.Parameters[0] == usr.Id.ToString())
                {
                    if(requestInfo.Parameters[1] == usr.Pwd)
                    {
                        usr.Pwd = requestInfo.Parameters[2];
                        C_DbTabUser.Change(usr);
                    }
                    else
                    {

                    }
                }
            }
            //C_DbUser.Change(requestInfo.Parameters[0], requestInfo.Parameters[1]);

            session.Send(API_ID.API_ResetPwd, RES_STATE.FAILED);
        }
    }
}
