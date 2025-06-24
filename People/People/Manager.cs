using Newtonsoft.Json;

namespace People
{
    internal class Manager : Person
    {
        public Manager(string name): base(name) 
        {
            Role = "Manager";
        }

        public string Role { get; }

        public override void TellRole()
        {
            Console.WriteLine("I am a manager.");
        }
    }
}
