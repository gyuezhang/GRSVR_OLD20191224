using Util;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System;

namespace GRSVR
{
    public class API_Login : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_Login"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            string req = string.Join("", requestInfo.Parameters);
            C_User user = new C_User();
            Tuple<string, string> loginInputs = JsonConvert.DeserializeObject<Tuple<string, string>>(req);
            E_DbRState res = C_DbTabUser.Login(requestInfo.Parameters[0], requestInfo.Parameters[1]);
            if (res == E_DbRState.Success)
            {
                foreach(C_User u in C_DbTabUser.Get().Item2)
                {
                    if (u.Name == requestInfo.Parameters[0])
                    {
                        user = u;
                        break;
                    }
                }
                session.SendLogin(RES_STATE.OK, user);
                C_DbLog.Add(new C_Log(E_LogType.Svr, E_UserType.User, user.Id, E_ActionType.UserLogin, "success", ""));
            }
            else
                session.SendLogin(RES_STATE.ErrorPwd, user);
        }
    }
}
