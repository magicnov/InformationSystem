namespace InformationSystem
{
    internal class Administrator : User
    {
        public Administrator(int id, string login, string password, string role) : base(id, login, password, role)
        {
            Console.Clear();
            Console.WriteLine($"Добро пожаловать, администратор {login}!");
            Console.WriteLine(new string('-', 30));
            Visualization();
            Console.WriteLine("Выберите операцию:\n 1 - Подробнее\n 2 - Добавить \n 3 - Изменить \n 4 - Удалить \n 5 - Поиск");

            string choice = "";

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.Enter) break;
                else if (key.Key == ConsoleKey.Escape)
                {
                    choice = "6";
                    break;
                }

                choice += key.KeyChar;
            }

            if (choice == "1")
            {
                More();
            }
            else if (choice == "2")
            {
                Create();
            }
            else if (choice == "3")
            {
                Update();
            }
            else if (choice == "4")
            {
                Delete();
            }
            else if (choice == "5")
            {
                Search();
            }
            else if (choice == "6")
            {
                Program.Start("Вы вышли");
            }

            Administrator admin = new(id, login, password, role);
        }
    }
}