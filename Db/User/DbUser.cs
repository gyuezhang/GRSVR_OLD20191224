using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Db
{
    public class DbUser
    {
        /// <summary>
        /// 初始化数据表
        /// </summary>
        public static void InitTabs()
        {
            DbOper.Exec("create table if not exists grims.user(" +
                            "Id int auto_increment," +
                            "Name varchar(255) not null unique," +
                            "Pwd varchar(255) not null," +
                            "DeptId int not null," +
                            "Tel varchar(255)," +
                            "Email varchar(255)," +
                            "primary key(Id),foreign key(DeptId) references grims.dept(Id)" +
                            ") default charset=utf8;");
        }

        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns>用户结构体列表</returns>
        public static List<STR_User> GetAllUsers()
        {
            List<STR_User> res = new List<STR_User>();
            STR_User tmp = new STR_User();
            MySqlDataReader reader = DbOper.Query("select * from grims.user;");
            while (reader.Read())
            {
                tmp.Id = reader.GetInt32("Id");
                tmp.Name = reader.GetString("Name");
                tmp.Pwd = reader.GetString("Pwd");
                tmp.DeptId = reader.GetInt32("DeptId");
                tmp.Tel = reader.GetString("Tel");
                tmp.Email = reader.GetString("Email");
                res.Add(tmp);
            }
            return res;
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="user">用户结构体</param>
        public static bool CreateUser(STR_User user)
        {
            try
            {
                string cmd = "insert into grims.user (Name,Pwd,DeptId,Tel,Email) values('" + user.Name + "'" +
                    ",'" + user.Pwd +
                    "','" + user.DeptId +
                    "','" + user.Tel +
                    "','" + user.Email +
                    "');";
                DbOper.Exec(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 根据用户id删除用户
        /// </summary>
        /// <param name="userId">用户id</param>
        public static bool DeleteUser(List<int> userIds)
        {
            try
            {
                string cmd = "delete from grims.user where ";
                foreach(int id in userIds)
                {
                    cmd += "Id='";
                    cmd += id.ToString();
                    cmd += "' or ";
                }
                cmd += "Id='-1';";
                DbOper.Exec(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="user">用户结构体</param>
        public static bool ChangeUser(STR_User user)
        {
            try
            {
                string cmd = "update grims.user set Name='" + user.Name + "'," +
                    "Pwd='" + user.Pwd + "'," +
                    "DeptId='" + user.DeptId + "'," +
                    "Tel='" + user.Tel + "'," +
                    "Email='" + user.Email +
                    "' where Id='" + user.Id + "';";
                DbOper.Exec(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 根据用户名获取用户结构体
        /// </summary>
        /// <param name="name">用户名</param>
        /// <returns>用户结构体</returns>
        public static User GetUserByUserName(string name)
        {
            User res = new User();
            //user2';
            MySqlDataReader reader = DbOper.Query("select grims.user.Id,grims.user.Name,grims.dept.DeptName,grims.user.Tel,grims.user.Email from grims.user left outer join grims.dept on grims.user.DeptId = grims.dept.Id where grims.user.Name='" + name + "';");
            while (reader.Read())
            {
                res.Id = reader.GetString("Id");
                res.Name = reader.GetString("Name");
                res.Pwd = "";
                res.DeptName = reader.GetString("DeptName");
                res.Tel = reader.GetString("Tel");
                res.Email = reader.GetString("Email");
            }
            return res;
        }

        /// <summary>
        /// 查询用户名密码
        /// </summary>
        /// <param name="Name">用户名</param>
        /// <param name="Pwd">密码</param>
        /// <returns>成功返回true,失败返回false</returns>
        public static bool Login(string Name, string Pwd)
        {
            List<STR_User> res = GetAllUsers();
            foreach (STR_User usr in res)
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
