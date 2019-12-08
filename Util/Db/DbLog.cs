using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using MySql.Data.MySqlClient;

namespace Util
{
    public class C_DbLog
    {
        public static void InitTabs()
        {
            C_Db.Exec("create table if not exists Grims.Log(" +
                            "id int auto_increment," +
                            "logType varchar(255) not null," +
                            "userType varchar(255) not null," +
                            "userId int not null," +
                            "operType varchar(255) not null," +
                            "content varchar(255)," +
                            "primary key(id) ) default charset=utf8;");
        }

    }

}
