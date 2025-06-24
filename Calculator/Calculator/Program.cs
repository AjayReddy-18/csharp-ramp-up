namespace Calculator
{
    internal class Program
    {
        private static readonly Func<double, double, double> add = (a, b) => a + b;
        private static readonly Func<double, double, double> sub = (a, b) => a - b;
        private static readonly Func<double, double, double> mul = (a, b) => a * b;
        private static readonly Func<double, double, double> div = (a, b) => b == 0 ? 0 : a / b;

        static void Main(string[] args)
        {
            //while (true)
            //{
            //    Calculate();
            //}
            var result = div(2, 0);
            Console.WriteLine(result);
        }

        private static void Calculate()
        {
            Console.Clear();
            UserPrompt();
            string input = ReadInput("Enter your choice: ");
            var choice = int.Parse(input);
            var number1 = double.Parse(ReadInput("Enter number 1: "));
            var number2 = double.Parse(ReadInput("Enter number 2: "));
            var result = PerformOperation(choice, number1, number2);
            Console.WriteLine("The result is: " + result);
            Console.ReadLine();
        }

        private static double PerformOperation(int choice, double number1, double number2)
        {
            var result = choice switch
            {
                1 => add(number1, number2),
                2 => sub(number1, number2),
                3 => mul(number1, number2),
                _ => div(number1, number2),
            };

            return result;
        }

        private static string ReadInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        private static void UserPrompt()
        {
            Console.WriteLine("Welcome to the Calculator app");
            Console.WriteLine("Choose the operation");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Sub");
            Console.WriteLine("3. Mul");
            Console.WriteLine("4. Div");
        }
    }
}
