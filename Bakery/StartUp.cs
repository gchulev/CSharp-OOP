﻿namespace Bakery
{
    using Bakery.Core;
    using Bakery.Models.Tables;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            //Don't forget to comment out the commented code lines in the Engine class!
            var engine = new Engine();

            engine.Run();
        }
    }
}
