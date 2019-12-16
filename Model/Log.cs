using Newtonsoft.Json;
using Stylet;
using System;

namespace Model
{
    /// <summary>
    /// 日志结构体
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class C_Log : PropertyChangedBase
    {

        public C_Log() { }
        public C_Log(E_LogType logType, E_UserType userType, int userId, E_ActionType actionType, string desc, string exContent)
        {
            LogType = logType;
            UserType = userType;
            UserId = userId;
            ActionType = actionType;
            Desc = desc;
            ExContent = exContent;
        }

        private int _id;
        private E_LogLevel _logLevel;
        private E_LogType _logType;
        private E_UserType _userType;
        private int _userId;
        private E_ActionType _actionType;
        private DateTime _recordTime = DateTime.UtcNow;
        private string _desc;
        private string _exContent;

        [JsonProperty]
        public int Id
        {
            get { return _id; }
            set
            {
                SetAndNotify(ref _id, value);
            }
        }

        [JsonProperty]
        public E_LogLevel LogLevel
        {
            get { return _logLevel; }
            set
            {
                SetAndNotify(ref _logLevel, value);
            }
        }

        [JsonProperty]
        public E_LogType LogType
        {
            get { return _logType; }
            set
            {
                SetAndNotify(ref _logType, value);
            }
        }

        [JsonProperty]
        public E_UserType UserType
        {
            get { return _userType; }
            set
            {
                SetAndNotify(ref _userType, value);
            }
        }

        [JsonProperty]
        public int UserId
        {
            get { return _userId; }
            set
            {
                SetAndNotify(ref _userId, value);
            }
        }

        [JsonProperty]
        public E_ActionType ActionType
        {
            get { return _actionType; }
            set
            {
                SetAndNotify(ref _actionType, value);
            }
        }

        public DateTime RecordTime
        {
            get { return _recordTime; }
            set
            {
                SetAndNotify(ref _recordTime, value);
            }
        }

        [JsonProperty]
        public string Desc
        {
            get { return _desc; }
            set
            {
                SetAndNotify(ref _desc, value);
            }
        }

        [JsonProperty]
        public string ExContent
        {
            get { return _exContent; }
            set
            {
                SetAndNotify(ref _exContent, value);
            }
        }
    }
}
