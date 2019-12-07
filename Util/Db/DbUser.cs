using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using MySql.Data.MySqlClient;

namespace Util
{
    public class DbAdminUser
    {
        public static void InitTabs()
        {
            Db.Exec("create table if not exists Grims.AdminPwd(pwd varchar(255) not null) default charset=utf8;");

            string cmd = "select * from Grims.AdminPwd;";
            MySqlDataReader reader = Db.Query(cmd);
            if (!reader.HasRows)
            {
                Db.Exec("insert into Grims.AdminPwd (pwd) values(\'123456\');");
            }
        }

        public static bool Login(string pwd)
        {
            try
            {
                MySqlDataReader reader = Db.Query("select * from Grims.AdminPwd;");
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
            MySqlDataReader reader = Db.Query("select * from Grims.AdminPwd;");
            try
            {
                if(oldPwd == reader.GetString("pwd"))
                {
                    string cmd = "udpate Grims.AdminPwd set pwd='" + newPwd + "';";
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

    public class DbDept
    {
        public static void InitTabs()
        {
            Db.Exec("create table if not exists Grims.Dept(id int auto_increment,deptName varchar(255) not null unique,primary key(Id)) default charset=utf8;");
        }

        public static bool AddDept(string deptName)
        {
            try
            {
                string cmd = "insert into Grims.Dept (deptName) values('" + deptName + "');";
                Db.Exec(cmd);
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
                string cmd = "delete from Grims.Dept where deptName='" + deptName + "');";
                Db.Exec(cmd);
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
                string cmd = "update Grims.Dept set deptName='" + newDeptName + "' where deptName='" + oldDeptName + "';";
                Db.Exec(cmd);
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
            MySqlDataReader reader = Db.Query("select * from Grims.Dept;");

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

    public class DbUser
    {

    }
}
