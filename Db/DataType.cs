using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db
{
    public struct STR_User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pwd { get; set; }
        public int DeptId { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
    }
}
