using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRSVR
{
    public enum API_ADMIN_ID
    {
        //Admin_API
        API_Admin_Login,
        API_Admin_ChangePwd,
        API_Admin_CreateDept,
        API_Admin_DeleteDept,
        API_Admin_ChangeDept,
        API_Admin_GetAllDepts,
        API_Admin_CreateUser,
        API_Admin_DeleteUsers,
        API_Admin_ChangeUser,
        API_Admin_GetAllUsers,

    }

    public enum API_ID
    {
        //User_API
        API_Login,
        API_ChangeAccount,
    }

    public enum RES_ID
    {
        OK,
        FAILED,
        BAD_REQUEST,
    }
}
