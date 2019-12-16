using System;
using System.Collections.Generic;
using Model;
using MySql.Data.MySqlClient;

namespace Util
{
    public class C_DbLog
    {
        public static void InitTabs()
        {
            C_Db.Exec("create table if not exists grims.log( id int auto_increment,level varchar(255),type varchar(255),userType varchar(255),userId int ,actionType varchar(255),recordTime date,description varchar(255),exContent varchar(255),primary key(id)) default charset=utf8mb4;");
        }

        public static Tuple<E_DbRState, Exception> Add(C_Log log)
        {
            return C_Db.Exec("insert into grims.log (id, level, type, userType, userId, actionType, recordTime, description, exContent) values('" + log.Id + "','" + log.LogLevel + "','" + log.LogType + "','" + log.UserType + "','" + log.UserId + "','" + log.ActionType + "','" + log.RecordTime + "','" + log.Desc + "','" + log.ExContent + "');");
        }

        public static Tuple<E_DbRState, Exception> Delete(int id)
        {
            return C_Db.Exec("delete from grims.log where id='" + id.ToString() + "';");
        }

        public static Tuple<E_DbRState, List<C_Log>, Exception> Get()
        {
            Tuple<E_DbRState, MySqlDataReader, Exception> QRes;

            string cmd = "select * from grims.log;";
            List<C_Log> res = new List<C_Log>();

            QRes = C_Db.Query(cmd);

            if (QRes.Item1 == E_DbRState.Success)
            {
                while (QRes.Item2.Read())
                {
                    C_Log tmp = new C_Log();
                    tmp.Id = QRes.Item2.GetInt32("id");
                    tmp.LogLevel = (E_LogLevel)Enum.Parse(typeof(E_LogLevel), QRes.Item2.GetString("level"), true);
                    tmp.LogType = (E_LogType)Enum.Parse(typeof(E_LogType), QRes.Item2.GetString("type"), true);
                    tmp.UserType = (E_UserType)Enum.Parse(typeof(E_UserType), QRes.Item2.GetString("userType"), true);
                    tmp.UserId = QRes.Item2.GetInt32("userId");
                    tmp.ActionType = (E_ActionType)Enum.Parse(typeof(E_ActionType), QRes.Item2.GetString("actionType"), true);
                    tmp.RecordTime = QRes.Item2.GetDateTime("recordTime");
                    tmp.Desc = QRes.Item2.GetString("description");
                    tmp.ExContent = QRes.Item2.GetString("exContent");
                    res.Add(tmp);
                }
                return new Tuple<E_DbRState, List<C_Log>, Exception>(QRes.Item1, res, QRes.Item3);
            }
            else
            {
                return new Tuple<E_DbRState, List<C_Log>, Exception>(QRes.Item1, null, QRes.Item3);
            }
        }
    }
}