using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db
{
    public class DbEntWell
    {
        /// <summary>
        /// 初始化数据表
        /// </summary>
        public static void InitTabs()
        {
            DbOper.Exec("create table if not exists grims.entwell(  "+
                        "Id int auto_increment,                     "+
                        "TsOrSt varchar(255),                       "+
                        "EntName varchar(255),                      "+
                        "UnitCat varchar(255),                      "+
                        "Loc varchar(255),                          "+
                        "Lng double,                                "+
                        "Lat double,                                "+
                        "Usefor varchar(255),                       "+
                        "IfRecordDigTime bool,                      "+
                        "DigTime timestamp,                         "+
                        "WaterIntakingNo varchar(255),              "+
                        "IsPaid bool,                               "+
                        "WellDepth int,                             "+
                        "TubeMat varchar(255),                      "+
                        "TubeIR int,                                "+
                        "StanWaterDepth int,                        "+
                        "SaltWaterFloorDepth int,                   "+
                        "FilterLocLow int,                          "+
                        "FilterLocHigh int,                         "+
                        "StillWaterLoc int,                         "+
                        "PumpModel varchar(255),                    "+
                        "PumpPower float,                           "+
                        "IsWaterLevelOp bool,                       "+
                        "IsMfInstall bool,                          "+
                        "Remark  varchar(255),                      "+
                        "primary key(Id)                            "+
                        ")default charset = utf8; ");
        }

        /// <summary>
        /// 创建企业井
        /// </summary>
        /// <param name="entWell">企业井结构体</param>
        /// <returns></returns>
        public static bool CreateEntWell(STR_EntWell entWell)
        {
            try
            {
                string cmd = "insert into grims.entwell (           TsOrSt,             EntName,                UnitCat,            Loc,                    Lng,                Lat,                " +
                                                                "   Usefor,             IfRecordDigTime,        DigTime,            WaterIntakingNo,        IsPaid, WellDepth,  TubeMat,            " +
                                                                "   TubeIR,             StanWaterDepth,         SaltWaterFloorDepth,FilterLocLow,           FilterLocHigh,      StillWaterLoc,      " +
                                                                "   PumpModel,          PumpPower,              IsWaterLevelOp,     IsMfInstall,            Remark, " +
                                                                ")values(" +
                                                                entWell.TsOrSt + "," +
                                                                entWell.EntName + "," +
                                                                entWell.UnitCat + "," +
                                                                entWell.Loc + "," +
                                                                entWell.Lng + "," +
                                                                entWell.Lat + "," +
                                                                entWell.Usefor + "," +
                                                                entWell.IfRecordDigTime + "," +
                                                                entWell.DigTime + "," +
                                                                entWell.WaterIntakingNo + "," +
                                                                entWell.IsPaid + "," +
                                                                entWell.WellDepth + "," +
                                                                entWell.TubeMat + "," +
                                                                entWell.TubeIR + "," +
                                                                entWell.StanWaterDepth + "," +
                                                                entWell.SaltWaterFloorDepth + "," +
                                                                entWell.FilterLocLow + "," +
                                                                entWell.FilterLocHigh + "," +
                                                                entWell.StillWaterLoc + "," +
                                                                entWell.PumpModel + "," +
                                                                entWell.PumpPower + "," +
                                                                entWell.IsWaterLevelOp + "," +
                                                                entWell.IsMfInstall + "," +
                                                                entWell.Remark + "," +
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
        /// 删除企业井
        /// </summary>
        /// <param name="id">企业井Id</param>
        /// <returns></returns>
        public static bool DeleteEntWell(int id)
        {
            try
            {
                string cmd = "delete from grims.entwell where Id='" + id + "';";
                DbOper.Exec(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 修改企业井
        /// </summary>
        /// <param name="entWell">企业井结构体</param>
        /// <returns></returns>
        public static bool ChangeEntWell(STR_EntWell entWell)
        {
            try
            {
                string cmd = "  update grims.entwell set" +
                "TsOrSt             ='" + entWell.TsOrSt + "'," +
                "EntName            ='" + entWell.EntName + "'," +
                "UnitCat            ='" + entWell.UnitCat + "'," +
                "Loc                ='" + entWell.Loc + "'," +
                "Lng                ='" + entWell.Lng + "'," +
                "Lat                ='" + entWell.Lat + "'," +
                "Usefor             ='" + entWell.Usefor + "'," +
                "IfRecordDigTime    ='" + entWell.IfRecordDigTime + "'," +
                "DigTime            ='" + entWell.DigTime + "'," +
                "WaterIntakingNo    ='" + entWell.WaterIntakingNo + "'," +
                "WellDepth          ='" + entWell.WellDepth + "'," +
                "TubeMat            ='" + entWell.TubeMat + "'," +
                "TubeIR             ='" + entWell.TubeIR + "'," +
                "StanWaterDepth     ='" + entWell.StanWaterDepth + "'," +
                "SaltWaterFloorDepth='" + entWell.SaltWaterFloorDepth + "'," +
                "FilterLocLow       ='" + entWell.FilterLocLow + "'," +
                "FilterLocHigh      ='" + entWell.FilterLocHigh + "'," +
                "StillWaterLoc      ='" + entWell.StillWaterLoc + "'," +
                "PumpModel          ='" + entWell.PumpModel + "'," +
                "PumpPower          ='" + entWell.PumpPower + "'," +
                "IsMfInstall        ='" + entWell.IsMfInstall + "'," +
                "IsWaterLevelOp     ='" + entWell.IsWaterLevelOp + "'," +
                "Remark             ='" + entWell.Remark + "'," +
                "where Id = '" + entWell.Id + "'" +
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
        /// 根据filter获取符合条件的企业井
        /// </summary>
        /// <param name="filter">where(filter)</param>
        /// <returns></returns>
        public static List<STR_EntWell> GetEntWellByFilter(string filter)
        {
            List<STR_EntWell> res = new List<STR_EntWell>();
            try
            {
                MySqlDataReader reader;
                if (filter == "")
                    reader = DbOper.Query("select * from grims.entwell;");
                else
                    reader = DbOper.Query("select * from grims.entwell where (" + filter + ");");

                while (reader.Read())
                {
                    STR_EntWell entWell = new STR_EntWell();
                    entWell.Id = reader.GetInt32("Id");
                    entWell.TsOrSt = reader.GetString("TsOrSt ");
                    entWell.EntName = reader.GetString("Village");
                    entWell.UnitCat = reader.GetString("UnitCat");
                    entWell.Loc = reader.GetString("Loc");
                    entWell.Lng = reader.GetDouble("Lng");
                    entWell.Lat = reader.GetDouble("Lat");
                    entWell.Usefor = reader.GetString("Usefor ");
                    entWell.IfRecordDigTime = reader.GetBoolean("IfRecordDigTime");
                    entWell.DigTime = new DateTime() + reader.GetTimeSpan("DigTime");
                    entWell.WaterIntakingNo = reader.GetString("WaterIntakingNo");
                    entWell.WellDepth = reader.GetInt32("WellDepth");
                    entWell.TubeMat = reader.GetString("TubeMat");
                    entWell.TubeIR = reader.GetInt32("TubeIR ");
                    entWell.StanWaterDepth = reader.GetInt32("StanWaterDepth ");
                    entWell.SaltWaterFloorDepth = reader.GetInt32("SaltWaterFloorDepth");
                    entWell.FilterLocLow = reader.GetInt32("FilterLocLow ");
                    entWell.FilterLocHigh = reader.GetInt32("FilterLocHigh");
                    entWell.StillWaterLoc = reader.GetInt32("StillWaterLoc");
                    entWell.PumpModel = reader.GetString("PumpModel");
                    entWell.PumpPower = reader.GetFloat("PumpPower");
                    entWell.IsMfInstall = reader.GetBoolean("IsMfInstall");
                    entWell.IsWaterLevelOp = reader.GetBoolean("IsWaterLevelOp");
                    entWell.Remark = reader.GetString("Remark ");
                    res.Add(entWell);
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
