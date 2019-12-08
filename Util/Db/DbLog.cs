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
                            "name varchar(255) not null unique," +
                            "pwd varchar(255) not null," +
                            "deptId int not null," +
                            "tel varchar(255)," +
                            "email varchar(255)," +
                            "primary key(Id),foreign key(deptId) references Grims.Dept(id)" +
                            ") default charset=utf8;");
        }

    }

}
