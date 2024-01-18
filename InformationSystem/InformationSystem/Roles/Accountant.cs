using InformationSystem.Entities;
using InformationSystem.Services;

namespace InformationSystem.Roles;

internal class Accountant : User
{
    public Accountant(int id, string login, string password, string role) : base(id, login, password, role)
    {
        Console.Clear();
        Console.WriteLine($"Добро пожаловать, Бухгалтер {login}!");
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

        Accountant ac = new(id, login, password, role);
    }

    public override void Create()
    {
        int id = Transaction.Transactions.Count; string name = "Название"; int amount = 0; string date = DateTime.Now.ToString(); bool profit = true;

        while (true)
        {
            Console.WriteLine($"Выберите параметр:\n 1 - ID: {id}\n 2 - Название: {name}\n 3 - Сумма: {amount}\n 4 - Дата: {date}\n 5 - Прибыль: {profit}\n Enter - Закончить");

            string choice = ChoiceInput();

            if (choice == "1")
            {
                Console.Write("Введите ID: ");
                id = IntInput();
            }
            else if (choice == "2")
            {
                Console.Write("Введите название: ");
                name = StringInput();
            }
            else if (choice == "3")
            {
                Console.Write("Введите сумму: ");
                amount = IntInput();
            }
            else if (choice == "4")
            {
                Console.Write("Введите дату: ");
                date = StringInput();
            }
            else if (choice == "5")
            {
                Console.Write("Прибыль? 1 - Да, 2 - Нет:  ");
                string choice1 = ChoiceInput();

                if (choice1 == "1") profit = true;
                else if (choice1 == "2") profit = false;
                else Console.WriteLine("Некорректное значение!");
            }
            else
            {
                break;
            }
        }

        Transaction newtransaction = new(id, name, amount, date, profit);
        Transaction.Transactions.Add(newtransaction);
        FileWorkService.Serialization(Transaction.Transactions, Transaction.Path);
    }

    public override void Visualization()
    {
        for (int i = 0; i < Transaction.Transactions.Count; i++)
        {
            Console.WriteLine($"[{i}] ID: {Transaction.Transactions[i].id}, название: {Transaction.Transactions[i].name}, сумма: {Transaction.Transactions[i].amount}, дата: {Transaction.Transactions[i].date}, прибыль: {Transaction.Transactions[i].profit}");
        }
    }

    public override void Update()
    {
        int findid;

        while (true)
        {
            Console.Write("Введите ID записи для изменения: ");
            findid = IntInput();

            Console.WriteLine("Вы уверены? Enter - чтобы продолжить");
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.Enter) break;
        }

