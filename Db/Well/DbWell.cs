using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db
{
    public class DbWell
    {
        /// <summary>
        /// 初始化数据表
        /// </summary>
        public static void InitTabs()
        {
            DbOper.Exec("create table if not exists grims.well( "   +
                        "Id int auto_increment,                 "   +
                        "TsOrSt varchar(255),                   "   +
                        "Village varchar(255),                  "   +
                        "UnitCat varchar(255),                  "   +
                        "Loc varchar(255),                      "   +
                        "Lng double,                            "   +
                        "Lat double,                            "   +
                        "Usefor varchar(255),                   "   +
                        "IfRecordDigTime bool,                  "   +
                        "DigTime timestamp,                     "   +
                        "WaterIntakingNo varchar(255),          "   +
                        "WellDepth int,                         "   +
                        "TubeMat varchar(255),                  "   +
                        "TubeIR int,                            "   +
                        "StanWaterDepth int,                    "   +
                        "SaltWaterFloorDepth int,               "   +
                        "FilterLocLow int,                      "   +
                        "FilterLocHigh int,                     "   +
                        "StillWaterLoc int,                     "   +
                        "PumpModel varchar(255),                "   +
                        "PumpPower float,                       "   +
                        "CoverArea float,                       "   +
                        "SupPeopleNo int,                       "   +
                        "IsMfInstall bool,                      "   +
                        "IsWaterLevelOp bool,                   "   +
                        "IsConnSeepageChn bool,                 "   +
                        "SeepageChnLength float,                "   +
                        "LinkWellNo int,                        "   +
                        "Remark  varchar(255),                  "   +
                        "primary key(Id)                        "   +
                        ")default charset = utf8; ");
        }

        /// <summary>
        /// 创建机井
        /// </summary>
        /// <param name="user">机井结构体</param>
        public static bool CreateWell(STR_Well well)
        {
            try
            {
                string cmd = "insert into grims.well (      TsOrSt,             Village,                UnitCat,            Loc,                    Lng,                Lat,                " +
                                                        "   Usefor,             IfRecordDigTime,        DigTime,            WaterIntakingNo,        WellDepth,          TubeMat,            " +
                                                        "   TubeIR,             StanWaterDepth,         SaltWaterFloorDepth,FilterLocLow,           FilterLocHigh,      StillWaterLoc,      " +
                                                        "   PumpModel,          PumpPower,              CoverArea,          SupPeopleNo,            IsMfInstall,        IsWaterLevelOp,     " +
                                                        "   IsConnSeepageChn,   SeepageChnLength,       LinkWellNo,         Remark                                                          " +
                                                        ")values(" +
                                                        well.TsOrSt                 +"," +
                                                        well.Village                + "," +
                                                        well.UnitCat                + "," +
                                                        well.Loc                    + "," +
                                                        well.Lng                    + "," +
                                                        well.Lat                    + "," +
                                                        well.Usefor                 + "," +
                                                        well.IfRecordDigTime        + "," +
                                                        well.DigTime                + "," +
                                                        well.WaterIntakingNo        + "," +
                                                        well.WellDepth              + "," +
                                                        well.TubeMat                + "," +
                                                        well.TubeIR                 + "," +
                                                        well.StanWaterDepth         + "," +
                                                        well.SaltWaterFloorDepth    + "," +
                                                        well.FilterLocLow           + "," +
                                                        well.FilterLocHigh          + "," +
                                                        well.StillWaterLoc          + "," +
                                                        well.PumpModel              + "," +
                                                        well.PumpPower              + "," +
                                                        well.CoverArea              + "," +
                                                        well.SupPeopleNo            + "," +
                                                        well.IsMfInstall            + "," +
                                                        well.IsWaterLevelOp         + "," +
                                                        well.IsConnSeepageChn       + "," +
                                                        well.SeepageChnLength       + "," +
                                                        well.LinkWellNo             + "," +
                                                        well.Remark                 + "," +
                                                        ");";
                DbOper.Exec(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 删除机井
        /// </summary>
        /// <param name="id">机井Id</param>
        /// <returns></returns>
        public static bool DeleteWell(int id)
        {
            try
            {
                string cmd = "delete from grims.well where Id='" + id + "';";
                DbOper.Exec(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 修改机井信息
        /// </summary>
        /// <param name="well">机井信息</param>
        /// <returns></returns>
        public static bool ChangeWell(STR_Well well)
        {
            try
            {
                string cmd = "  update grims.well set" +
                                "TsOrSt             ='" + well.TsOrSt              + "'," +
                                "Village            ='" + well.Village             + "'," +
                                "UnitCat            ='" + well.UnitCat             + "'," +
                                "Loc                ='" + well.Loc                 + "'," +
                                "Lng                ='" + well.Lng                 + "'," +
                                "Lat                ='" + well.Lat                 + "'," +
                                "Usefor             ='" + well.Usefor              + "'," +
                                "IfRecordDigTime    ='" + well.IfRecordDigTime     + "'," +
                                "DigTime            ='" + well.DigTime             + "'," +
                                "WaterIntakingNo    ='" + well.WaterIntakingNo     + "'," +
                                "WellDepth          ='" + well.WellDepth           + "'," +
                                "TubeMat            ='" + well.TubeMat             + "'," +
                                "TubeIR             ='" + well.TubeIR              + "'," +
                                "StanWaterDepth     ='" + well.StanWaterDepth      + "'," +
                                "SaltWaterFloorDepth='" + well.SaltWaterFloorDepth + "'," +
                                "FilterLocLow       ='" + well.FilterLocLow        + "'," +
                                "FilterLocHigh      ='" + well.FilterLocHigh       + "'," +
                                "StillWaterLoc      ='" + well.StillWaterLoc       + "'," +
                                "PumpModel          ='" + well.PumpModel           + "'," +
                                "PumpPower          ='" + well.PumpPower           + "'," +
                                "CoverArea          ='" + well.CoverArea           + "'," +
                                "SupPeopleNo        ='" + well.SupPeopleNo         + "'," +
                                "IsMfInstall        ='" + well.IsMfInstall         + "'," +
                                "IsWaterLevelOp     ='" + well.IsWaterLevelOp      + "'," +
                                "IsConnSeepageChn   ='" + well.IsConnSeepageChn    + "'," +
                                "SeepageChnLength   ='" + well.SeepageChnLength    + "'," +
                                "LinkWellNo         ='" + well.LinkWellNo          + "'," +
                                "Remark             ='" + well.Remark + "'," +
                                "where Id = '" + well.Id +"'" + 
                                ";";
                DbOper.Exec(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 根据filter获取符合条件的机井
        /// </summary>
        /// <param name="filter">where(filter)</param>
        /// <returns></returns>
        public static List<STR_Well> GetWellByFilter(string filter)
        {
            List<STR_Well> res = new List<STR_Well>();

            try
            {
                MySqlDataReader reader;
                if (filter == "")
                    reader = DbOper.Query("select * from grims.well;");
                else
                    reader = DbOper.Query("select * from grims.well where (" + filter + ");");

                while (reader.Read())
                {
                    STR_Well well = new STR_Well();
                    well.Id = reader.GetInt32("Id");
                    well.TsOrSt = reader.GetString("TsOrSt ");
                    well.Village = reader.GetString("Village");
                    well.UnitCat = reader.GetString("UnitCat");
                    well.Loc = reader.GetString("Loc");
                    well.Lng = reader.GetDouble("Lng");
                    well.Lat = reader.GetDouble("Lat");
                    well.Usefor = reader.GetString("Usefor ");
                    well.IfRecordDigTime = reader.GetBoolean("IfRecordDigTime");
                    well.DigTime = new DateTime() + reader.GetTimeSpan("DigTime");
                    well.WaterIntakingNo = reader.GetString("WaterIntakingNo");
                    well.WellDepth = reader.GetInt32("WellDepth");
                    well.TubeMat = reader.GetString("TubeMat");
                    well.TubeIR = reader.GetInt32("TubeIR ");
                    well.StanWaterDepth = reader.GetInt32("StanWaterDepth ");
                    well.SaltWaterFloorDepth = reader.GetInt32("SaltWaterFloorDepth");
                    well.FilterLocLow = reader.GetInt32("FilterLocLow ");
                    well.FilterLocHigh = reader.GetInt32("FilterLocHigh");
                    well.StillWaterLoc = reader.GetInt32("StillWaterLoc");
                    well.PumpModel = reader.GetString("PumpModel");
                    well.PumpPower = reader.GetFloat("PumpPower");
                    well.CoverArea = reader.GetFloat("CoverArea");
                    well.SupPeopleNo = reader.GetInt32("SupPeopleNo");
                    well.IsMfInstall = reader.GetBoolean("IsMfInstall");
                    well.IsWaterLevelOp = reader.GetBoolean("IsWaterLevelOp");
                    well.IsConnSeepageChn = reader.GetBoolean("IsConnSeepageChn");
                    well.SeepageChnLength = reader.GetFloat("SeepageChnLength");
                    well.LinkWellNo = reader.GetInt32("LinkWellNo");
                    well.Remark = reader.GetString("Remark ");
                    res.Add(well);
                }
                return res;
            }
            catch
            {
                return res;
            }
        }
    }
}
