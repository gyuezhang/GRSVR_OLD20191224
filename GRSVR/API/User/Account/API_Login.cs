using Db;
using Newtonsoft.Json;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

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
            //{"name":"123","pwd":"abc"}
            try
            {
                ;
                string req = string.Join("", requestInfo.Parameters);
                API_Login_Req a = JsonConvert.DeserializeObject<API_Login_Req>(req);
                if (DbUser.Login(a.name, a.pwd))
                {
                    User cuser = DbUser.GetUserByUserName(a.name);
                    string p = JsonConvert.SerializeObject(cuser);
                    session.Send(API_ID.API_Login, RES_STATE.OK, p);
                }
                else
                {
                    session.Send(API_ID.API_Login, RES_STATE.FAILED);
                }
            }
            catch
            {
                session.Send(API_ID.API_Login, RES_STATE.BAD_REQUEST);
            }
        }
    }
}
