using InformationSystem.Entities;
using InformationSystem.Services;

namespace InformationSystem.Roles;

internal class Cashier : User
{
    public Cashier(int id, string login, string password, string role) : base(id, login, password, role)
    {
        Console.Clear();
        Console.WriteLine($"Добро пожаловать, кассир {login}!");
        Console.WriteLine(new string('-', 30));
        Visualization();
        Console.WriteLine("Выберите операцию:\n 1 - Выбрать товар");

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
        else if (choice == "6")
        {
            Program.Start("Вы вышли"); 
        }

        Cashier cs = new(id, login, password, role);
    }

    public override void Visualization()
    {
        for (int i = 0; i < Product.Products.Count; i++)
        {
            Console.WriteLine($"[{i}] ID: {Product.Products[i].id}, название: {Product.Products[i].name}, цена: {Product.Products[i].price}, кол-во на складе: {Product.Products[i].available}");
        }
    }

    public override void More()
    {
        while (true)
        {
            Console.WriteLine($"Введите индекс для заказа товара (Enter - закончить):");

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
                if (index < 0 | index >= Product.Products.Count) flag = false;

                if (flag)
                {
                    Console.WriteLine($" ID: {Product.Products[index].id}\n Название: {Product.Products[index].name}\n Цена: {Product.Products[index].price}\n Кол-во на складе: {Product.Products[index].available}");
                    Console.WriteLine("Кол-во продукта для заказа: ");
                    int selected = IntInput();

                    if (selected == 0 | selected > Product.Products[index].available)
                    {
                        Console.WriteLine("Некорректное значение!");
                    }
                    else
                    {
                        Product.Products[index].available -= selected;
                        Transaction newtransaction = new(Transaction.Transactions.Count, Product.Products[index].name, Product.Products[index].price * selected, DateTime.Now.ToString(), true);
                        Transaction.Transactions.Add(newtransaction);
                        FileWorkService.Serialization(Transaction.Transactions, Transaction.Path);
                    }
                }
                else Console.WriteLine("Некорректное значение!");
            }
            else break;
        }
    }
}