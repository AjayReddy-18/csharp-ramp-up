﻿using Newtonsoft.Json;

namespace People
{
    internal abstract class Person
    {
        public Person(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public void Introduce()
        {
            Console.WriteLine("Hello, My name is " + Name);
            TellRole();
        }

        public abstract void TellRole();

         public override string ToString()
        {
            return Name;
        }

        public string ToJson()
        {
            var info = JsonConvert.SerializeObject(this, Formatting.Indented);
            return info;
        }
    }
}
