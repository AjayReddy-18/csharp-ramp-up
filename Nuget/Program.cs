using Newtonsoft.Json; 

namespace Nuget
{
    public class Account
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account
            {
                Name = "Ajay Reddy",
                Email = "ajay.reddy",
                DOB = new DateTime(2006, 5, 18, 0, 0, 0, DateTimeKind.Utc),
            };

            string json = JsonConvert.SerializeObject(account, Formatting.Indented);
            Console.WriteLine(json);
            Console.ReadLine();
        }
    }
}