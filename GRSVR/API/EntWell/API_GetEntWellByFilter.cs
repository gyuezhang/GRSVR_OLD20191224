using Db;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System.Collections.Generic;

namespace GRSVR
{
    public class API_GetEntWellByFilter : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_GetEntWellByFilter"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            try
            {
                string filter = requestInfo.Parameters[0];

                List<STR_EntWell> entWells = DbEntWell.GetEntWellByFilter(filter);
                List<string> res = new List<string>();
                foreach (STR_EntWell entWell in entWells)
                {
                    res.Add(entWell.Id.ToString() + " ");
                    res.Add(entWell.TsOrSt + " ");
                    res.Add(entWell.EntName + " ");
                    res.Add(entWell.UnitCat + " ");
                    res.Add(entWell.Loc + " ");
                    res.Add(entWell.Lng.ToString() + " ");
                    res.Add(entWell.Lat.ToString() + " ");
                    res.Add(entWell.Usefor + " ");
                    res.Add(entWell.IfRecordDigTime.ToString() + " ");
                    res.Add(entWell.DigTime.ToString() + " ");
                    res.Add(entWell.WaterIntakingNo + " ");
                    res.Add(entWell.WellDepth.ToString() + " ");
                    res.Add(entWell.TubeMat + " ");
                    res.Add(entWell.TubeIR.ToString() + " ");
                    res.Add(entWell.StanWaterDepth.ToString() + " ");
                    res.Add(entWell.SaltWaterFloorDepth.ToString() + " ");
                    res.Add(entWell.FilterLocLow.ToString() + " ");
                    res.Add(entWell.FilterLocHigh.ToString() + " ");
                    res.Add(entWell.StillWaterLoc.ToString() + " ");
                    res.Add(entWell.PumpModel + " ");
                    res.Add(entWell.PumpPower.ToString() + " ");
                    res.Add(entWell.IsMfInstall.ToString() + " ");
                    res.Add(entWell.IsWaterLevelOp.ToString() + " ");
                    res.Add(entWell.Remark + " ");
                }
                session.Send(API_ID.API_GetEntWellByFilter, RES_STATE.OK, res);

            }
            catch
            {
                session.Send(API_ID.API_GetEntWellByFilter, RES_STATE.FAILED);
            }
        }
    }
}