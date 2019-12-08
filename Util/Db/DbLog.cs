using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using MySql.Data.MySqlClient;

namespace Util
{
    /// <summary>
    /// 数据库日志操作，本身不记录日志
    /// </summary>
    public class C_DbLog
    {
        public static void InitTabs()
        {
            try
            {
                C_Db.Exec("create table if not exists grims.log(" +
                                "id int auto_increment," +
                                "logType varchar(255) not null," +
                                "userType varchar(255) not null," +
                                "userId int not null," +
                                "operType varchar(255) not null," +
                                "recordTime date," +
                                "content varchar(255)," +
                                "primary key(id) ) default charset=utf8;");
            }
            catch
            {

            }
        }

        public static void Record(C_Log log)
        {
            try
            {
                string cmd = "insert into grims.log (logType,userType,userId,operType,recordTime,content) values('" + log.LogType +
                            "','" + log.UserType +
                            "','" + log.UserId +
                            "','" + log.OperType +
                            "','" + log.RecordTime +
                            "','" + log.Desc +
                            "');";
                C_Db.Exec(cmd);
            }
            catch
            {

            }
        }

        public static List<C_Log> Get()
        {
            List<C_Log> logs = new List<C_Log>();
            try
            {
                string cmd = "select * from grims.log;";
                MySqlDataReader reader = C_Db.Query(cmd).Item2;
                C_Log tmp = new C_Log();
                while (reader.Read())
                {
                    tmp.Id = reader.GetInt32("id");
                    tmp.LogType = (E_LogType)Enum.Parse(typeof(E_LogType), reader.GetString("logType"), true);
                    tmp.UserType = (E_UserType)Enum.Parse(typeof(E_UserType), reader.GetString("userType"), true);
                    tmp.UserId = reader.GetInt32("userId");
                    tmp.OperType = (E_OperType)Enum.Parse(typeof(E_OperType), reader.GetString("operType"), true);
                    tmp.RecordTime = reader.GetDateTime("recordTime");
                    tmp.Desc = reader.GetString("content");
                    logs.Add(tmp);
                }
                return logs;
            }
            catch
            {
                return new List<C_Log>();
            }

        }
    }

}
