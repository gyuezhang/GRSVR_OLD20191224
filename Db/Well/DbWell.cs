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
                        "Id int auto_increment,                 "   +          //0
                        "TsOrSt varchar(255),                   "   +          //1
                        "Village varchar(255),                  "   +          //2
                        "UnitCat varchar(255),                  "   +          //3
                        "Loc varchar(255),                      "   +          //4
                        "Lng varchar(255),                            " +      //5
                        "Lat varchar(255),                            " +      //6
                        "Usefor varchar(255),                   " +             //7
                        "DigTime date,                  " +                    //8
                        "WellDepth float,                     " +              //9
                        "TubeMat varchar(255),          " +                    //10
                        "TubeIr float,                         " +             //11
                        "StanWaterDepth float,                  " +            //12
                        "SaltWaterFloorDepth float,            " +             //13
                        "FilterLocLow float,                    " +            //14
                        "FilterLocHigh float,               " +                //15
                        "StillWaterLoc float,                      " +         //16

                        "PumpMode varchar(255),                     " +          //17
                        "PumpPower int,                     " +          //18
                        "CoverArea varchar(255),                " +          //19
                        "SupPeopleNum float,                       " +          //20
                        "IsWaterLevelOp float,                       " +          //21
                        "IsMfInstalled int,                       " +          //22
                        "LinkWellNo bool,                      " +          //23
                        "IsSeepChnLinked bool,                   " +          //24
                        "SeepChnLength bool,                 " +          //25
                        "Remark varchar(255),                " +          //26
                        "primary key(Id)                        "   +          
                        ")default charset = utf8; ");
        }

        /// <summary>
        /// 创建机井
        /// </summary>
        /// <param name="user">机井结构体</param>
        public static bool CreateWell(List<Well> wells)
        {
            try
            {
                string cmd = "insert into grims.well (   TsOrSt," +//1
                                                        "Village," +//2
                                                        "UnitCat," +//3
                                                        "Loc," +//4
                                                        "Lng," +//5
                                                        "Lat," +//6
                                                        "Usefor," +//7
                                                        "DigTime," +//8
                                                        "WellDepth," +//9
                                                        "TubeMat," +//10
                                                        "TubeIr," +//11
                                                        "StanWaterDepth," +//12
                                                        "SaltWaterFloorDepth," +//13
                                                        "FilterLocLow," +//14
                                                        "FilterLocHigh," +//15
                                                        "StillWaterLoc," +//16
                                                        "PumpMode," +//17
                                                        "PumpPower," +//18
                                                        "CoverArea," +//19
                                                        "SupPeopleNum," +//20
                                                        "IsWaterLevelOp," +//21
                                                        "IsMfInstalled," +//22
                                                        "LinkWellNo," +//23
                                                        "IsSeepChnLinked," +//24
                                                        "SeepChnLength," +//25
                                                        "Remark" +//26
                                                        ")values";
                string tmp;
                for(int i=0; i<wells.Count;++i)
                {
                    tmp = "('" +
                    wells[i].TsOrSt + "','" +    //1
                    wells[i].Village + "','" +   //2
                    wells[i].UnitCat + "','" +   //3
                    wells[i].Loc + "','" +   //4
                    wells[i].Lng + "','" +   //5
                    wells[i].Lat + "','" +   //6
                    wells[i].Usefor + "','" +   //7
                    wells[i].DigTime.ToString("yyyy-MM-dd") + "'," +   //8
                    wells[i].WellDepth + ",'" +   //9
                    wells[i].TubeMat + "'," +   //10
                    wells[i].TubeIr + "," +   //11
                    wells[i].StanWaterDepth + "," +   //12
                    wells[i].SaltWaterFloorDepth + "," +   //13
                    wells[i].FilterLocLow + "," +   //14
                    wells[i].FilterLocHigh + "," +   //15
                    wells[i].StillWaterLoc + ",'" +   //16
                    wells[i].PumpMode + "'," +   //17
                    wells[i].PumpPower + "," +   //18
                    wells[i].CoverArea + "," +   //19
                    wells[i].SupPeopleNum + "," +   //20
                    wells[i].IsWaterLevelOp + "," +   //21
                    wells[i].IsMfInstalled + "," +   //22
                    wells[i].LinkWellNo + "," +   //23
                    wells[i].IsSeepChnLinked + "," +   //24
                    wells[i].SeepChnLength + ",'" +   //25
                    wells[i].Remark +         //26
                    "')";
                    if (i == wells.Count - 1)
                        tmp += ";";
                    else
                        tmp += ",";
                    cmd += tmp;
                }
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
                string cmd = "  update grims.well set " +
                                "TsOrSt             =" + well.TsOrSt              + "," +
                                "Village            =" + well.Village             + "," +
                                "UnitCat            =" + well.UnitCat             + "," +
                                "Loc                =" + well.Loc                 + "," +
                                "Lng                =" + well.Lng                 + "," +
                                "Lat                =" + well.Lat                 + "," +
                                "Usefor             =" + well.Usefor              + "," +
                                "IfRecordDigTime    =" + well.IfRecordDigTime     + "," +
                                "DigTime            =" + well.DigTime             + "," +
                                "WaterIntakingNo    =" + well.WaterIntakingNo     + "," +
                                "WellDepth          =" + well.WellDepth           + "," +
                                "TubeMat            =" + well.TubeMat             + "," +
                                "TubeIR             =" + well.TubeIR              + "," +
                                "StanWaterDepth     =" + well.StanWaterDepth      + "," +
                                "SaltWaterFloorDepth=" + well.SaltWaterFloorDepth + "," +
                                "FilterLocLow       =" + well.FilterLocLow        + "," +
                                "FilterLocHigh      =" + well.FilterLocHigh       + "," +
                                "StillWaterLoc      =" + well.StillWaterLoc       + "," +
                                "PumpModel          =" + well.PumpModel           + "," +
                                "PumpPower          =" + well.PumpPower           + "," +
                                "CoverArea          =" + well.CoverArea           + "," +
                                "SupPeopleNo        =" + well.SupPeopleNo         + "," +
                                "IsMfInstall        =" + well.IsMfInstall         + "," +
                                "IsWaterLevelOp     =" + well.IsWaterLevelOp      + "," +
                                "IsConnSeepageChn   =" + well.IsConnSeepageChn    + "," +
                                "SeepageChnLength   =" + well.SeepageChnLength    + "," +
                                "LinkWellNo         =" + well.LinkWellNo          + "," +
                                "Remark             =" + well.Remark + "" +
                                " where Id = " + well.Id +"" + 
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
                if (filter == "x")
                    reader = DbOper.Query("select * from grims.well;");
                else
                    reader = DbOper.Query("select * from grims.well where (" + filter + ");");
                while (reader.Read())
                {
                    STR_Well well = new STR_Well();
                    well.Id = reader.GetInt32("Id");
                    well.TsOrSt = reader.GetString("TsOrSt");
                    well.Village = reader.GetString("Village");
                    well.UnitCat = reader.GetString("UnitCat");
                    well.Loc = reader.GetString("Loc");
                    well.Lng = reader.GetDouble("Lng");
                    well.Lat = reader.GetDouble("Lat");
                    well.Usefor = reader.GetString("Usefor");
                    well.IfRecordDigTime = reader.GetBoolean("IfRecordDigTime");
                    well.DigTime = reader.GetInt32("DigTime");
                    well.WaterIntakingNo = reader.GetString("WaterIntakingNo");
                    well.WellDepth = reader.GetInt32("WellDepth");
                    well.TubeMat = reader.GetString("TubeMat");
                    well.TubeIR = reader.GetInt32("TubeIR");
                    well.StanWaterDepth = reader.GetInt32("StanWaterDepth");
                    well.SaltWaterFloorDepth = reader.GetInt32("SaltWaterFloorDepth");
                    well.FilterLocLow = reader.GetInt32("FilterLocLow");
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
                    well.Remark = reader.GetString("Remark");
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
