namespace People
{
    internal class Employee : Person
    {
        public Employee(string name) : base(name)
        {
            Role = "Employee";
        }

        public string Role { get; }

        public override void TellRole()
        {
            Console.WriteLine("I am an Employee"); 
        }
    }
}
