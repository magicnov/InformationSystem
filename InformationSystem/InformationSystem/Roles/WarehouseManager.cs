using InformationSystem.Entities;

namespace InformationSystem.Roles;

internal class WarehouseManager : User
{
    public WarehouseManager(int id, string login, string password, string role) : base(id, login, password, role)
    {
        Console.Clear();
        Console.WriteLine($"Добро пожаловать, Склад {login}!");
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

        WarehouseManager wh = new(id, login, password, role);
    }

    public override void Create()
    {
        int id = Product.Products.Count; string name = "Товар"; int price = 0; int available = 1;

        while (true)
        {
            Console.WriteLine($"Выберите параметр:\n 1 - ID: {id}\n 2 - название: {name}\n 3 - цена за штуку: {price}\n 4 - кол-во на складе: {available}\n Enter - закончить");

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
                Console.Write("Введите цену: ");
                price = IntInput();
            }
            else if (choice == "4")
            {
                Console.Write("Введите кол-во на складе ");
                available = IntInput();
            }
            else
            {
                break;
            }
        }

        Product newproduct = new(id, name, price, available);
        Product.Products.Add(newproduct);
        FileWork.Serialization(Product.Products, Product.Path);
    }

    public override void Visualization()
    {
        for (int i = 0; i < Product.Products.Count; i++)
        {
            Console.WriteLine($"[{i}] ID: {Product.Products[i].id}, название: {Product.Products[i].name}, цена: {Product.Products[i].price}, кол-во на складе: {Product.Products[i].available}");
        }
    }

    public override void Update()
    {
        int findid;

        while (true)
        {
            Console.WriteLine("Введите ID товара для изменения: ");
            findid = IntInput();

            Console.WriteLine("Вы уверены? Enter - чтобы продолжить");
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.Enter) break;
        }

        foreach (Product product in Product.Products)
        {
            if (findid == product.id)
            {
                while (true)
                {
                    Console.WriteLine($"Выберите параметр:\n 1 - ID: {product.id}\n 2 - название: {product.name}\n 3 - цена за штуку: {product.price}\n 4 - кол-во на складе: {product.available}\n Enter - закончить");

                    string choice = ChoiceInput();

                    if (choice == "1")
                    {
                        Console.Write("Введите ID: ");
                        product.id = IntInput();
                    }
                    else if (choice == "2")
                    {
                        Console.Write("Введите логин: ");
                        product.name = StringInput();
                    }
                    else if (choice == "3")
                    {
                        Console.Write("Введите пароль: ");
                        product.price = IntInput();
                    }
                    else if (choice == "4")
                    {
                        Console.Write("Введите роль ");
                        product.available = IntInput();
                    }
                    else
                    {
                        break;
                    }

                    FileWork.Serialization(Product.Products, Product.Path);
                }
            }
        }
    }

    public override void Delete()
    {
        int findid;

        while (true)
        {
            Console.Write("Введите индекс товара для удаления: ");
            findid = IntInput();

            Console.WriteLine("Вы уверены? Enter - чтобы продолжить");
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.Enter) break;
        }

        Product.Products.Remove(Product.Products[findid]);
        FileWork.Serialization(Product.Products, Product.Path);
    }

    public override void Search()
    {
        while (true)
        {
            Console.WriteLine($"Выберите параметр:\n 1 - индекс\n 2 - ID\n 3 - название\n 4 - цена\n 5 - кол-во на складе\n Enter - закончить");

            string choice = ChoiceInput();

            if (choice == "1")
            {
                Console.Write("Введите искомый индекс: ");
                int id = IntInput();

                if (id >= Product.Products.Count || id < 0)
                {
                    Console.WriteLine("Некорректный индекс!");
                }
                else Console.WriteLine($"ID: {Product.Products[id].id}, название: {Product.Products[id].name}, цена: {Product.Products[id].price}, кол-во на складе: {Product.Products[id].available}");

            }
            else if (choice == "2")
            {
                Console.Write("Введите искомый ID: ");
                int id = IntInput();

                foreach (Product product in Product.Products)
                {
                    if (id == product.id)
                    {
                        Console.WriteLine($"ID: {Product.Products[id].id}, название: {Product.Products[id].name}, цена: {Product.Products[id].price}, кол-во на складе: {Product.Products[id].available}");
                    }
                }
            }
            else if (choice == "3")
            {
                Console.Write("Введите искомое название: ");
                string name = StringInput();

                foreach (Product product in Product.Products)
                {
                    if (name == product.name)
                    {
                        Console.WriteLine($"ID: {Product.Products[id].id}, название: {Product.Products[id].name}, цена: {Product.Products[id].price}, кол-во на складе: {Product.Products[id].available}");
                    }
                }
            }
            else if (choice == "4")
            {
                Console.Write("Введите искомую цену: ");
                int price = IntInput();

                foreach (Product product in Product.Products)
                {
                    if (price == product.price)
                    {
                        Console.WriteLine($"ID: {Product.Products[id].id}, название: {Product.Products[id].name}, цена: {Product.Products[id].price}, кол-во на складе: {Product.Products[id].available}");
                    }
                }
            }
            else if (choice == "5")
            {
                Console.Write("Введите искомое кол-во на складе: ");
                int available = IntInput();

                foreach (Product product in Product.Products)
                {
                    if (available == product.available)
                    {
                        Console.WriteLine($"ID: {Product.Products[id].id}, название: {Product.Products[id].name}, цена: {Product.Products[id].price}, кол-во на складе: {Product.Products[id].available}");
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
                if (index < 0 | index >= Product.Products.Count) flag = false;

                if (flag) Console.WriteLine($" ID: {Product.Products[index].id}\n Название: {Product.Products[index].name}\n Цена: {Product.Products[index].price}\n Кол-во на складе: {Product.Products[index].available}");
                else Console.WriteLine("Некорректное значение!");
            }
            else break;
        }
    }
}