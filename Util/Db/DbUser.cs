using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using MySql.Data.MySqlClient;

namespace Util
{
    public class C_DbAdminUser
    {
        public static void InitTabs()
        {
            Tuple<E_DbRes, Exception> ERes;
            Tuple<E_DbRes, MySqlDataReader, Exception> QRes;

            ERes = C_Db.Exec("create table if not exists grims.adminPwd(pwd varchar(255) not null) default charset=utf8;");
            if (ERes.Item1 != E_DbRes.Success)
            {
                C_DbLog.Record(new C_Log(E_LogType.Db, E_UserType.Sys, 0, E_OperType.AdminUserInitTab, "", ERes.Item2.Message));
            }

            QRes = C_Db.Query("select * from grims.adminPwd;");
            if (QRes.Item1 == E_DbRes.Success)
            {
                if (!QRes.Item2.HasRows)
                {
                    ERes = C_Db.Exec("insert into grims.AdminPwd (pwd) values(\'123456\');");
                    if(ERes.Item1 != E_DbRes.Success)
                    {
                        C_DbLog.Record(new C_Log(E_LogType.Db, E_UserType.Sys, 0, E_OperType.AdminUserInitPwd, "", ERes.Item2.Message));
                    }
                }
            }
            else
            {
                C_DbLog.Record(new C_Log(E_LogType.Db, E_UserType.Sys, 0, E_OperType.AdminUserGet, "", ERes.Item2.Message));
            }
        }

        public static bool Login(string pwd)
        {
            try
            {
                MySqlDataReader reader = C_Db.Query("select * from grims.adminPwd;").Item2;
                reader.Read();
                if (pwd == reader.GetString("pwd"))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool ChangePwd(string oldPwd, string newPwd)
        {
            MySqlDataReader reader = C_Db.Query("select * from grims.adminPwd;").Item2;
            try
            {
                if(oldPwd == reader.GetString("pwd"))
                {
                    string cmd = "udpate grims.adminPwd set pwd='" + newPwd + "';";
                    C_Db.Exec(cmd);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }

    public class C_DbDept
    {
        public static void InitTabs()
        {
            C_Db.Exec("create table if not exists grims.dept(id int auto_increment,deptName varchar(255) not null unique,primary key(id)) default charset=utf8;");
        }

        public static bool AddDept(string deptName)
        {
            try
            {
                string cmd = "insert into grims.dept (deptName) values('" + deptName + "');";
                C_Db.Exec(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool DeleteDept(string deptName)
        {
            try
            {
                string cmd = "delete from grims.dept where deptName='" + deptName + "');";
                C_Db.Exec(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ChangeDept(string oldDeptName, string newDeptName)
        {
            try
            {
                string cmd = "update grims.dept set deptName='" + newDeptName + "' where deptName='" + oldDeptName + "';";
                C_Db.Exec(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<string> GetAllDepts()
        {
            List<string> res = new List<string>();
            MySqlDataReader reader = C_Db.Query("select * from grims.dept;").Item2;

            try
            {
                while (reader.Read())
                {
                    res.Add(reader.GetString("deptName"));
                }
                return res;
            }
            catch
            {
                return res;
            }
        }
    }

    public class C_DbUser
    {
        public static void InitTabs()
        {
            C_Db.Exec("create table if not exists grims.user(" +
                            "id int auto_increment," +
                            "name varchar(255) not null unique," +
                            "pwd varchar(255) not null," +
                            "deptId int not null," +
                            "tel varchar(255)," +
                            "email varchar(255)," +
                            "primary key(id),foreign key(deptId) references grims.dept(id)" +
                            ") default charset=utf8;");
        }

        public static bool AddUser(C_User user)
        {
            try
            {
                string cmd = "insert into grims.user (name,pwd,deptId,tel,email) values('" + user.Name + "'" +
                    ",'" + user.Pwd +
                    "','" + user.DeptName +
                    "','" + user.Tel +
                    "','" + user.Email +
                    "');";
                C_Db.Exec(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool DeleteUser(C_User user)
        {
            try
            {
                string cmd = "delete from grims.user where ";

                    cmd += "id='";
                    cmd += user.Id.ToString();
                    cmd += "' or ";
                cmd += "id='-1';";
                C_Db.Exec(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ChangeUser(string userid, string newTel, string newEmail)
        {
            try
            {
                string cmd = "update grims.user set tel='" + newTel + "',email='" + newEmail + "' where id='" + userid + "';";
                C_Db.Exec(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<C_User> GetAllUsers()
        {
            List<C_User> res = new List<C_User>();
            C_User tmp = new C_User();
            MySqlDataReader reader = C_Db.Query("select * from grims.user;").Item2;
            while (reader.Read())
            {
                tmp.Id = reader.GetInt32("id");
                tmp.Name = reader.GetString("name");
                tmp.Pwd = reader.GetString("pwd");
                tmp.DeptName = reader.GetString("deptName");
                tmp.Tel = reader.GetString("tel");
                tmp.Email = reader.GetString("email");
                res.Add(tmp);
            }
            return res;
        }

        public static bool ChangeUserInfo(string userid, string newTel, string newEmail)
        {
            try
            {
                string cmd = "update grims.user set tel='" + newTel + "',email='" + newEmail + "' where id='" + userid + "';";
                C_Db.Exec(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ResetPwd(string userid, string oldPwd, string newPwd)
        {
            try
            {
                string cmd = "select grims.user.pwd from grims.user where grims.user.id='" + userid + "';";
                MySqlDataReader reader = C_Db.Query(cmd).Item2;
                string getOldPwd = "";
                while (reader.Read())
                {
                    getOldPwd = reader.GetString("pwd");
                }
                if (getOldPwd != oldPwd)
                {
                    return false;
                }
                cmd = "update grims.user set pwd='" + newPwd + "'where grims.user.id='" + userid + "';";
                C_Db.Exec(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Login(string Name, string Pwd)
        {
            List<C_User> res = GetAllUsers();
            foreach (C_User usr in res)
            {
                if (Name == usr.Name && Pwd == usr.Pwd)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
