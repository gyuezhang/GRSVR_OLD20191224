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
    }
}
