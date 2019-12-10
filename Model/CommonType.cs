using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 日志类型
    /// </summary>
    public enum E_LogType
    {
        Db,
        Svr,
    }

    /// <summary>
    /// 用户类型
    /// </summary>
    public enum E_UserType
    {
        Admin,
        User,
        Sys,
    }

    /// <summary>
    /// 操作类型
    /// </summary>
    public enum E_OperType
    {
        AreaCodeInitTab,
        AreaCodeInitData,
        AreaCodeGet,

        AdminUserInitTab,
        AdminUserGet,
        AdminUserInitPwd,

    }

    /// <summary>
    /// 机井参数类型
    /// </summary>
    public enum E_WellParaType
    {
        UnitCat,
        Loc,
        TubeMat,
        PumpModel,
        UseFor,
    }

    /// <summary>
    /// 数据库操作返回状态值
    /// </summary>
    public enum E_DbRState
    {
        //Db Return
        Success,
        Failed,
        //Other Return
        Created,
        Deleted,
        Changed,
        NoResult,
        GotSuccess,
        GramError,

        //LOGIN
        ErrorPwd,
    }

    public enum API_ID
    {
        API_ConnState,

        API_AddAreaCode,
        API_DeleteAreaCode,
        API_ChangeAreaCode,
        API_GetAreaCodes,

        API_AdminUserResetPwd,
        API_AdminUserLogin,

        API_AddDept,
        API_DeleteDept,
        API_ChangeDept,
        API_GetDepts,

        API_AddUser,
        API_DeleteUser,
        API_ChangeUser,
        API_GetUsers,
        API_Login,
        API_ResetPwd,

        API_AddEntWell,
        API_ChangeEntWell,
        API_DeleteEntWell,
        API_GetEntWells,

        API_AddEntWellPara,
        API_ChangeEntWellPara,
        API_DeleteEntWellPara,
        API_GetEntWellParas,

        API_AddWell,
        API_ChangeWell,
        API_DeleteWell,
        API_GetWells,

        API_AddWellPara,
        API_ChangeWellPara,
        API_DeleteWellPara,
        API_GetWellParas,



    }

    public enum RES_STATE
    {
        OK,         //成功
        FAILED,
        BAD_REQUEST,//请求参数（格式）错误
        INCORRECT,//请求参数（值）不正确
    }
}
