using Db;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;

namespace GRSVR
{
    public class API_CreateWell : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_CreateWell"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            try
            {
                STR_Well well = new STR_Well();
                well.Id = int.Parse(requestInfo.Parameters[0]);
                well.TsOrSt = requestInfo.Parameters[1];
                well.Village = requestInfo.Parameters[2];
                well.UnitCat = requestInfo.Parameters[3];
                well.Loc = requestInfo.Parameters[4];
                well.Lng = double.Parse(requestInfo.Parameters[5]);
                well.Lat = double.Parse(requestInfo.Parameters[6]);
                well.Usefor = requestInfo.Parameters[7];
                well.IfRecordDigTime = bool.Parse(requestInfo.Parameters[8]);
                well.DigTime = int.Parse(requestInfo.Parameters[9]);
                well.WaterIntakingNo = requestInfo.Parameters[10];
                well.WellDepth = int.Parse(requestInfo.Parameters[11]);
                well.TubeMat = requestInfo.Parameters[12];
                well.TubeIR = int.Parse(requestInfo.Parameters[13]);
                well.StanWaterDepth = int.Parse(requestInfo.Parameters[14]);
                well.SaltWaterFloorDepth = int.Parse(requestInfo.Parameters[15]);
                well.FilterLocLow = int.Parse(requestInfo.Parameters[16]);
                well.FilterLocHigh = int.Parse(requestInfo.Parameters[17]);
                well.StillWaterLoc = int.Parse(requestInfo.Parameters[18]);
                well.PumpModel = requestInfo.Parameters[19];
                well.PumpPower = float.Parse(requestInfo.Parameters[20]);
                well.CoverArea = float.Parse(requestInfo.Parameters[21]);
                well.SupPeopleNo = int.Parse(requestInfo.Parameters[22]);
                well.IsMfInstall = bool.Parse(requestInfo.Parameters[23]);
                well.IsWaterLevelOp = bool.Parse(requestInfo.Parameters[24]);
                well.IsConnSeepageChn = bool.Parse(requestInfo.Parameters[25]);
                well.SeepageChnLength = float.Parse(requestInfo.Parameters[26]);
                well.LinkWellNo = int.Parse(requestInfo.Parameters[27]);
                well.Remark = requestInfo.Parameters[28];

                if (DbWell.CreateWell(well))
                {
                    session.Send(API_ID.API_CreateWell, RES_STATE.OK);
                }
                else
                {
                    session.Send(API_ID.API_CreateWell, RES_STATE.FAILED);
                }

            }
            catch
            {
                return;
            }
        }
    }
}