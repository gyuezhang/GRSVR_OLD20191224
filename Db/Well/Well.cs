using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Well
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Well
    {
        [JsonProperty]
        public int _id;//0
        [JsonProperty]
        public string _tsOrSt;//乡镇街道1
        [JsonProperty]
        public string _village;//村庄2
        [JsonProperty]
        public string _loc;//位置3
        [JsonProperty]
        public string _lng;//东经4
        [JsonProperty]
        public string _lat;//北纬5
        [JsonProperty]
        public string _unitCat;//单位类型6
        [JsonProperty]
        public string _usage;//用途7
        [JsonProperty]
        public DateTime _ditTime;//成井时间8
        [JsonProperty]
        public float _wellDepth;//井深9 米
        [JsonProperty]
        public string _tubeMat;//管材10
        [JsonProperty]
        public float _tubeIr;//井管内径11 毫米
        [JsonProperty]
        public float _stanWaterDepth;//止水深度12 米
        [JsonProperty]
        public float _saltWaterFloorDepth;//咸水底板深度13 米
        [JsonProperty]
        public float _filterLocLow;//过滤器低位14 米
        [JsonProperty]
        public float _filterLocHigh;//过滤器高位15 米
        [JsonProperty]
        public float _stillWaterLoc;//静水位16 //米
        [JsonProperty]
        public string _pumpMode;//水泵型号17
        [JsonProperty]
        public float _pumpPower;//水泵功率18 //kw
        [JsonProperty]
        public float _coverArea;//井控面积19
        [JsonProperty]
        public int _supPeopleNum;//供水人口20
        [JsonProperty]
        public bool _isWaterLevelOp;//是否水位观测点21
        [JsonProperty]
        public bool _isMfInstalled;//是否安装计量设备22
        [JsonProperty]
        public int _linkWellNo;//连接井眼眼数23
        [JsonProperty]
        public bool _isSeepChnLinked;//装防渗渠道24
        [JsonProperty]
        public float _seepChnLength;//防渗渠道长度25 //千米 float
        [JsonProperty]
        public string _remark;//备注26
    }

}
