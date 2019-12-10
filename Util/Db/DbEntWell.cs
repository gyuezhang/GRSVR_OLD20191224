using Model;
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
            return C_Db.Exec("insert into grims.areacode (code, name, level, pcode) values;");
        }

        public static Tuple<E_DbRState, Exception> Delete(C_EntWell well)
        {
            return C_Db.Exec("insert into grims.areacode (code, name, level, pcode) values;");
        }

        public static Tuple<E_DbRState, Exception> Change(C_EntWell well)
        {
            return C_Db.Exec("insert into grims.areacode (code, name, level, pcode) values;");
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
            return C_Db.Exec("insert into grims.areacode (code, name, level, pcode) values');");
        }

        public static Tuple<E_DbRState, Exception> Delete(C_WellPara wellPara)
        {
            return C_Db.Exec("insert into grims.areacode (code, name, level, pcode) values');");
        }

        public static Tuple<E_DbRState, List<C_WellPara>, Exception> Get()
        {
            return new Tuple<E_DbRState, List<C_WellPara>, Exception>(E_DbRState.Changed, null, null);
        }
    }
}
