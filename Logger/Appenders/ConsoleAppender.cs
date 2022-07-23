using Logger.Appenders.Interfaces;
using Logger.Layouts.Interfaces;
using Logger.Messages.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Appenders
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout)
        {
            this.Layout = layout;
        }
        public ILayout Layout { get; }

        public void Append(IMessage msg)
        {
            string formattedMessage = this.FormatMessage(msg);
            Console.WriteLine(formattedMessage);
        }

        private string FormatMessage(IMessage message)
        {
            return string.Format(this.Layout.Format, message.LogTime, message.Level.ToString(), message.MessageText);
        }
    }
}
