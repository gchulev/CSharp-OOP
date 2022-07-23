using Logger.Layouts.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Layouts
{
    internal class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
