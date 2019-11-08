using Db;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System.Collections.Generic;

namespace GRSVR
{
    public class API_GetWellByFilter : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_GetWellByFilter"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            try
            {
                string filter = requestInfo.Parameters[0];

                List<STR_Well> wells = DbWell.GetWellByFilter(filter);
                List<string> res = new List<string>();
                foreach (STR_Well well in wells)
                {
                    res.Add(well.Id.ToString()  +" ");
                    res.Add(well.TsOrSt              + " ");
                    res.Add(well.Village             + " ");
                    res.Add(well.UnitCat             + " ");
                    res.Add(well.Loc                 + " ");
                    res.Add(well.Lng.ToString() + " ");
                    res.Add(well.Lat.ToString() + " ");
                    res.Add(well.Usefor              + " ");
                    res.Add(well.IfRecordDigTime.ToString() + " ");
                    res.Add(well.DigTime.ToString() + " ");
                    res.Add(well.WaterIntakingNo     + " ");
                    res.Add(well.WellDepth.ToString() + " ");
                    res.Add(well.TubeMat             + " ");
                    res.Add(well.TubeIR.ToString() + " ");
                    res.Add(well.StanWaterDepth.ToString() + " ");
                    res.Add(well.SaltWaterFloorDepth.ToString() + " ");
                    res.Add(well.FilterLocLow.ToString() + " ");
                    res.Add(well.FilterLocHigh.ToString() + " ");
                    res.Add(well.StillWaterLoc.ToString() + " ");
                    res.Add(well.PumpModel           + " ");
                    res.Add(well.PumpPower.ToString() + " ");
                    res.Add(well.CoverArea.ToString() + " ");
                    res.Add(well.SupPeopleNo.ToString() + " ");
                    res.Add(well.IsMfInstall.ToString() + " ");
                    res.Add(well.IsWaterLevelOp.ToString() + " ");
                    res.Add(well.IsConnSeepageChn.ToString() + " ");
                    res.Add(well.SeepageChnLength.ToString() + " ");
                    res.Add(well.LinkWellNo.ToString() + " ");
                    res.Add(well.Remark              + " ");
                }
                session.Send(API_ID.API_GetWellByFilter, RES_STATE.OK, res);

            }
            catch
            {
                session.Send(API_ID.API_GetWellByFilter, RES_STATE.FAILED);
            }
        }
    }
}