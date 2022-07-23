using Logger.Enum;
using Logger.Layouts.Interfaces;
using Logger.Messages.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Appenders.Interfaces
{
    public interface IAppender
    {
        ILayout Layout { get; }
        void Append(IMessage msg);
    }
}
