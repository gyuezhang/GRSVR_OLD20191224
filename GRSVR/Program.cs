using Util;

namespace GRSVR
{
    class Program
    {
        static void Main(string[] args)
        {
            C_Db.ConnDb("127.0.0.1", 3306, "root", "123456");
            _ = C_DbAreaCode.Get().Item2;
            _ = C_DbAdminUser.Login("888");
        }
    }
}
