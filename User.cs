namespace InformationSystem
{
    class User : ICrud
    {
        public static string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public static List<User> users = new(FileWork.Deserialization<User>(path));

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
            int id = users.Count; string login = "login"; string password = "password"; string role = "User";

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
            users.Add(newuser);
            FileWork.Serialization(users, path);
        }

        public virtual void Visualization()
        {
            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine($"[{i}] ID: {users[i].id}, логин: {users[i].login}, пароль: {users[i].password}, роль: {users[i].role}");
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

            foreach (User user in users)
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

                        FileWork.Serialization(users, path);
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

            users.Remove(users[findid]);
            FileWork.Serialization(users, path);
        }

        public virtual void Search()
        {
            while (true)
            {
                Console.WriteLine($"Выберите параметр:\n 1 - индекс\n 2 - ID\n 3 - логин\n 4 - пароль\n 5 - роль\n Enter - закончить");

                string choice = ChoiceInput();

                if (choice == "1")
                {
                    Console.Write("Введите искомый индекс: ");
                    int id = IntInput();

                    if (id >= users.Count() || id < 0)
                    {
                        Console.WriteLine("Некорректный индекс!");
                    }
                    else Console.WriteLine($"ID: {users[id].id}, логин: {users[id].login}, пароль: {users[id].password}, роль: {users[id].role}");

                }
                else if (choice == "2")
                {
                    Console.Write("Введите искомый ID: ");
                    int id = IntInput();

                    foreach (User user in users)
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
                    string login = StringInput();

                    foreach (User user in users)
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
                    string password = StringInput();

                    foreach (User user in users)
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
                    string role = RoleChoice();

                    foreach (User user in users)
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
                        flag = false;
                    }
                    if (index < 0 | index >= users.Count) flag = false;

                    if (flag) Console.WriteLine($" ID: {users[index].id}\n Логин: {users[index].login}\n Пароль: {users[index].password}\n Роль: {users[index].role}");
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
            Console.Write("(0 - Administrator, 1 - HR, 2 - Warehouse manager, 3 - Cashier, 4 - Accountant): ");
            int result = IntInput();
            string role = "User";

            if (result == 0)
            {
                role = "Administrator";
            }
            else if (result == 1)
            {
                role = "HR_Manager";
            }
            else if (result == 2)
            {
                role = "Warehouse_Manager";
            }
            else if (result == 3)
            {
                role = "Cashier";
            }
            else if (result == 4)
            {
                role = "Accountant";
            }
            else
            {
                Console.WriteLine("Некорректное значение!");
                role = RoleChoice();
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
}