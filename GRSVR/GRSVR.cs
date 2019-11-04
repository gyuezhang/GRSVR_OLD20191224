using Db;
using SuperSocket.SocketBase;

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
    }
}
