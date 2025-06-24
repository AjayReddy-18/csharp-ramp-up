namespace People
{
    internal class Employee : Person
    {
        public Employee(string name) : base(name) { }

        public override void TellRole()
        {
            Console.WriteLine("I am an Employee"); 
        }
    }
}
