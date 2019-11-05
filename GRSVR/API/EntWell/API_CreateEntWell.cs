using Db;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;

namespace GRSVR
{
    public class API_CreateEntWell : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "API_CreateEntWell"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            try
            {
                STR_EntWell entWell = new STR_EntWell();
                entWell.Id = int.Parse(requestInfo.Parameters[0]);
                entWell.TsOrSt = requestInfo.Parameters[1];
                entWell.EntName = requestInfo.Parameters[2];
                entWell.UnitCat = requestInfo.Parameters[3];
                entWell.Loc = requestInfo.Parameters[4];
                entWell.Lng = double.Parse(requestInfo.Parameters[5]);
                entWell.Lat = double.Parse(requestInfo.Parameters[6]);
                entWell.Usefor = requestInfo.Parameters[7];
                entWell.IfRecordDigTime = bool.Parse(requestInfo.Parameters[8]);
                entWell.DigTime = int.Parse(requestInfo.Parameters[9]);
                entWell.WaterIntakingNo = requestInfo.Parameters[10];
                entWell.WellDepth = int.Parse(requestInfo.Parameters[11]);
                entWell.TubeMat = requestInfo.Parameters[12];
                entWell.TubeIR = int.Parse(requestInfo.Parameters[13]);
                entWell.StanWaterDepth = int.Parse(requestInfo.Parameters[14]);
                entWell.SaltWaterFloorDepth = int.Parse(requestInfo.Parameters[15]);
                entWell.FilterLocLow = int.Parse(requestInfo.Parameters[16]);
                entWell.FilterLocHigh = int.Parse(requestInfo.Parameters[17]);
                entWell.StillWaterLoc = int.Parse(requestInfo.Parameters[18]);
                entWell.PumpModel = requestInfo.Parameters[19];
                entWell.PumpPower = float.Parse(requestInfo.Parameters[20]);
                entWell.IsWaterLevelOp = bool.Parse(requestInfo.Parameters[21]);
                entWell.IsMfInstall = bool.Parse(requestInfo.Parameters[22]);
                entWell.Remark = requestInfo.Parameters[23];

                if (DbEntWell.CreateEntWell(entWell))
                {
                    session.Send(API_ID.API_CreateEntWell, RES_ID.OK);
                }
                else
                {
                    session.Send(API_ID.API_CreateEntWell, RES_ID.FAILED);
                }

            }
            catch
            {
                return;
            }
        }
    }
}