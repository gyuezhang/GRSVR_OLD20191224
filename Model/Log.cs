using Newtonsoft.Json;
using Stylet;

namespace Model
{
    /// <summary>
    /// 日志结构体
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class C_Log : PropertyChangedBase
    {
        private int _id;
        private E_LogType _logType;
        private E_UserType _userType;
        private int _userId;
        private E_OperType _operType;
        private string _content;

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
        public E_OperType OperType
        {
            get { return _operType; }
            set
            {
                SetAndNotify(ref _operType, value);
            }
        }

        [JsonProperty]
        public string Content
        {
            get { return _content; }
            set
            {
                SetAndNotify(ref _content, value);
            }
        }
    }
}
