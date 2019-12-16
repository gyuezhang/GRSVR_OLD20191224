using Util;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;
using System.Collections.Generic;
using System.Text;
using Model;
using Newtonsoft.Json;

namespace GRSVR
{
    public class GRServer : AppServer<GRSession>
    {
        public GRServer()
            : base(new TerminatorReceiveFilterFactory("\r\n", Encoding.UTF8))
        {
            C_Db.ConnDb("localhost", 3306, "root", "123456");
        }

        protected override bool Setup(IRootConfig rootConfig, IServerConfig config)
        {
            return base.Setup(rootConfig, config);
        }
    }

    public class GRSession : AppSession<GRSession>
    {
        public const string RESTMNT = "<RESTMNT>";

        public void Send(API_ID api_id, RES_STATE res)
        {
            string strMsg = api_id.ToString() + " " + res.ToString() + " " + RESTMNT;
            base.Send(strMsg);
        }

        public void SendLogin(RES_STATE res, C_User user)
        {
            string strMsg;
            if (res == RES_STATE.OK)
            {
                strMsg = API_ID.API_Login.ToString() + " " + res.ToString() + " " + AppServer.GetSessionByID(SessionID) + " " + JsonConvert.SerializeObject(user) + RESTMNT;
            }
            else
                strMsg = API_ID.API_Login.ToString() + " " + res.ToString() + " " + RESTMNT;
            base.Send(strMsg);
        }

        public void Send(API_ID api_id, RES_STATE res, string json)
        {
            string strMsg = api_id.ToString() + " " + res.ToString() + " " + json;
            strMsg += RESTMNT;
            base.Send(strMsg);
        }

        public void Send(API_ID api_id, RES_STATE res, List<string> Parameters)
        {
            string strMsg = api_id.ToString() + " " + res.ToString() + " ";
            foreach (string para in Parameters)
            {
                strMsg += (para + " ");
            }
            strMsg += RESTMNT;
            base.Send(strMsg);
        }

        protected override void HandleUnknownRequest(StringRequestInfo requestInfo)
        {
            base.HandleUnknownRequest(requestInfo);
        }

        protected override void OnSessionStarted()
        {
            this.Send(API_ID.API_ConnState, RES_STATE.OK);
        }
    }
}
