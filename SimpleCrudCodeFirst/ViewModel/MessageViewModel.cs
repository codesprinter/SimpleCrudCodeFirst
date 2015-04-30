using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SC.ViewModel
{
    public class MessageViewModel
    {
        public string ClassName { get; set; }
        public string MessageText { get; set; }
        public EMessageType MessageType { get; set; }
    }

    public enum EMessageType
    { 
        Success = 1,
        Warning = 2,
        Error = 3
    }
}