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
            return C_Db.Exec("insert into grims.areacode (code, name, level, pcode) values;");
        }

        public static Tuple<E_DbRState, Exception> Delete(C_Well well)
        {
            return C_Db.Exec("insert into grims.areacode (code, name, level, pcode) values;");
        }

        public static Tuple<E_DbRState, Exception> Change(C_Well well)
        {
            return C_Db.Exec("insert into grims.areacode (code, name, level, pcode) values;");
        }

        public static Tuple<E_DbRState, List<C_Well>, Exception> Get()
        {
            return new Tuple<E_DbRState, List<C_Well>, Exception>(E_DbRState.Changed, null, null);
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
