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

        public static Tuple<E_DbRState, List<C_EntWell>, Exception> Get()
        {
            return new Tuple<E_DbRState, List<C_EntWell>, Exception>(E_DbRState.Changed, null, null);
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
