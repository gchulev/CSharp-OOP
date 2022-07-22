using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    public class Person
    {
        private const int MIN_RANGE_VALUE = 10;
        private const int MAX_RANGE_VALUE = 90;
        public Person(string name, int age)
        {
            this.FullName = name;
            this.Age = age;
        }

        [MyRequired]
        public string FullName { get; set; }

        [MyRange(MIN_RANGE_VALUE, MAX_RANGE_VALUE)]
        public int Age { get; set; }
    }
}
