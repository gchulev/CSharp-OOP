using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    internal class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int _minRangeValue;
        private readonly int _maxRangeValue;

        public MyRangeAttribute(int minRangeValue, int maxRangeValue)
        {
            this._minRangeValue = minRangeValue;
            this._maxRangeValue = maxRangeValue;
        }
        public override bool IsValid(object obj)
        {
            if (obj is int val)
            {
                return val >= this._minRangeValue && val <= this._maxRangeValue;
            }
            return false;
        }
    }
}
