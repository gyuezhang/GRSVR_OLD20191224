﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRSVR
{
    public enum API_ID
    {
        API_ConnState,

        API_Admin_Login,
        API_Admin_ChangePwd, 
        API_ChangeUserInfo,
        API_ResetPwd,

        API_Admin_CreateDept,
        API_Admin_DeleteDept,
        API_Admin_ChangeDept,
        API_Admin_GetAllDepts,
        API_Admin_CreateUser,
        API_Admin_DeleteUsers,
        API_Admin_ChangeUser,
        API_Admin_GetAllUsers,
        API_Admin_GetDeptIdByName,

        API_Login,
        API_ChangeAccount, 
        API_GetUserInfo,

        API_ChangeWell,
        API_CreateWell,
        API_DeleteWell,
        API_GetWellByFilter,
        API_SetWellParas,
        API_GetWellParas,

        API_ChangeEntWell,
        API_CreateEntWell,
        API_DeleteEntWell,
        API_GetEntWellByFilter,

        API_GetLevelZoning,
    }

    public enum RES_STATE
    {
        OK,         //成功
        FAILED,
        BAD_REQUEST,//请求参数（格式）错误
        INCORRECT,//请求参数（值）不正确
    }
}
