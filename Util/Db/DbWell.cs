using Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Util
{
    public class C_DbTabWell
    {
        public static void InitTabs()
        {
            C_Db.Exec("create table if not exists grims.well( " +
                        "id int auto_increment,                 " +          //0
                        "tsOrSt varchar(255),                   " +          //1
                        "village varchar(255),                  " +          //2
                        "unitCat varchar(255),                  " +          //3
                        "loc varchar(255),                      " +          //4
                        "lng varchar(255),                            " +      //5
                        "lat varchar(255),                            " +      //6
                        "usefor varchar(255),                   " +             //7
                        "digTime date,                  " +                    //8
                        "wellDepth float,                     " +              //9
                        "tubeMat varchar(255),          " +                    //10
                        "tubeIr float,                         " +             //11
                        "stanWaterDepth float,                  " +            //12
                        "saltWaterFloorDepth float,            " +             //13
                        "filterLocLow float,                    " +            //14
                        "filterLocHigh float,               " +                //15
                        "stillWaterLoc float,                      " +         //16

                        "pumpMode varchar(255),                     " +          //17
                        "pumpPower float,                     " +          //18
                        "coverArea float,                " +          //19
                        "supPeopleNum int,                       " +          //20
                        "isWaterLevelOp bool,                       " +          //21
                        "isMfInstalled bool,                       " +          //22
                        "linkWellNo int,                      " +          //23
                        "isSeepChnLinked bool,                   " +          //24
                        "seepChnLength float,                 " +          //25
                        "remark varchar(255),                " +          //26
                        "primary key(Id)                        " +
                        ")default charset = utf8mb4; ");
        }

        public static Tuple<E_DbRState, Exception> Add(List<C_Well> wells)
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
            for (int i = 0; i < wells.Count; ++i)
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

            return C_Db.Exec(cmd);
        }

        public static Tuple<E_DbRState, Exception> Delete(C_Well well)
        {
            return C_Db.Exec("delete from grims.well where Id='" + well.Id.ToString() + "';");
        }

        public static Tuple<E_DbRState, Exception> Change(C_Well well)
        {
            return C_Db.Exec("  update grims.well set " +
                                "TsOrSt             ='" + well.TsOrSt + "'," +
                                "Village            ='" + well.Village + "'," +
                                "UnitCat            ='" + well.UnitCat + "'," +
                                "Loc                ='" + well.Loc + "'," +
                                "Lng                ='" + well.Lng + "'," +
                                "Lat                ='" + well.Lat + "'," +
                                "Usefor             ='" + well.Usefor + "'," +
                                "DigTime            ='" + well.DigTime.ToString("yyyy-MM-dd") + "'," +
                                "WellDepth          =" + well.WellDepth + "," +
                                "TubeMat            ='" + well.TubeMat + "'," +
                                "TubeIr             =" + well.TubeIr + "," +
                                "StanWaterDepth     =" + well.StanWaterDepth + "," +
                                "SaltWaterFloorDepth=" + well.SaltWaterFloorDepth + "," +
                                "FilterLocLow       =" + well.FilterLocLow + "," +
                                "FilterLocHigh      =" + well.FilterLocHigh + "," +
                                "StillWaterLoc      =" + well.StillWaterLoc + "," +
                                "PumpMode           ='" + well.PumpMode + "'," +
                                "PumpPower          =" + well.PumpPower + "," +
                                "CoverArea          =" + well.CoverArea + "," +
                                "SupPeopleNum       =" + well.SupPeopleNum + "," +
                                "IsWaterLevelOp     =" + well.IsWaterLevelOp + "," +
                                "IsMfInstalled      =" + well.IsMfInstalled + "," +
                                "LinkWellNo         =" + well.LinkWellNo + "," +
                                "IsSeepChnLinked    =" + well.IsSeepChnLinked + "," +
                                "SeepChnLength      =" + well.SeepChnLength + "," +
                                "Remark             ='" + well.Remark + "'" +
                                " where Id = " + well.Id + "" +
                                ";"
                            );
        }

        public static Tuple<E_DbRState, List<C_Well>, Exception> Get(string filter)
        {
            List<C_Well> res = new List<C_Well>();
            Tuple<E_DbRState, MySqlDataReader, Exception> QRes;
            if (filter == null || filter == "")
            {
                QRes = C_Db.Query("select * from grims.well;");
            }
            else
            {
                QRes = C_Db.Query("select * from grims.well where (" +
                        "TsOrSt                   LIKE '%" + filter + "%' OR " +
                        "Village                  LIKE '%" + filter + "%' OR " +
                        "UnitCat                  LIKE '%" + filter + "%' OR " +
                        "Loc                      LIKE '%" + filter + "%' OR " +
                        "Lng                      LIKE '%" + filter + "%' OR " +
                        "Lat                      LIKE '%" + filter + "%' OR " +
                        "Usefor                   LIKE '%" + filter + "%' OR " +
                        "DigTime                  LIKE '%" + filter + "%' OR " +
                        "WellDepth                LIKE '%" + filter + "%' OR " +
                        "TubeMat                  LIKE '%" + filter + "%' OR " +
                        "TubeIr                   LIKE '%" + filter + "%' OR " +
                        "StanWaterDepth           LIKE '%" + filter + "%' OR " +
                        "SaltWaterFloorDepth      LIKE '%" + filter + "%' OR " +
                        "FilterLocLow             LIKE '%" + filter + "%' OR " +
                        "FilterLocHigh            LIKE '%" + filter + "%' OR " +
                        "StillWaterLoc            LIKE '%" + filter + "%' OR " +
                        "PumpMode                 LIKE '%" + filter + "%' OR " +
                        "PumpPower                LIKE '%" + filter + "%' OR " +
                        "CoverArea                LIKE '%" + filter + "%' OR " +
                        "SupPeopleNum             LIKE '%" + filter + "%' OR " +
                        "IsWaterLevelOp           LIKE '%" + filter + "%' OR " +
                        "IsMfInstalled            LIKE '%" + filter + "%' OR " +
                        "LinkWellNo               LIKE '%" + filter + "%' OR " +
                        "IsSeepChnLinked          LIKE '%" + filter + "%' OR " +
                        "SeepChnLength            LIKE '%" + filter + "%' OR " +
                        "Remark                   LIKE '%" + filter + "%' " +
                        ");");
            }
            while (QRes.Item2.Read())
            {
                C_Well well = new C_Well();
                well.Id = QRes.Item2.GetInt32("Id");
                well.TsOrSt = QRes.Item2.GetString("TsOrSt");
                well.Village = QRes.Item2.GetString("Village");
                well.UnitCat = QRes.Item2.GetString("UnitCat");
                well.Loc = QRes.Item2.GetString("Loc");
                well.Lng = QRes.Item2.GetString("Lng");//5
                well.Lat = QRes.Item2.GetString("Lat");
                well.Usefor = QRes.Item2.GetString("Usefor");
                well.DigTime = QRes.Item2.GetDateTime("DigTime");
                well.WellDepth = QRes.Item2.GetFloat("WellDepth");
                well.TubeMat = QRes.Item2.GetString("TubeMat");//10
                well.TubeIr = QRes.Item2.GetFloat("TubeIr");
                well.StanWaterDepth = QRes.Item2.GetFloat("StanWaterDepth");
                well.SaltWaterFloorDepth = QRes.Item2.GetFloat("SaltWaterFloorDepth");
                well.FilterLocLow = QRes.Item2.GetFloat("FilterLocLow");
                well.FilterLocHigh = QRes.Item2.GetFloat("FilterLocHigh");
                well.StillWaterLoc = QRes.Item2.GetFloat("StillWaterLoc");
                well.PumpMode = QRes.Item2.GetString("PumpMode");
                well.PumpPower = QRes.Item2.GetFloat("PumpPower");
                well.CoverArea = QRes.Item2.GetFloat("CoverArea");
                well.SupPeopleNum = QRes.Item2.GetInt32("SupPeopleNum");
                well.IsWaterLevelOp = QRes.Item2.GetBoolean("IsWaterLevelOp");
                well.IsMfInstalled = QRes.Item2.GetBoolean("IsMfInstalled");
                well.LinkWellNo = QRes.Item2.GetInt32("LinkWellNo");
                well.IsSeepChnLinked = QRes.Item2.GetBoolean("IsSeepChnLinked");
                well.SeepChnLength = QRes.Item2.GetFloat("SeepChnLength");
                well.Remark = QRes.Item2.GetString("Remark");
                res.Add(well);
            }
            return new Tuple<E_DbRState, List<C_Well>, Exception>(E_DbRState.Changed, res, null);
        }
    }

    public class C_DbTabWellPara
    {
        public static void InitTabs()
        {
            C_Db.Exec("create table if not exists grims.wellpara(paraType varchar(255),paraValue varchar(255) unique)default charset = utf8mb4;");
        }

        public static Tuple<E_DbRState, Exception> Add(C_WellPara wellPara)
        {
            return C_Db.Exec("insert into grims.wellpara (paraType,paraValue) values('"+ wellPara.Type + "','" + wellPara.Value + "');");
        }

        public static Tuple<E_DbRState, Exception> Delete(C_WellPara wellPara)
        {
            return C_Db.Exec("delete from grims.wellpara where paraType='" + wellPara.Type + "' and paraValue='" + wellPara.Value + "';");
        }

        public static Tuple<E_DbRState, Exception> Change(C_WellPara oldWp, C_WellPara newWp)
        {
            return C_Db.Exec("update grims.wellpara set paraType='" + newWp.Type + "' , paraValue='" + newWp.Value + "' where paraType='" + oldWp.Type + "' and paraValue='" + oldWp.Value + "';");
        }

        public static Tuple<E_DbRState, C_WellParas, Exception> Get()
        {
            Tuple<E_DbRState, MySqlDataReader, Exception> QRes;
            List<C_WellPara> res = new List<C_WellPara>();
            QRes = C_Db.Query("select * from grims.wellpara;");

            if (QRes.Item1 == E_DbRState.Success)
            {
                while (QRes.Item2.Read())
                {
                    C_WellPara tmp = new C_WellPara();
                    tmp.Type = (E_WellParaType)Enum.Parse(typeof(E_WellParaType), QRes.Item2.GetString("paraType"), true);
                    tmp.Value = QRes.Item2.GetString("paraValue");
                    res.Add(tmp);
                }
                C_WellParas wps = new C_WellParas(res);
                return new Tuple<E_DbRState, C_WellParas, Exception>(QRes.Item1, wps, QRes.Item3);
            }
            else
            {
                return new Tuple<E_DbRState, C_WellParas, Exception>(QRes.Item1, null, QRes.Item3);
            }
        }
    }

}
