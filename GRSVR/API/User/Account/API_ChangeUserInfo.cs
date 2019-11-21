using Db;
using Newtonsoft.Json;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace GRSVR
{
    public class API_ChangeUserInfo : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_ChangeUserInfo"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            //{"name":"123","pwd":"abc"}
            try
            {
                ;
                string req = string.Join("", requestInfo.Parameters);
                User a = JsonConvert.DeserializeObject<User>(req);
                if (DbUser.ChangeUserInfo(a.Id,a.Tel,a.Email))
                {
                    User cuser = DbUser.GetUserByUserName(a.Name);
                    string p = JsonConvert.SerializeObject(cuser);
                    session.Send(API_ID.API_ChangeUserInfo, RES_STATE.OK, p);
                }
                else
                {
                    session.Send(API_ID.API_ChangeUserInfo, RES_STATE.FAILED);
                }
            }
            catch
            {
                session.Send(API_ID.API_ChangeUserInfo, RES_STATE.BAD_REQUEST);
            }
        }
    }
}
