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
            Tuple<E_DbRState, MySqlDataReader, Exception> QRes;

            C_Db.Exec("create table if not exists grims.adminPwd(pwd varchar(255) not null) default charset=utf8;");

            QRes = C_Db.Query("select * from grims.adminPwd;");
            if (QRes.Item1 == E_DbRState.Success)
            {
                if (!QRes.Item2.HasRows)
                {
                    C_Db.Exec("insert into grims.AdminPwd (pwd) values('" + C_Md5.GetHash("123456") + "');");
                }
            }
        }

        public static Tuple<E_DbRState, Exception> ResetPwd(string oldPwd, string newPwd)
        {
            Tuple<E_DbRState, MySqlDataReader, Exception> QRes = C_Db.Query("select * from grims.adminPwd;");
            if (QRes.Item1 == E_DbRState.Failed) 
                return new Tuple<E_DbRState, Exception>(QRes.Item1, QRes.Item3);
            QRes.Item2.Read();
            if (oldPwd == QRes.Item2.GetString("pwd"))
            {
                return C_Db.Exec("update grims.adminPwd set pwd='" + newPwd + "';");
            }
            else
            {
                return new Tuple<E_DbRState, Exception>(E_DbRState.ErrorPwd, null);
            }
        }

        public static Tuple<E_DbRState, Exception> Login(string pwd)
        {
            Tuple<E_DbRState, MySqlDataReader, Exception> QRes = C_Db.Query("select * from grims.adminPwd;");
            if(QRes.Item1 == E_DbRState.Failed)
                return new Tuple<E_DbRState, Exception>(QRes.Item1, QRes.Item3);
                
            QRes.Item2.Read();
            if (pwd == QRes.Item2.GetString("pwd"))
                return new Tuple<E_DbRState, Exception>(E_DbRState.Success, null);
            else
                return new Tuple<E_DbRState, Exception>(E_DbRState.ErrorPwd, null);
        }
    }

    public class C_DbDept
    {
        public static void InitTabs()
        {
            C_Db.Exec("create table if not exists grims.dept(id int auto_increment,deptName varchar(255) not null unique,primary key(id)) default charset=utf8;");
        }

        //OUT
        public static Tuple<E_DbRState, Exception> Add(string deptName)
        {
            return C_Db.Exec("insert into grims.dept (deptName) values('" + deptName + "');");
        }

        //OUT
        public static Tuple<E_DbRState, Exception> Delete(string deptName)
        {
            return C_Db.Exec("delete from grims.dept where deptName='" + deptName + "');");
        }

        //OUT
        public static Tuple<E_DbRState, Exception> Change(string oldDeptName, string newDeptName)
        {
            return C_Db.Exec("update grims.dept set deptName='" + newDeptName + "' where deptName='" + oldDeptName + "';");
        }

        //OUT
        public static Tuple<E_DbRState, List<string>, Exception>  Get()
        {
            List<string> res = new List<string>();
            Tuple<E_DbRState, MySqlDataReader, Exception> QRes = C_Db.Query("select * from grims.dept;");
            if (QRes.Item1 == E_DbRState.Failed)
                return new Tuple<E_DbRState, List<string>, Exception>(QRes.Item1, null, QRes.Item3);

            while (QRes.Item2.Read())
            {
                res.Add(QRes.Item2.GetString("deptName"));
            }
            return new Tuple<E_DbRState, List<string>, Exception>(E_DbRState.Success, res, null);
        }

        public static Tuple<E_DbRState, string, Exception> GetIdByName(string name)
        {
            Tuple<E_DbRState, MySqlDataReader, Exception> QRes = C_Db.Query("select * from grims.dept;");
            if (QRes.Item1 == E_DbRState.Failed)
                return new Tuple<E_DbRState, string, Exception>(QRes.Item1, null, QRes.Item3);

            while (QRes.Item2.Read())
            {
                if (QRes.Item2.GetString("deptName") == name)
                    return new Tuple<E_DbRState, string, Exception>(E_DbRState.Success, QRes.Item2.GetString("id"), null);
            }
            return new Tuple<E_DbRState, string, Exception>(E_DbRState.Success, null, null);
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

        public static Tuple<E_DbRState, Exception> Add(C_User user)
        {
            string cmd = "insert into grims.user (name,pwd,deptId,tel,email) values('" + user.Name + "'" +
                    ",'" + user.Pwd +
                    "','" + user.DeptName +
                    "','" + user.Tel +
                    "','" + user.Email +
                    "');";
            return C_Db.Exec(cmd);
        }

        public static Tuple<E_DbRState, Exception> Delete(C_User user)
        {
            return C_Db.Exec("delete from grims.user where id='" + user.Id.ToString() + "'");
        }

        public static Tuple<E_DbRState, Exception> Change(C_User user)
        {
            return C_Db.Exec("update grims.user set name='" + user.Name + "',pwd='" + user.Pwd + "',deptId='" + user.DeptName + "',tel='" + user.Tel + "',email='" + user.Email + "' where id='" + user.Id + "';");
        }

        public static E_DbRState Login(string Name, string Pwd)
        {
            List<C_User> res = Get().Item2;
            foreach (C_User usr in res)
            {
                if (Name == usr.Name && Pwd == usr.Pwd)
                {
                    return E_DbRState.Success;
                }
            }
            return E_DbRState.ErrorPwd;
        }

        public static Tuple<E_DbRState, List<C_User>, Exception>  Get()
        {
            List<C_User> res = new List<C_User>();
            C_User tmp = new C_User();
            Tuple<E_DbRState, MySqlDataReader, Exception> QRes = C_Db.Query("select * from grims.user;");
            while (QRes.Item2.Read())
            {
                tmp.Id = QRes.Item2.GetInt32("id");
                tmp.Name = QRes.Item2.GetString("name");
                tmp.Pwd = QRes.Item2.GetString("pwd");
                tmp.DeptName = QRes.Item2.GetString("deptName");
                tmp.Tel = QRes.Item2.GetString("tel");
                tmp.Email = QRes.Item2.GetString("email");
                res.Add(tmp);
            }
            return new Tuple<E_DbRState, List<C_User>, Exception>(E_DbRState.Success, res, null);
        }
    }
}
