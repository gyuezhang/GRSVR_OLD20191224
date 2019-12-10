using Model;
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
            return C_Db.Exec("insert into grims.wellpara (code, name, level, pcode) values');");
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
