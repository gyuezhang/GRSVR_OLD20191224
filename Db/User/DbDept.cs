using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Db
{
    public class DbDept
    {
        /// <summary>
        /// 初始化数据表
        /// </summary>
        public static void InitTabs()
        {
            DbOper.Exec("create table if not exists grims.dept(Id int auto_increment,Name varchar(255) not null unique,primary key(Id)) default charset=utf8;");
        }

        /// <summary>
        /// 获取所有部门
        /// </summary>
        /// <returns>返回部门名字符串列表</returns>
        public static List<string> GetAllDepts()
        {
            List<string> res = new List<string>();
            MySqlDataReader reader = DbOper.Query("select * from grims.dept;");
            while (reader.Read())
            {
                res.Add(reader.GetString("Name"));
            }
            return res;
        }

        /// <summary>
        /// 通过部门名新建部门
        /// </summary>
        /// <param name="strDeptName">部门名</param>
        public static bool CreateDept(string strDeptName)
        {
            try
            {
                string cmd = "insert into grims.dept (Name) values('" + strDeptName + "');";
                DbOper.Exec(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 通过部门名删除部门
        /// </summary>
        /// <param name="strDeptName">部门名</param>
        public static bool DeleteDept(string strDeptName)
        {
            try
            {
                string cmd = "delete from grims.dept where Name='" + strDeptName + "';";
                DbOper.Exec(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 修改部门名
        /// </summary>
        /// <param name="strOldName">旧名</param>
        /// <param name="strNewName">新名</param>
        public static bool ChangeDept(string strOldName, string strNewName)
        {
            try
            {
                string cmd = "update grims.dept set Name='" + strNewName + "' where Name='" + strOldName + "';";
                DbOper.Exec(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 通过部门名获取部门id
        /// </summary>
        /// <param name="strDeptName">部门名</param>
        /// <returns>部门id</returns>
        public static int GetDeptIdByName(string strDeptName)
        {
            string cmd = "select * from grims.dept where Name='" + strDeptName + "';";
            MySqlDataReader reader = DbOper.Query(cmd);
            int res = 0;
            while (reader.Read())
            {
                res = reader.GetInt32("Id");
            }
            return res;
        }

        /// <summary>
        /// 通过部门id获取部门名
        /// </summary>
        /// <param name="iDeptId">部门id</param>
        /// <returns>部门名</returns>
        public static string GetDeptNameById(int iDeptId)
        {
            string cmd = "select * from grims.dept where Id='" + iDeptId + "';";
            MySqlDataReader reader = DbOper.Query(cmd);
            string res = "";
            while (reader.Read())
            {
                res = reader.GetString("Name");
            }
            return res;
        }
    }
}
