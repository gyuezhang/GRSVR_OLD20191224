using Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DbOper.ConnDb("localhost", "3306", "root", "123456");
            TestDbAdminUser();

            Console.ReadLine();
        }

        static void TestDbAdminUser()
        {
            //测试Login函数
            if (DbAdminUser.Login("admin2", "123123"))
            {
                Console.WriteLine("测试Login函数  ->  Login : admin2 123123 成功!");
            }
            else
            {
                Console.WriteLine("测试Login函数  ->  Login : admin2 123123 失败!");
            }
            if (DbAdminUser.Login("admin", "123456"))
            {
                Console.WriteLine("测试Login函数  ->  Login : admin 123456 成功!");
            }
            else
            {
                Console.WriteLine("测试Login函数  ->  Login : admin 123456 失败!");
            }

            //测试修改密码
            if (DbAdminUser.ChangePwd("123123", "aaaaaa"))
            {
                Console.WriteLine("测试ChangePwd函数  ->  ChangePwd : 123123 aaaaaa 成功!");
            }
            else
            {
                Console.WriteLine("测试ChangePwd函数  ->  ChangePwd : 123123 aaaaaa 失败!");
            }
            if (DbAdminUser.ChangePwd("123456", "bbbbbb"))
            {
                Console.WriteLine("测试ChangePwd函数  ->  ChangePwd : 123456 bbbbbb 成功!");
            }
            else
            {
                Console.WriteLine("测试ChangePwd函数  ->  ChangePwd : 123456 bbbbbb 失败!");
            }
        }
    }
}
