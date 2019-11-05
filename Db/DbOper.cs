using MySql.Data.MySqlClient;

namespace Db
{
    public class DbOper
    {
        /// <summary>
        /// 单例模式
        /// </summary>
        private static string ServerIp { get; set; }
        private static string Port { get; set; }
        private static string DbUserName { get; set; }
        private static string DbUserPwd { get; set; }

        private static MySqlDataReader Reader { get; set; }
        private static MySqlCommand Cmd { get; set; }
        private static MySqlConnection Conn { get; set; }

        private static MySqlConnection GetConn()
        {
            string connStr = "datasource=" + ServerIp + ";port=" + Port + ";user=" + DbUserName + ";pwd=" + DbUserPwd + ";";
            Conn = new MySqlConnection(connStr);
            Conn.Open();
            return Conn;
        }

        private static void InitDb()
        {
            Exec("create database If Not Exists grims Character Set UTF8");

            DbAdminUser.InitTabs();
            DbDept.InitTabs();
            DbUser.InitTabs();
        }

        /// <summary>
        /// 调用接口前，需要预先设置此项
        /// </summary>
        /// <param name="iServerIp">服务器IP地址</param>
        /// <param name="iPort">端口号</param>
        /// <param name="iDbUserName">数据库用户名</param>
        /// <param name="iDbUserPwd">数据库密码</param>
        public static void ConnDb(string iServerIp, string iPort, string iDbUserName, string iDbUserPwd)
        {
            ServerIp = iServerIp;
            Port = iPort;
            DbUserName = iDbUserName;
            DbUserPwd = iDbUserPwd;
            //连接后初始化数据库
            InitDb();
        }

        /// <summary>
        /// 查询操作
        /// </summary>
        /// <param name="cmdStr">查询命令</param>
        /// <returns>返回查询结果</returns>
        public static MySqlDataReader Query(string cmdStr)
        {
            Cmd = new MySqlCommand(cmdStr, GetConn());
            Reader = Cmd.ExecuteReader();
            return Reader;
        }

        /// <summary>
        /// 执行操作
        /// </summary>
        /// <param name="cmdStr">执行命令</param>
        public static void Exec(string cmdStr)
        {
            Cmd = new MySqlCommand(cmdStr, GetConn());
            Cmd.ExecuteNonQuery();
        }

    }
}
