using System.Transactions;

namespace InformationSystem
{
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
            for (int i = 0; i < Product.products.Count; i++)
            {
                Console.WriteLine($"[{i}] ID: {Product.products[i].id}, название: {Product.products[i].name}, цена: {Product.products[i].price}, кол-во на складе: {Product.products[i].available}");
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
                    if (index < 0 | index >= Product.products.Count) flag = false;

                    if (flag)
                    {
                        Console.WriteLine($" ID: {Product.products[index].id}\n Название: {Product.products[index].name}\n Цена: {Product.products[index].price}\n Кол-во на складе: {Product.products[index].available}");
                        Console.WriteLine("Кол-во продукта для заказа: ");
                        int selected = IntInput();

                        if (selected == 0 | selected > Product.products[index].available)
                        {
                            Console.WriteLine("Некорректное значение!");
                        }
                        else
                        {
                            Product.products[index].available -= selected;
                            Transaction newtransaction = new(Transaction.transactions.Count, Product.products[index].name, Product.products[index].price * selected, DateTime.Now.ToString(), true);
                            Transaction.transactions.Add(newtransaction);
                            FileWork.Serialization(Transaction.transactions, Transaction.path);
                        }
                    }
                    else Console.WriteLine("Некорректное значение!");
                }
                else break;
            }
        }
    }
}
