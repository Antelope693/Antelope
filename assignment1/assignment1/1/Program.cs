namespace homeWork1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter 2 numbers and 1 operator.Each with a enter!");
            string temp;
            int a;
            int b;
            char op;
            temp = Console.ReadLine();
            a = Int32.Parse(temp);
            temp = Console.ReadLine();
            b = Int32.Parse(temp);
            temp = Console.ReadLine();
            op = char.Parse(temp);
            int result;
            switch (op) {
                case '+':
                    result = a + b;
                    Console.WriteLine($"{a}{op}{b}={result}");
                    break;
                case '-':
                    result = a - b;
                    Console.WriteLine($"{a}{op}{b}={result}");
                    break;
                case '*':
                    result = a * b;
                    Console.WriteLine($"{a}{op}{b}={result}");
                    break;
                case '/':
                    result = a / b;
                    Console.WriteLine($"{a}{op}{b}={result}");
                    break;
                default:
                    Console.WriteLine("Unknown operator");
                    break;
            
            }


        }
    }
}
