using MySql.Data.MySqlClient;

namespace Db
{
    class DbAdminUser
    {
        /// <summary>
        /// 初始化数据表，首次初始化生成默认用户名密码
        /// </summary>
        public static void InitTabs()
        {
            DbOper.Exec("create table if not exists grims.admin(Name varchar(255) not null unique,Pwd varchar(255) not null) default charset=utf8;");

            string cmd = "select * from grims.admin;";
            MySqlDataReader reader = DbOper.Query(cmd);
            if (!reader.HasRows)
            {
                DbOper.Exec("insert into grims.admin (Name,Pwd) values(\'admin\',\'123456\');");
            }
        }

        /// <summary>
        /// 查找AdminUser表中对应用户名密码是否正确
        /// </summary>
        /// <param name="Name">管理员用户名</param>
        /// <param name="Pwd">管理员密码</param>
        /// <returns>成功返回true,失败返回false</returns>
        public static bool Login(string Name, string Pwd)
        {
            MySqlDataReader reader = DbOper.Query("select * from grims.admin;");
            reader.Read();
            if ((reader.GetString("Name") == Name) && (Pwd == reader.GetString("Pwd")))
                return true;
            else
                return false;
        }

        /// <summary>
        /// 更换管理员密码
        /// </summary>
        /// <param name="oldPwd">旧的密码</param>
        /// <param name="newPwd">新的密码</param>
        /// <returns>成功返回true,失败返回false</returns>
        public static bool ChangePwd(string oldPwd, string newPwd)
        {
            MySqlDataReader reader = DbOper.Query("select * from grims.admin;");
            reader.Read();
            if (oldPwd == reader.GetString("Pwd"))
            {
                string cmd = "update grims.admin set Pwd='" + newPwd + "' where Name='admin';";
                DbOper.Exec(cmd);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
