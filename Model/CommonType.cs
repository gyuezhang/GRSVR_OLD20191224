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
}