        foreach (Transaction transaction in Transaction.Transactions)
        {
            if (findid == transaction.id)
            {
                while (true)
                {
                    Console.WriteLine($"Выберите параметр:\n 1 - ID: {transaction.id}\n 2 - Название: {transaction.name}\n 3 - Сумма: {transaction.amount}\n 4 - Дата: {transaction.date}\n 5 - Прибыль: {transaction.profit}\n Enter - Закончить");

                    string choice = ChoiceInput();

                    if (choice == "1")
                    {
                        Console.Write("Введите ID: ");
                        transaction.id = IntInput();
                    }
                    else if (choice == "2")
                    {
                        Console.Write("Введите название: ");
                        transaction.name = StringInput();
                    }
                    else if (choice == "3")
                    {
                        Console.Write("Введите сумму: ");
                        transaction.amount = IntInput();
                    }
                    else if (choice == "4")
                    {
                        Console.Write("Введите дату: ");
                        transaction.date = StringInput();
                    }
                    else if (choice == "4")
                    {
                        Console.Write("Прибыль? 1 - Да, 2 - Нет:  ");
                        string choice1 = ChoiceInput();

                        if (choice1 == "1") transaction.profit = true;
                        else if (choice1 == "2") transaction.profit = false;
                        else Console.WriteLine("Некорректное значение!");
                    }
                    else
                    {
                        break;
                    }

                    FileWorkService.Serialization(Transaction.Transactions, Transaction.Path);
                }
            }
        }
    }

    public override void Delete()
    {
        int findid;

        while (true)
        {
            Console.WriteLine("Введите индекс записи для удаления: ");
            findid = IntInput();

            Console.WriteLine("Вы уверены? Enter - чтобы продолжить");
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.Enter) break;
        }

        Transaction.Transactions.Remove(Transaction.Transactions[findid]);
        FileWorkService.Serialization(Transaction.Transactions, Transaction.Path);
    }

    public override void Search()
    {
        while (true)
        {
            Console.WriteLine($"Выберите параметр:\n 1 - индекс\n 2 - ID\n 3 - название\n 4 - сумма\n 5 - дата\n 6 - прибыль\n Enter - закончить");

            string choice = ChoiceInput();

            if (choice == "1")
            {
                Console.Write("Введите искомый индекс: ");
                int id = IntInput();

                if (id >= Product.Products.Count || id < 0)
                {
                    Console.WriteLine("Некорректный индекс!");
                }
                else Console.WriteLine($"ID: {Transaction.Transactions[id].id}, название: {Transaction.Transactions[id].name}, сумма: {Transaction.Transactions[id].amount}, дата: {Transaction.Transactions[id].date}, прибыль: {Transaction.Transactions[id].profit}");


            }
            else if (choice == "2")
            {
                Console.Write("Введите искомый ID: ");
                int id = IntInput();

                foreach (Transaction transaction in Transaction.Transactions)
                {
                    if (id == transaction.id)
                    {
                        Console.WriteLine($"ID: {transaction.id}, название: {transaction.name}, сумма: {transaction.amount}, дата: {transaction.date}, прибыль: {transaction.profit}");

                    }
                }
            }
            else if (choice == "3")
            {
                Console.Write("Введите искомое название: ");
                string name = StringInput();

                foreach (Transaction transaction in Transaction.Transactions)
                {
                    if (name == transaction.name)
                    {
                        Console.WriteLine($"ID: {transaction.id}, название: {transaction.name}, сумма: {transaction.amount}, дата: {transaction.date}, прибыль: {transaction.profit}");
                    }
                }
            }
            else if (choice == "4")
            {
                Console.Write("Введите искомую сумму: ");
                int amount = IntInput();

                foreach (Transaction transaction in Transaction.Transactions)
                {
                    if (amount == transaction.amount)
                    {
                        Console.WriteLine($"ID: {transaction.id}, название: {transaction.name}, сумма: {transaction.amount}, дата: {transaction.date}, прибыль: {transaction.profit}");
                    }
                }
            }
            else if (choice == "5")
            {
                Console.Write("Введите искомую дату: ");
                string date = StringInput();

                foreach (Transaction transaction in Transaction.Transactions)
                {
                    if (date == transaction.date)
                    {
                        Console.WriteLine($"ID: {transaction.id}, название: {transaction.name}, сумма: {transaction.amount}, дата: {transaction.date}, прибыль: {transaction.profit}");
                    }
                }
            }
            else if (choice == "6")
            {
                Console.Write("Прибыль? 1 - Да, 2 - Нет: ");
                string choice1 = ChoiceInput();
                bool profit = false;

                if (choice1 == "1") profit = true;
                else if (choice1 == "2") profit = false;
                else Console.WriteLine("Некорректное значение!");

                foreach (Transaction transaction in Transaction.Transactions)
                {
                    if (profit == transaction.profit)
                    {
                        Console.WriteLine($"ID: {transaction.id}, название: {transaction.name}, сумма: {transaction.amount}, дата: {transaction.date}, прибыль: {transaction.profit}");
                    }
                }
            }
            else
            {
                break;
            }
        }
    }

    public override void More()
    {
        while (true)
        {
            Console.WriteLine($"Введите индекс для подробной информации (Enter - закончить):");

            string choice = ChoiceInput();
            int index = 0;
            bool flag = true;
            if (choice != "")
            {
                try
                {
                    index = int.Parse(choice);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Некорректное значение!");
                    flag = false;
                }
                if (index < 0 | index >= Transaction.Transactions.Count) flag = false;

                if (flag) Console.WriteLine($" ID: {Transaction.Transactions[index].id}\n Название: {Transaction.Transactions[index].name}\n Сумма: {Transaction.Transactions[index].amount}\n Дата: {Transaction.Transactions[index].date}\n Прибыль: {Transaction.Transactions[index].profit}");
                else Console.WriteLine("Некорректное значение!");
            }
            else break;
        }
    }
}