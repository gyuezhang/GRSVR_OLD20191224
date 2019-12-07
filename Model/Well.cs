using Newtonsoft.Json;
using Stylet;
using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// 机井参数类型
    /// </summary>
    public enum WellParaType
    {
        UnitCat,
        Loc,
        TubeMat,
        PumpModel,
    }

    /// <summary>
    /// 机井参数
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class WellPara : PropertyChangedBase
    {
        public WellPara() { }
        public WellPara(WellParaType type, string value)
        {
            Type = type;
            Value = value;
        }

        private WellParaType _type;
        private string _value;

        [JsonProperty]
        public WellParaType Type
        {
            get { return _type; }
            set
            {
                SetAndNotify(ref _type, value);
            }
        }

        [JsonProperty]
        public string Value
        {
            get { return _value; }
            set
            {
                SetAndNotify(ref _value, value);
            }
        }
    }

    /// <summary>
    /// 机井参数列表
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class WellParas : PropertyChangedBase
    {
        public WellParas(){ }

        public WellParas(List<WellPara> paras)
        {
            AllParas = paras;
            UnitCat.Clear();
            Loc.Clear();
            TubeMat.Clear();
            PumpModel.Clear();

            if (paras == null)
                return;
            if (paras.Count == 0)
                return;

            foreach(WellPara node in paras)
            {
                switch(node.Type)
                {
                    case WellParaType.Loc:
                        Loc.Add(node);
                        break;
                    case WellParaType.PumpModel:
                        PumpModel.Add(node);
                        break;
                    case WellParaType.TubeMat:
                        TubeMat.Add(node);
                        break;
                    case WellParaType.UnitCat:
                        UnitCat.Add(node);
                        break;
                    default:
                        break;
                }
            }

            if (UnitCat.Count != 0)
            {
                UnitCatIndex = UnitCat[0];
            }
            if (Loc.Count != 0)
            {
                LocIndex = Loc[0];
            }
            if (PumpModel.Count != 0)
            {
                PumpModelIndex = PumpModel[0];
            }
            if (TubeMat.Count != 0)
            {
                TubeMatIndex = TubeMat[0];
            }
        }

        public void ResetAllPara()
        {
            AllParas.Clear();
            AllParas.AddRange(UnitCat);
            AllParas.AddRange(Loc);
            AllParas.AddRange(TubeMat);
            AllParas.AddRange(PumpModel);
        }

        private List<WellPara> _allParas = new List<WellPara>();
        private List<WellPara> _unitCat = new List<WellPara>();
        private List<WellPara> _loc = new List<WellPara>();
        private List<WellPara> _tubeMat = new List<WellPara>();
        private List<WellPara> _pumpModel = new List<WellPara>();

        private WellPara _unitCatIndex = new WellPara();
        private WellPara _locIndex = new WellPara();
        private WellPara _tubeMatIndex = new WellPara();
        private WellPara _pumpModelIndex = new WellPara();

        [JsonProperty]
        public List<WellPara> AllParas
        {
            get { return _allParas; }
            set
            {
                SetAndNotify(ref _allParas, value);
            }
        }

        [JsonProperty]
        public List<WellPara> UnitCat
        {
            get { return _unitCat; }
            set
            {
                SetAndNotify(ref _unitCat, value);
            }
        }

        [JsonProperty]
        public List<WellPara> Loc
        {
            get { return _loc; }
            set
            {
                SetAndNotify(ref _loc, value);
            }
        }

        [JsonProperty]
        public List<WellPara> TubeMat
        {
            get { return _tubeMat; }
            set
            {
                SetAndNotify(ref _tubeMat, value);
            }
        }

        [JsonProperty]
        public List<WellPara> PumpModel
        {
            get { return _pumpModel; }
            set
            {
                SetAndNotify(ref _pumpModel, value);
            }
        }

        public WellPara UnitCatIndex
        {
            get { return _unitCatIndex; }
            set
            {
                SetAndNotify(ref _unitCatIndex, value);
            }
        }

        public WellPara LocIndex
        {
            get { return _locIndex; }
            set
            {
                SetAndNotify(ref _locIndex, value);
            }
        }

        public WellPara TubeMatIndex
        {
            get { return _tubeMatIndex; }
            set
            {
                SetAndNotify(ref _tubeMatIndex, value);
            }
        }

        public WellPara PumpModelIndex
        {
            get { return _pumpModelIndex; }
            set
            {
                SetAndNotify(ref _pumpModelIndex, value);
            }
        }

    }

    /// <summary>
    /// 机井
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Well : PropertyChangedBase
    {
    }

}
