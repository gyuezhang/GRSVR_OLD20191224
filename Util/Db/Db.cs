using Model;
using MySql.Data.MySqlClient;
using System;

namespace Util
{
    /// <summary>
    /// 数据库操作类
    /// </summary>
    public class C_Db
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

        public static Tuple<E_DbRes, MySqlDataReader, Exception>  Query(string cmdStr)
        {
            try
            {
                _cmd = new MySqlCommand(cmdStr, GetConn());
                _reader = _cmd.ExecuteReader();
                return new Tuple<E_DbRes, MySqlDataReader, Exception>(E_DbRes.Success, _reader, null);
            }
            catch (Exception e)
            {
                return new Tuple<E_DbRes, MySqlDataReader, Exception>(E_DbRes.Error, null, e);
            }
        }

        public static Tuple<E_DbRes,Exception> Exec(string cmdStr)
        {
            try
            {
                _cmd = new MySqlCommand(cmdStr, GetConn());
                _cmd.ExecuteNonQuery();
                return new Tuple<E_DbRes, Exception>(E_DbRes.Success,null);
            }
            catch (Exception e)
            {
                return new Tuple<E_DbRes, Exception>(E_DbRes.Error, e);
            }
        }

    }
}
