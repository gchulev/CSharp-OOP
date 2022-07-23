using Logger.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Messages.Interfaces
{
    public interface IMessage
    {
        public string LogTime { get; }
        public string MessageText { get; }
        public ReportLevel Level { get; }
    }
}
