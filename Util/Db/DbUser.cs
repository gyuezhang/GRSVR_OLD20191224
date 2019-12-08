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
                    Db.Exec(cmd);
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
        public static void InitTabs()
        {
            Db.Exec("create table if not exists Grims.User(" +
                            "id int auto_increment," +
                            "name varchar(255) not null unique," +
                            "pwd varchar(255) not null," +
                            "deptId int not null," +
                            "tel varchar(255)," +
                            "email varchar(255)," +
                            "primary key(Id),foreign key(deptId) references Grims.Dept(id)" +
                            ") default charset=utf8;");
        }

        public static bool AddUser(User user)
        {
            try
            {
                string cmd = "insert into grims.user (Name,Pwd,DeptId,Tel,Email) values('" + user.Name + "'" +
                    ",'" + user.Pwd +
                    "','" + user.DeptName +
                    "','" + user.Tel +
                    "','" + user.Email +
                    "');";
                Db.Exec(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool DeleteUser(User user)
        {
            try
            {
                string cmd = "delete from grims.user where ";

                    cmd += "Id='";
                    cmd += user.Id.ToString();
                    cmd += "' or ";
                cmd += "Id='-1';";
                Db.Exec(cmd);
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
                string cmd = "update grims.user set Tel='" + newTel + "',Email='" + newEmail + "' where Id='" + userid + "';";
                Db.Exec(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<User> GetAllUsers()
        {
            List<User> res = new List<User>();
            User tmp = new User();
            MySqlDataReader reader = Db.Query("select * from grims.user;");
            while (reader.Read())
            {
                tmp.Id = reader.GetInt32("Id");
                tmp.Name = reader.GetString("Name");
                tmp.Pwd = reader.GetString("Pwd");
                tmp.DeptName = reader.GetString("DeptName");
                tmp.Tel = reader.GetString("Tel");
                tmp.Email = reader.GetString("Email");
                res.Add(tmp);
            }
            return res;
        }

        public static bool ChangeUserInfo(string userid, string newTel, string newEmail)
        {
            try
            {
                string cmd = "update grims.user set Tel='" + newTel + "',Email='" + newEmail + "' where Id='" + userid + "';";
                Db.Exec(cmd);
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
                string cmd = "select grims.user.Pwd from grims.user where grims.user.Id='" + userid + "';";
                MySqlDataReader reader = Db.Query(cmd);
                string getOldPwd = "";
                while (reader.Read())
                {
                    getOldPwd = reader.GetString("Pwd");
                }
                if (getOldPwd != oldPwd)
                {
                    return false;
                }
                cmd = "update grims.user set Pwd='" + newPwd + "'where grims.user.Id='" + userid + "';";
                Db.Exec(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Login(string Name, string Pwd)
        {
            List<User> res = GetAllUsers();
            foreach (User usr in res)
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
