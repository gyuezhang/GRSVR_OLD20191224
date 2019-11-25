using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Well
    {
        [JsonProperty]
        public int Id;//0
        [JsonProperty]
        public string TsOrSt;//乡镇街道1
        [JsonProperty]
        public string Village;//村庄2
        [JsonProperty]
        public string Loc;//位置3
        [JsonProperty]
        public string Lng;//东经4
        [JsonProperty]
        public string Lat;//北纬5
        [JsonProperty]
        public string UnitCat;//单位类型6
        [JsonProperty]
        public string Usefor;//用途7
        [JsonProperty]
        public DateTime DigTime;//成井时间8
        [JsonProperty]
        public float WellDepth;//井深9 米
        [JsonProperty]
        public string TubeMat;//管材10
        [JsonProperty]
        public float TubeIr;//井管内径11 毫米
        [JsonProperty]
        public float StanWaterDepth;//止水深度12 米
        [JsonProperty]
        public float SaltWaterFloorDepth;//咸水底板深度13 米
        [JsonProperty]
        public float FilterLocLow;//过滤器低位14 米
        [JsonProperty]
        public float FilterLocHigh;//过滤器高位15 米
        [JsonProperty]
        public float StillWaterLoc;//静水位16 //米
        [JsonProperty]
        public string PumpMode;//水泵型号17
        [JsonProperty]
        public float PumpPower;//水泵功率18 //kw
        [JsonProperty]
        public float CoverArea;//井控面积19
        [JsonProperty]
        public int SupPeopleNum;//供水人口20
        [JsonProperty]
        public bool IsWaterLevelOp;//是否水位观测点21
        [JsonProperty]
        public bool IsMfInstalled;//是否安装计量设备22
        [JsonProperty]
        public int LinkWellNo;//连接井眼眼数23
        [JsonProperty]
        public bool IsSeepChnLinked;//装防渗渠道24
        [JsonProperty]
        public float SeepChnLength;//防渗渠道长度25 //千米 float
        [JsonProperty]
        public string Remark;//备注26
    }

}
