﻿using Model;
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

        private static MySqlConnection _conn;

        private static MySqlConnection GetConn()
        {
            string connStr = "datasource=" + _dbSvrIp + ";port=" + _dbSvrPort.ToString() + ";user=" + _dbUserName + ";pwd=" + _dbUserPwd + ";";
            _conn = new MySqlConnection(connStr);
            _conn.Open();
            return _conn;
        }

        private static void InitDb()
        {
            Exec("create database If Not Exists grims Character Set UTF8");
            
            C_DbAreaCode.InitTabs();
            C_DbAdminUser.InitTabs();
            C_DbDept.InitTabs();
            C_DbUser.InitTabs();
            C_DbWell.InitTabs();
        }

        public static void ConnDb(string ServerIp, int Port, string DbUserName, string DbUserPwd)
        {
            _dbSvrIp = ServerIp;
            _dbSvrPort = Port;
            _dbUserName = DbUserName;
            _dbUserPwd = DbUserPwd;

            InitDb();
        }

        public static Tuple<E_DbRState, MySqlDataReader, Exception>  Query(string cmdStr)
        {
            try
            {
                MySqlDataReader _reader;
                MySqlCommand _cmd;
                _cmd = new MySqlCommand(cmdStr, GetConn());
                _reader = _cmd.ExecuteReader();
                return new Tuple<E_DbRState, MySqlDataReader, Exception>(E_DbRState.Success, _reader, null);
            }
            catch (Exception e)
            {
                return new Tuple<E_DbRState, MySqlDataReader, Exception>(E_DbRState.Failed, null, e);
            }
        }

        public static Tuple<E_DbRState,Exception> Exec(string cmdStr)
        {
            try
            {
                MySqlCommand _cmd;
                _cmd = new MySqlCommand(cmdStr, GetConn());
                _cmd.ExecuteNonQuery();
                return new Tuple<E_DbRState, Exception>(E_DbRState.Success,null);
            }
            catch (Exception e)
            {
                return new Tuple<E_DbRState, Exception>(E_DbRState.Failed, e);
            }
        }

    }
}
