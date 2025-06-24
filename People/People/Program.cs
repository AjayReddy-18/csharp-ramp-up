namespace People
{

    internal class Program
    {
        static void Main(string[] args)
        {
            var e = new Employee("Ajay");
            e.Introduce();
            var m = new Manager("Krishna");
            m.Introduce();
        }
    }
}
