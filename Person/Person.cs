using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        public string _name;
        public int _age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get { return _name; } set { this._name = value; } }
        public int Age { get { return _age; } set { this._age = value; } }


        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(String.Format("Name: {0}, Age: {1}",
                                 this.Name,
                                 this.Age));

            return stringBuilder.ToString();
        }
    }
}
