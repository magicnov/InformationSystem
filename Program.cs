namespace InformationSystem
{
    internal class Program
    {
        static void Main()
        {
            Start("");
        }

        public static void Start(string message)
        {
            Console.Clear();
            if (!string.IsNullOrWhiteSpace(message))
            {
                Console.WriteLine("   " + message);
            }
            
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("Выберите операцию:\n1 - Авторизоваться");

            var choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Введите логин: ");
                var login = Console.ReadLine();

                Console.Write("Введите пароль: ");
                var password = string.Empty;

                while (true)
                {
                    var key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.Enter) break;

                    Console.Write("*");

                    password += key.KeyChar;
                }

                Authorization.Start(login, password);
            }
            else
            {
                Start("Неправильно введено значение операции!");
            }
        }
    }
}