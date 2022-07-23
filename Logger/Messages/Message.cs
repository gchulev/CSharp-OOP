using Logger.Enum;
using Logger.Messages.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Messages
{
    internal class Message : IMessage
    {
        public Message(string date, string messageText, ReportLevel level)
        {
            this.LogTime = date;
            this.MessageText = messageText;
            this.Level = level;
        }
        public string LogTime { get; }

        public string MessageText { get; }

        public ReportLevel Level { get; }
    }
}
