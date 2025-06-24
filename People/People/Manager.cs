namespace People
{
    internal class Manager : Person
    {
        public Manager(string name): base(name) { }

        public override void TellRole()
        {
            Console.WriteLine("I am a Manager");
        }
    }
}
