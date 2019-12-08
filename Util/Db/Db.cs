using MySql.Data.MySqlClient;
using System;

namespace Util
{
    /// <summary>
    /// 数据库操作类
    /// </summary>
    public class Db
    {
        private static string _dbSvrIp;
        private static int _dbSvrPort;
        private static string _dbUserName;
        private static string _dbUserPwd;

        private static MySqlDataReader _reader;
        private static MySqlCommand _cmd;
        private static MySqlConnection _conn;

        private static MySqlConnection GetConn()
        {
            if (_conn != null)
                return _conn;
            string connStr = "datasource=" + _dbSvrIp + ";port=" + _dbSvrPort.ToString() + ";user=" + _dbUserName + ";pwd=" + _dbUserPwd + ";";
            _conn = new MySqlConnection(connStr);
            _conn.Open();
            return _conn;
        }

        private static void InitDb()
        {
            Exec("create database If Not Exists Grims Character Set UTF8");
        }

        public static void ConnDb(string ServerIp, int Port, string DbUserName, string DbUserPwd)
        {
            _dbSvrIp = ServerIp;
            _dbSvrPort = Port;
            _dbUserName = DbUserName;
            _dbUserPwd = DbUserPwd;

            InitDb();
        }

        public static MySqlDataReader Query(string cmdStr)
        {
            _cmd = new MySqlCommand(cmdStr, GetConn());
            _reader = _cmd.ExecuteReader();
            return _reader;
        }

        public static Tuple<DbRes,Exception> Exec(string cmdStr)
        {
            try
            {
                _cmd = new MySqlCommand(cmdStr, GetConn());
                _cmd.ExecuteNonQuery();
                return new Tuple<DbRes, Exception>(DbRes.Success,null);
            }
            catch (Exception e)
            {
                return new Tuple<DbRes, Exception>(DbRes.Error, e);
            }
        }

    }

    public enum DbRes
    {
        Success,
        Error,
        Created,
        Deleted,
        Changed,
        NoResult,
        GotSuccess,
        GramError,
    }
}
