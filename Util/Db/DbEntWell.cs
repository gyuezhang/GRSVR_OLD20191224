using Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Util
{
    public class C_DbTabEntWell
    {
        public static void InitTabs()
        {
            C_Db.Exec("create table if not exists grims.entwell( " +
                        "id int auto_increment,                 " +             //0
                        "tsOrSt varchar(255),                   " +             //1
                        "entName varchar(255),                  " +             //2
                        "unitCat varchar(255),                  " +             //3
                        "loc varchar(255),                      " +             //4
                        "lng varchar(255),                            " +       //5
                        "lat varchar(255),                            " +       //6
                        "usefor varchar(255),                   " +             //7
                        "digTime date,                  " +                     //8
                        "fetchWaterId varchar(255),         " +                 //9
                        "isPaid bool,         " +                               //10
                        "wellDepth float,                     " +               //11
                        "tubeMat varchar(255),          " +                     //12
                        "tubeIr float,                         " +              //13
                        "stanWaterDepth float,                  " +             //14
                        "saltWaterFloorDepth float,            " +              //15
                        "filterLocLow float,                    " +             //16
                        "filterLocHigh float,               " +                 //17
                        "stillWaterLoc float,                      " +          //18
                        "pumpMode varchar(255),                     " +         //19
                        "pumpPower float,                     " +               //20
                        "isWaterLevelOp bool,                       " +         //21
                        "isMfInstalled bool,                       " +          //22
                        "remark varchar(255),                " +                //23
                        "primary key(Id)                        " +
                        ")default charset = utf8mb4; ");
        }

        public static Tuple<E_DbRState, Exception> Add(List<C_EntWell> wells)
        {

            string cmd = "insert into grims.entwell (   TsOrSt," +//1
                                                        "EntName," +//2
                                                        "UnitCat," +//3
                                                        "Loc," +//4
                                                        "Lng," +//5
                                                        "Lat," +//6
                                                        "Usefor," +//7
                                                        "DigTime," +//8


                                                        "FetchWaterId," +//9
                                                        "IsPaid," +//10

                                                        "WellDepth," +//11
                                                        "TubeMat," +//12
                                                        "TubeIr," +//13
                                                        "StanWaterDepth," +//14
                                                        "SaltWaterFloorDepth," +//15
                                                        "FilterLocLow," +//16
                                                        "FilterLocHigh," +//17
                                                        "StillWaterLoc," +//18
                                                        "PumpMode," +//19
                                                        "PumpPower," +//20
                                                        "IsWaterLevelOp," +//21
                                                        "IsMfInstalled," +//22
                                                        "Remark" +//23
                                                        ")values";
            string tmp;
            for (int i = 0; i < wells.Count; ++i)
            {
                tmp = "('" +
                wells[i].TsOrSt + "','" +    //1
                wells[i].EntName + "','" +   //2
                wells[i].UnitCat + "','" +   //3
                wells[i].Loc + "','" +   //4
                wells[i].Lng + "','" +   //5
                wells[i].Lat + "','" +   //6
                wells[i].Usefor + "','" +   //7
                wells[i].DigTime.ToString("yyyy-MM-dd") + "','" +   //8

                wells[i].FetchWaterId + "'," +   //9
                wells[i].IsPaid + "," +   //10

                wells[i].WellDepth + ",'" +   //11
                wells[i].TubeMat + "'," +   //12
                wells[i].TubeIr + "," +   //13
                wells[i].StanWaterDepth + "," +   //14
                wells[i].SaltWaterFloorDepth + "," +   //15
                wells[i].FilterLocLow + "," +   //16
                wells[i].FilterLocHigh + "," +   //17
                wells[i].StillWaterLoc + ",'" +   //18
                wells[i].PumpMode + "'," +   //19
                wells[i].PumpPower + "," +   //20
                wells[i].IsWaterLevelOp + "," +   //21
                wells[i].IsMfInstalled + ",'" +   //22
                wells[i].Remark +         //23
                "')";
                if (i == wells.Count - 1)
                    tmp += ";";
                else
                    tmp += ",";
                cmd += tmp;
            }

            return C_Db.Exec(cmd);
        }

        public static Tuple<E_DbRState, Exception> Delete(C_EntWell well)
        {
            return C_Db.Exec("delete from grims.entwell where Id='" + well.Id.ToString() + "';");
        }

        public static Tuple<E_DbRState, Exception> Change(C_EntWell well)
        {
            return C_Db.Exec("update grims.entwell set TsOrSt='" + well.TsOrSt + 
                                                     "', EntName='" + well.EntName +
                                                     "', UnitCat='" + well.UnitCat +
                                                     "', Loc='" + well.Loc +
                                                     "', Lng='" + well.Lng +
                                                     "', Lat='" + well.Lat +
                                                     "', Usefor='" + well.Usefor +
                                                     "', DigTime='" + well.DigTime.ToString("yyyy-MM-dd") +
                                                     "', FetchWaterId='" + well.FetchWaterId +
                                                     "', IsPaid=" + well.IsPaid +
                                                     ", WellDepth=" + well.WellDepth +
                                                     ", TubeMat='" + well.TubeMat +
                                                     "', TubeIr=" + well.TubeIr +
                                                     ", StanWaterDepth=" + well.StanWaterDepth +
                                                     ", SaltWaterFloorDepth=" + well.SaltWaterFloorDepth +
                                                     ", FilterLocLow=" + well.FilterLocLow +
                                                     ", FilterLocHigh=" + well.FilterLocHigh +
                                                     ", StillWaterLoc=" + well.StillWaterLoc +
                                                     ", PumpMode='" + well.PumpMode +
                                                     "', PumpPower=" + well.PumpPower +
                                                     ", IsWaterLevelOp=" + well.IsWaterLevelOp +
                                                     ", IsMfInstalled=" + well.IsMfInstalled +
                                                     ", Remark='" + well.Remark +
                                                     "' where Id = '" + well.Id + "';"
                            );

        }

        public static Tuple<E_DbRState, List<C_EntWell>, Exception> Get(string filter)
        {
            List<C_EntWell> res = new List<C_EntWell>();
            Tuple<E_DbRState, MySqlDataReader, Exception> QRes;
            if(filter == null ||filter == "")
            {
                QRes = C_Db.Query("select * from grims.entwell;");
            }
            else
            {
                QRes = C_Db.Query("select * from grims.entwell where (" +
                        "TsOrSt                   LIKE '%" + filter + "%' OR " +//1
                        "EntName                  LIKE '%" + filter + "%' OR " +//2
                        "UnitCat                  LIKE '%" + filter + "%' OR " +//3
                        "Loc                      LIKE '%" + filter + "%' OR " +//4
                        "Lng                      LIKE '%" + filter + "%' OR " +//5
                        "Lat                      LIKE '%" + filter + "%' OR " +//6
                        "Usefor                   LIKE '%" + filter + "%' OR " +//7
                        "DigTime                  LIKE '%" + filter + "%' OR " +//8
                                                                                
                        "FetchWaterId             LIKE '%" + filter + "%' OR " +//9
                        "IsPaid                   LIKE '%" + filter + "%' OR " +//10
                                                                                
                        "WellDepth                LIKE '%" + filter + "%' OR " +//11
                        "TubeMat                  LIKE '%" + filter + "%' OR " +//12
                        "TubeIr                   LIKE '%" + filter + "%' OR " +//13
                        "StanWaterDepth           LIKE '%" + filter + "%' OR " +//14
                        "SaltWaterFloorDepth      LIKE '%" + filter + "%' OR " +//15
                        "FilterLocLow             LIKE '%" + filter + "%' OR " +//16
                        "FilterLocHigh            LIKE '%" + filter + "%' OR " +//17
                        "StillWaterLoc            LIKE '%" + filter + "%' OR " +//18
                        "PumpMode                 LIKE '%" + filter + "%' OR " +//19
                        "PumpPower                LIKE '%" + filter + "%' OR " +//20
                        "IsWaterLevelOp           LIKE '%" + filter + "%' OR " +//21
                        "IsMfInstalled            LIKE '%" + filter + "%' OR " +//22
                        "Remark                   LIKE '%" + filter + "%' " +
                        ");");
            }
            while (QRes.Item2.Read())
            {
                C_EntWell well = new C_EntWell();
                well.Id = QRes.Item2.GetInt32("Id");
                well.TsOrSt = QRes.Item2.GetString("TsOrSt");
                well.EntName = QRes.Item2.GetString("EntName");
                well.UnitCat = QRes.Item2.GetString("UnitCat");
                well.Loc = QRes.Item2.GetString("Loc");
                well.Lng = QRes.Item2.GetString("Lng");//5
                well.Lat = QRes.Item2.GetString("Lat");
                well.Usefor = QRes.Item2.GetString("Usefor");
                well.DigTime = QRes.Item2.GetDateTime("DigTime");

                well.FetchWaterId = QRes.Item2.GetString("FetchWaterId");
                well.IsPaid = QRes.Item2.GetBoolean("IsPaid");

                well.WellDepth = QRes.Item2.GetFloat("WellDepth");//11
                well.TubeMat = QRes.Item2.GetString("TubeMat");//12
                well.TubeIr = QRes.Item2.GetFloat("TubeIr");
                well.StanWaterDepth = QRes.Item2.GetFloat("StanWaterDepth");
                well.SaltWaterFloorDepth = QRes.Item2.GetFloat("SaltWaterFloorDepth");
                well.FilterLocLow = QRes.Item2.GetFloat("FilterLocLow");//16
                well.FilterLocHigh = QRes.Item2.GetFloat("FilterLocHigh");
                well.StillWaterLoc = QRes.Item2.GetFloat("StillWaterLoc");
                well.PumpMode = QRes.Item2.GetString("PumpMode");
                well.PumpPower = QRes.Item2.GetFloat("PumpPower");//20
                well.IsWaterLevelOp = QRes.Item2.GetBoolean("IsWaterLevelOp");
                well.IsMfInstalled = QRes.Item2.GetBoolean("IsMfInstalled");
                well.Remark = QRes.Item2.GetString("Remark");
                res.Add(well);
            }
            return new Tuple<E_DbRState, List<C_EntWell>, Exception>(E_DbRState.Changed, res,null);
        }
    }

    public class C_DbTabEntWellPara
    {
        public static void InitTabs()
        {
            C_Db.Exec("create table if not exists grims.entwellpara(paraType varchar(255),paraValue varchar(255) unique)default charset = utf8mb4;");
        }

        public static Tuple<E_DbRState, Exception> Add(C_WellPara wellPara)
        {
            return C_Db.Exec("insert into grims.entwellpara (paraType,paraValue) values('" + wellPara.Type + "','" + wellPara.Value + "');");
        }

        public static Tuple<E_DbRState, Exception> Delete(C_WellPara wellPara)
        {
            return C_Db.Exec("delete from grims.entwellpara where paraType='"+ wellPara.Type + "' and paraValue='" + wellPara.Value + "';");
        }
                   // return C_Db.Exec("update grims.dept set deptName='" + newDeptName + "' where deptName='" + oldDeptName + "';");

        public static Tuple<E_DbRState, Exception> Change(C_WellPara oldWp, C_WellPara newWp)
        {
            return C_Db.Exec("update grims.entwellpara set paraType='" + newWp.Type + "' , paraValue='" + newWp.Value + "' where paraType='" + oldWp.Type + "' and paraValue='" + oldWp.Value + "';");
        }

        public static Tuple<E_DbRState, C_WellParas, Exception> Get()
        {
            Tuple<E_DbRState, MySqlDataReader, Exception> QRes;
            List<C_WellPara> res = new List<C_WellPara>();
            QRes = C_Db.Query("select * from grims.entwellpara;");

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
