using Db;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using System.Collections.Generic;

namespace GRSVR
{
    public class GRServer:AppServer<GRSession>
    {
        public GRServer()
        {
            DbOper.ConnDb("localhost", "3306", "root", "123456");
        }
    }

    public class GRSession:AppSession<GRSession>
    {
        public const string RESTMNT = "<RESTMNT>";

        public void Send(API_ADMIN_ID api_id, RES_ID res)
        {
            string strMsg = api_id.ToString() + " " + res.ToString() + " " + RESTMNT;
            base.Send(strMsg);
        }

        public void Send(API_ADMIN_ID api_id, RES_ID res, List<string> Parameters)
        {
            string strMsg = api_id.ToString() + " " + res.ToString() + " ";
            foreach(string para in Parameters)
            {
                strMsg += (para+" ");
            }
            strMsg += RESTMNT;
            base.Send(strMsg);
        }

        protected override void HandleUnknownRequest(StringRequestInfo requestInfo)
        {
            base.HandleUnknownRequest(requestInfo);
        }
    }
}
