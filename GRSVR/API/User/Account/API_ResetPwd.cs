using Db;
using Newtonsoft.Json;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

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
            //{"name":"123","pwd":"abc"}
            try
            {
                ;
                string req = string.Join("", requestInfo.Parameters);
                API_ResetPwd_Req a = JsonConvert.DeserializeObject<API_ResetPwd_Req>(req);
                if (DbUser.ResetPwd(a.Id, a.OldPwd, a.NewPwd))
                {
                    session.Send(API_ID.API_ResetPwd, RES_STATE.OK);
                }
                else
                {
                    session.Send(API_ID.API_ResetPwd, RES_STATE.FAILED);
                }
            }
            catch
            {
                session.Send(API_ID.API_ResetPwd, RES_STATE.BAD_REQUEST);
            }
        }
    }
}
