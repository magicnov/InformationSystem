using InformationSystem.Interfaces;
using InformationSystem.Roles;
using InformationSystem.Services;

namespace InformationSystem.Entities;

internal class User : ICrud
{
    private static readonly string Path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "users.csv");
    public static List<User> Users = new(FileWorkService.Deserialization<User>(Path));

    public User(int id, string login, string password, string role)
    {
        this.id = id;
        this.login = login;
        this.password = password;
        this.role = role;
    }

    public int id { get; set; }
    public string login { get; set; }
    public string password { get; set; }
    public string role { get; set; }

    public virtual void Create()
    {
        var id = Users.Count; 
        var login = "login"; 
        var password = "password";
        var role = "User";

        while (true)
        {
            Console.WriteLine($"Выберите параметр:\n 1 - ID: {id}\n 2 - логин: {login}\n 3 - пароль: {password}\n 4 - роль: {role}\n Enter - закончить");

            string choice = ChoiceInput();

            if (choice == "1")
            {
                Console.Write("Введите ID: ");
                id = IntInput();
            }
            else if (choice == "2")
            {
                Console.Write("Введите логин: ");
                login = StringInput();
            }
            else if (choice == "3")
            {
                Console.Write("Введите пароль: ");
                password = StringInput();
            }
            else if (choice == "4")
            {
                Console.Write("Введите роль ");
                role = RoleChoice();
            }
            else
            {
                break;
            }
        }

        User newuser = new(id, login, password, role);
        Users.Add(newuser);
        FileWorkService.Serialization(Users, Path);
    }

    public virtual void Visualization()
    {
        for (int i = 0; i < Users.Count; i++)
        {
            Console.WriteLine($"[{i}] ID: {Users[i].id}, логин: {Users[i].login}, пароль: {Users[i].password}, роль: {Users[i].role}");
        }
    }

    public virtual void Update()
    {
        int findid;

        while (true)
        {
            Console.Write("Введите ID пользователя для изменения: ");
            findid = IntInput();

            Console.WriteLine("Вы уверены? Enter - чтобы продолжить");
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.Enter) break;
        }

        foreach (User user in Users)
        {
            if (findid == user.id)
            {
                while (true)
                {
                    Console.WriteLine($"Выберите параметр:\n 1 - ID: {user.id}\n 2 - логин: {user.login}\n 3 - пароль: {user.password}\n 4 - роль: {user.role}\n Enter - закончить");

                    string choice = ChoiceInput();

                    if (choice == "1")
                    {
                        Console.Write("Введите ID: ");
                        user.id = IntInput();
                    }
                    else if (choice == "2")
                    {
                        Console.Write("Введите логин: ");
                        user.login = StringInput();
                    }
                    else if (choice == "3")
                    {
                        Console.Write("Введите пароль: ");
                        user.password = StringInput();
                    }
                    else if (choice == "4")
                    {
                        Console.Write("Введите роль ");
                        user.role = RoleChoice();
                    }
                    else
                    {
                        break;
                    }

                    FileWorkService.Serialization(Users, Path);
                }
            }
        }
    }

    public virtual void Delete()
    {
        int findid;

        while (true)
        {
            Console.Write("Введите индекс пользователя для удаления: ");
            findid = IntInput();

            Console.WriteLine("Вы уверены? Enter - чтобы продолжить");
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.Enter) break;
        }

        Users.Remove(Users[findid]);
        FileWorkService.Serialization(Users, Path);
    }

    public virtual void Search()
    {
        while (true)
        {
            Console.WriteLine("Выберите параметр:\n 1 - индекс\n 2 - ID\n 3 - логин\n 4 - пароль\n 5 - роль\n Enter - закончить");

            var choice = ChoiceInput();

            if (choice == "1")
            {
                Console.Write("Введите искомый индекс: ");
                var id = IntInput();

                if (id >= Users.Count || id < 0)
                {
                    Console.WriteLine("Некорректный индекс!");
                }
                else Console.WriteLine($"ID: {Users[id].id}, логин: {Users[id].login}, пароль: {Users[id].password}, роль: {Users[id].role}");

            }
            else if (choice == "2")
            {
                Console.Write("Введите искомый ID: ");
                var id = IntInput();

                foreach (var user in Users)
                {
                    if (id == user.id)
                    {
                        Console.WriteLine($"ID: {user.id}, логин: {user.login}, пароль: {user.password}, роль: {user.role}");
                    }
                }
            }
            else if (choice == "3")
            {
                Console.Write("Введите искомый логин: ");
                var login = StringInput();

                foreach (var user in Users)
                {
                    if (login == user.login)
                    {
                        Console.WriteLine($"ID: {user.id}, логин: {user.login}, пароль: {user.password}, роль: {user.role}");
                    }
                }
            }
            else if (choice == "4")
            {
                Console.Write("Введите искомый пароль: ");
                var password = StringInput();

                foreach (var user in Users)
                {
                    if (password == user.password)
                    {
                        Console.WriteLine($"ID: {user.id}, логин: {user.login}, пароль: {user.password}, роль: {user.role}");
                    }
                }
            }
            else if (choice == "5")
            {
                Console.Write("Введите искомую роль ");
                var role = RoleChoice();

                foreach (var user in Users)
                {
                    if (role == user.role)
                    {
                        Console.WriteLine($"ID: {user.id}, логин: {user.login}, пароль: {user.password}, роль: {user.role}");
                    }
                }
            }
            else
            {
                break;
            }
        }
    }

    public virtual void More()
    {
        while (true)
        {
            Console.WriteLine($"Введите индекс для подробной информации (Enter - закончить):");

            var choice = ChoiceInput();
            var index = 0;
            var flag = true;
            if (choice != "")
            {
                try
                {
                    index = int.Parse(choice);
                }
                catch (FormatException)
                {
                    flag = false;
                }
                if (index < 0 | index >= Users.Count) flag = false;

                if (flag) Console.WriteLine($" ID: {Users[index].id}\n Логин: {Users[index].login}\n Пароль: {Users[index].password}\n Роль: {Users[index].role}");
                else Console.WriteLine("Некорректное значение!");
            }
            else break;
        }
    }

    public static string StringInput()
    {
        string result = Console.ReadLine();

        if (result == null)
        {
            Console.WriteLine("Некорректное значение!");
            result = StringInput();
        }

        return result;
    }

    public static int IntInput()
    {
        int result;
        try
        {
            result = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Некорректное значение!");
            result = IntInput();
        }

        return result;
    }

    protected static string RoleChoice()
    {
        Console.Write("(0 - Administrator, 1 - HrManager, 2 - WarehouseManager, 3 - Cashier, 4 - Accountant): ");
        var result = IntInput();
        string role;

        switch (result)
        {
            case 0:
                role = nameof(Administrator);
                break;
            case 1:
                role = nameof(HrManager);
                break;
            case 2:
                role = nameof(WarehouseManager);
                break;
            case 3:
                role = nameof(Cashier);
                break;
            case 4:
                role = nameof(Accountant);
                break;
            default:
                Console.WriteLine("Некорректное значение!");
                role = RoleChoice();
                break;
        }

        return role;
    }

    public static string ChoiceInput()
    {
        string result = "";

        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.Enter) break;

            result += key.KeyChar;
        }

        return result;
    }
}