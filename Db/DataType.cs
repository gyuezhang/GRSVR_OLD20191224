﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db
{
    /// <summary>
    /// 用户信息结构体
    /// </summary>
    public struct STR_User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pwd { get; set; }
        public int DeptId { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
    }

    /// <summary>
    /// 机井结构体
    /// </summary>
    public struct STR_Well
    {
        /// <summary>
        /// 井Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 所属乡镇（街道）
        /// </summary>
        public string TsOrSt { get; set; }
        
        /// <summary>
        /// 所属村
        /// </summary>
        public string Village { get; set; }
        
        /// <summary>
        /// 权属单位
        /// </summary>
        public string UnitCat { get; set; }
        
        /// <summary>
        /// 位置
        /// </summary>
        public string Loc { get; set; }
        
        /// <summary>
        /// 东经
        /// </summary>
        public double Lng { get; set; }
        
        /// <summary>
        /// 北纬
        /// </summary>
        public double Lat { get; set; }
        
        /// <summary>
        /// 用途
        /// </summary>
        public string Usefor { get; set; }

        /// <summary>
        /// 是否记录了成井时间
        /// </summary>
        public bool IfRecordDigTime { get; set; }

        /// <summary>
        /// 成井时间
        /// </summary>
        public int DigTime { get; set; }
        
        /// <summary>
        /// 取水证号
        /// </summary>
        public string WaterIntakingNo { get; set; }
        
        /// <summary>
        /// 井深（米）
        /// </summary>
        public int WellDepth { get; set; }

        /// <summary>
        /// 管材
        /// </summary>
        public string TubeMat { get; set; }

        /// <summary>
        /// 井管内径（毫米）
        /// </summary>
        public int TubeIR { get; set; }

        /// <summary>
        /// 止水深度（米）
        /// </summary>
        public int StanWaterDepth { get; set; }

        /// <summary>
        /// 咸水底板深度（米）
        /// </summary>
        public int SaltWaterFloorDepth { get; set; }

        /// <summary>
        /// 过滤器位置(低位)（米）
        /// </summary>
        public int FilterLocLow { get; set; }

        /// <summary>
        /// 过滤器位置(高位)（米）
        /// </summary>
        public int FilterLocHigh { get; set; }

        /// <summary>
        /// 静水位（米）
        /// </summary>
        public int StillWaterLoc { get; set; }

        /// <summary>
        /// 水泵型号
        /// </summary>
        public string PumpModel { get; set; }

        /// <summary>
        /// 水泵动力（千瓦）
        /// </summary>
        public float PumpPower { get; set; }

        /// <summary>
        /// 井控面积（亩）
        /// </summary>
        public float CoverArea { get; set; }

        /// <summary>
        /// 供水人口（人）
        /// </summary>
        public int SupPeopleNo { get; set; }

        /// <summary>
        /// 是否安装计量设施
        /// </summary>
        public bool IsMfInstall { get; set; }

        /// <summary>
        /// 是否为水位观测点
        /// </summary>
        public bool IsWaterLevelOp { get; set; }

        /// <summary>
        /// 是否连接防渗渠道
        /// </summary>
        public bool IsConnSeepageChn { get; set; }

        /// <summary>
        /// 防渗渠道长度（km）
        /// </summary>
        public float SeepageChnLength { get; set; }

        /// <summary>
        /// 连接机井眼数
        /// </summary>
        public int LinkWellNo { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        //public STR_Well(int id,string tsOrSt, string village, string unitCat,
        //                        string loc, double lng, double lat,
        //                        string usefor, bool ifRecordDigTime,DateTime digTime, string waterIntakingNo,
        //                        int wellDepth, string tubeMat, int tubeIR,
        //                        int stanWaterDepth, int saltWaterFloorDepth, int filterLocLow,
        //                        int filterLocHigh, int stillWaterLoc, string pumpModel, float pumpPower,
        //                        float coverArea, int supPeopleNo, bool isWaterLevelOp,
        //                        bool isMfInstall, bool isConnSeepageChn, float seepageChnLength,
        //                        int linkWellNo, string remark)
        //{
        //    Id = id;
        //    TsOrSt = tsOrSt;
        //    Village = village;
        //    UnitCat = unitCat;
        //    Loc = loc;
        //    Lng = lng;
        //    Lat = lat;
        //    Usefor = usefor;
        //    IfRecordDigTime = ifRecordDigTime;
        //    DigTime = digTime;
        //    WaterIntakingNo = waterIntakingNo;
        //    WellDepth = wellDepth;
        //    TubeMat = tubeMat;
        //    TubeIR = tubeIR;
        //    StanWaterDepth = stanWaterDepth;
        //    SaltWaterFloorDepth = saltWaterFloorDepth;
        //    FilterLocLow = filterLocLow;
        //    FilterLocHigh = filterLocHigh;
        //    StillWaterLoc = stillWaterLoc;
        //    PumpModel = pumpModel;
        //    PumpPower = pumpPower;
        //    CoverArea = coverArea;
        //    SupPeopleNo = supPeopleNo;
        //    IsWaterLevelOp = isWaterLevelOp;
        //    IsMfInstall = isMfInstall;
        //    IsConnSeepageChn = isConnSeepageChn;
        //    SeepageChnLength = seepageChnLength;
        //    LinkWellNo = linkWellNo;
        //    Remark = remark;
        //}

    }

    /// <summary>
    /// 企业井结构体
    /// </summary>
    public struct STR_EntWell
    {
        /// <summary>
        /// 企业井Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 所属乡镇（街道）
        /// </summary>
        public string TsOrSt { get; set; }

        /// <summary>
        /// 企业名称
        /// </summary>
        public string EntName { get; set; }
        
        /// <summary>
        /// 权属单位
        /// </summary>
        public string UnitCat { get; set; }
        
        /// <summary>
        /// 位置
        /// </summary>
        public string Loc { get; set; }

        /// <summary>
        /// 东经
        /// </summary>
        public double Lng { get; set; }
        
        /// <summary>
        /// 北纬
        /// </summary>
        public double Lat { get; set; }
        
        /// <summary>
        /// 用途
        /// </summary>
        public string Usefor { get; set; }

        /// <summary>
        /// 是否记录了成井时间
        /// </summary>
        public bool IfRecordDigTime { get; set; }

        /// <summary>
        /// 成井时间
        /// </summary>
        public int DigTime { get; set; }

        /// <summary>
        /// 取水证号
        /// </summary>
        public string WaterIntakingNo { get; set; }

        /// <summary>
        /// 是否正常缴费
        /// </summary>
        public bool IsPaid { get; set; }

        /// <summary>
        /// 井深（米）
        /// </summary>
        public int WellDepth { get; set; }

        /// <summary>
        /// 管材
        /// </summary>
        public string TubeMat { get; set; }

        /// <summary>
        /// 井管内径（毫米）
        /// </summary>
        public int TubeIR { get; set; }

        /// <summary>
        /// 止水深度（米）
        /// </summary>
        public int StanWaterDepth { get; set; }

        /// <summary>
        /// 咸水底板深度（米）
        /// </summary>
        public int SaltWaterFloorDepth { get; set; }

        /// <summary>
        /// 过滤器位置(低位)（米）
        /// </summary>
        public int FilterLocLow { get; set; }

        /// <summary>
        /// 过滤器位置(高位)（米）
        /// </summary>
        public int FilterLocHigh { get; set; }

        /// <summary>
        /// 静水位（米）
        /// </summary>
        public int StillWaterLoc { get; set; }

        /// <summary>
        /// 水泵型号
        /// </summary>
        public string PumpModel { get; set; }

        /// <summary>
        /// 水泵动力（千瓦）
        /// </summary>
        public float PumpPower { get; set; }

        /// <summary>
        /// 是否为水位观测点
        /// </summary>
        public bool IsWaterLevelOp { get; set; }

        /// <summary>
        /// 是否安装计量设施
        /// </summary>
        public bool IsMfInstall { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        //public STR_EntWell(int id,string tsOrSt, string entName, string unitCat,
        //                        string loc, double lng, double lat,
        //                        string usefor, bool ifRecordDigTime, DateTime digTime, string waterIntakingNo,
        //                        bool isPaid, int wellDepth, string tubeMat,
        //                        int tubeIR, int stanWaterDepth, int saltWaterFloorDepth,
        //                        int filterLocLow, int filterLocHigh, int stillWaterLoc, string pumpModel,
        //                        float pumpPower, bool isWaterLevelOp, bool isMfInstall,
        //                        string remark)
        //{
        //    Id = id;
        //    TsOrSt = tsOrSt;
        //    EntName = entName;
        //    UnitCat = unitCat;
        //    Loc = loc;
        //    Lng = lng;
        //    Lat = lat;
        //    Usefor = usefor;
        //    IfRecordDigTime = ifRecordDigTime;
        //    DigTime = digTime;
        //    WaterIntakingNo = waterIntakingNo;
        //    IsPaid = isPaid;
        //    WellDepth = wellDepth;
        //    TubeMat = tubeMat;
        //    TubeIR = tubeIR;
        //    StanWaterDepth = stanWaterDepth;
        //    SaltWaterFloorDepth = saltWaterFloorDepth;
        //    FilterLocLow = filterLocLow;
        //    FilterLocHigh = filterLocHigh;
        //    StillWaterLoc = stillWaterLoc;
        //    PumpModel = pumpModel;
        //    PumpPower = pumpPower;
        //    IsWaterLevelOp = isWaterLevelOp;
        //    IsMfInstall = isMfInstall;
        //    Remark = remark;
        //}
    }
}
