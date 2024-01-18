using InformationSystem.Entities;
using InformationSystem.Services;

namespace InformationSystem.Roles;

internal class HrManager : User
{
    public HrManager(int id, string login, string password, string role) : base(id, login, password, role)
    {
        Console.Clear();
        Console.WriteLine($"Добро пожаловать, менеджер по персоналу {login}!");
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

        HrManager hr = new(id, login, password, role);
    }

    public static string Binding(string login)
    {
        foreach (User user in Users)
        {
            foreach (Staff staff in Staff.staff)
            {
                if (staff.userid != 0 & user.id == staff.userid)
                {
                    login = staff.name;
                }
            }
        }

        return login;
    }

    public override void Create()
    {
        int id = Staff.staff.Count; string surname = "Иванов"; string name = "Иван"; string patronymic = "-"; string birthdate = "01.01.2000"; string passport = "1234 123456"; string post = "Никто"; int salary = 10000; int userid = Staff.staff.Count;

        while (true)
        {
            Console.WriteLine($"Выберите параметр:\n 1 - ID: {id}\n 2 - фамилия: {surname}\n 3 - имя: {name}\n 4 - отчество: {patronymic}\n 5 - дата рождения: {birthdate}\n 6 - серия и номер паспорта: {passport}\n 7 - должность: {post}\n 8 - зарплата: {salary}\n 9 - ID пользователя: {userid}\n Enter - закончить");

            string choice = ChoiceInput();

            if (choice == "1")
            {
                Console.Write("Введите ID: ");
                id = IntInput();
            }
            else if (choice == "2")
            {
                Console.Write("Введите фамилию: ");
                surname = StringInput();
            }
            else if (choice == "3")
            {
                Console.Write("Введите имя: ");
                name = StringInput();
            }
            else if (choice == "4")
            {
                Console.Write("Введите отчество: ");
                patronymic = StringInput();
            }
            else if (choice == "5")
            {
                Console.Write("Введите дату рождения: ");
                birthdate = StringInput();
            }
            else if (choice == "6")
            {
                Console.Write("Введите серию и номер паспорта: ");
                passport = StringInput();
            }
            else if (choice == "7")
            {
                Console.Write("Введите должность: ");
                post = StringInput();
            }
            else if (choice == "8")
            {
                Console.Write("Введите зарплату: ");
                salary = IntInput();
            }
            else if (choice == "9")
            {
                Console.Write("Введите ID пользователя ");

                bool useridexist = false;

                foreach (Staff staff in Staff.staff)
                {
                    if (userid == staff.userid)
                    {
                        useridexist = true; break;
                    }
                }

                if (!useridexist) userid = IntInput();
                else Console.WriteLine("Такой ID пользователя уже занят");
            }
            else
            {
                break;
            }
        }

        Staff newstaff = new(id, surname, name, patronymic, birthdate, passport, post, salary, userid);
        Staff.staff.Add(newstaff);
        FileWorkService.Serialization(Staff.staff, Staff.Path);
    }

    public override void Visualization()
    {
        for (int i = 0; i < Staff.staff.Count; i++)
        {
            Console.WriteLine($"[{i}] ID: {Staff.staff[i].id}, ФИО: {Staff.staff[i].lastname} {Staff.staff[i].name} {Staff.staff[i].middlename}, должность: {Staff.staff[i].position}, ID пользователя: {Staff.staff[i].userid}");
        }
    }

    public override void Update()
    {
        int findid;

        while (true)
        {
            Console.Write("Введите ID сотрудника для изменения: ");
            findid = IntInput();

            Console.WriteLine("Вы уверены? Enter - чтобы продолжить");
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.Enter) break;
        }

        foreach (Staff staff in Staff.staff)
        {
            if (findid == staff.id)
            {
                while (true)
                {
                    Console.WriteLine($"Выберите параметр:\n 1 - ID: {staff.id}\n 2 - фамилия: {staff.lastname}\n 3 - имя: {staff.name}\n 4 - отчество: {staff.middlename}\n 5 - дата рождения: {staff.birthdate}\n 6 - серия и номер паспорта: {staff.passport}\n 7 - должность: {staff.position}\n 8 - зарплата: {staff.salary}\n 9 - ID пользователя: {staff.userid}\n Enter - закончить");

                    string choice = ChoiceInput();

                    if (choice == "1")
                    {
                        Console.Write("Введите ID: ");
                        staff.id = IntInput();
                    }
                    else if (choice == "2")
                    {
                        Console.Write("Введите фамилию: ");
                        staff.lastname = StringInput();
                    }
                    else if (choice == "3")
                    {
                        Console.Write("Введите имя: ");
                        staff.name = StringInput();
                    }
                    else if (choice == "4")
                    {
                        Console.Write("Введите отчество: ");
                        staff.middlename = StringInput();
                    }
                    else if (choice == "5")
                    {
                        Console.Write("Введите дату рождения: ");
                        staff.birthdate = StringInput();
                    }
                    else if (choice == "6")
                    {
                        Console.Write("Введите серию и номер паспорта: ");
                        staff.passport = StringInput();
                    }
                    else if (choice == "7")
                    {
                        Console.Write("Введите должность: ");
                        staff.position = StringInput();
                    }
                    else if (choice == "8")
                    {
                        Console.Write("Введите зарплату: ");
                        staff.salary = IntInput();
                    }
                    else if (choice == "9")
                    {
                        Console.Write("Введите ID пользователя для привязки: ");

                        bool useridexist = false;
                        int input = IntInput();

                        foreach (Staff staff1 in Staff.staff)
                        {
                            if (input == staff1.userid)
                            {
                                useridexist = true; break;
                            }
                        }

                        if (!useridexist) staff.userid = input;
                        else Console.WriteLine("Такой ID пользователя уже занят");
                    }
                    else
                    {
                        break;
                    }
                }

                FileWorkService.Serialization(Staff.staff, Staff.Path);
            }
        }
    }

    public override void Delete()
    {
        int findid;

        while (true)
        {
            Console.Write("Введите индекс сотрудника для удаления: ");
            findid = IntInput();

            Console.WriteLine("Вы уверены? Enter - чтобы продолжить");
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.Enter) break;
        }



        Staff.staff.Remove(Staff.staff[findid]);
        FileWorkService.Serialization(Staff.staff, Staff.Path);
    }

    public override void Search()
    {
        while (true)
        {
            Console.WriteLine("Выберите параметр:\n1 - индекс\n 2 - ID\n 3 - фамилия\n 4 - имя\n 5 - отчество\n 6 - дата рождения\n 7 - серия и номер паспорта\n 8 - должность\n 9 - зарплата\n 10 - ID пользователя\n Enter - закончить");

            string choice = ChoiceInput();

            if (choice == "1")
            {
                Console.Write("Введите искомый индекс: ");
                var id = IntInput();

                if (id >= Staff.staff.Count || id < 0)
                {
                    Console.WriteLine("Некорректный индекс!");
                }
                else Console.WriteLine($"ID: {Staff.staff[id].id}, фамилия: {Staff.staff[id].lastname}, имя: {Staff.staff[id].name}, отчество: {Staff.staff[id].middlename}, дата рождения: {Staff.staff[id].birthdate}, серия и номер паспорта: {Staff.staff[id].passport}, должность: {Staff.staff[id].position}, зарплата: {Staff.staff[id].salary}, ID пользователя: {Staff.staff[id].userid}");

            }
            else if (choice == "2")
            {
                Console.Write("Введите искомый ID: ");
                var id = IntInput();

                foreach (var staff in Staff.staff)
                {
                    if (id == staff.id)
                    {
                        Console.WriteLine($"ID: {staff.id}, фамилия: {staff.lastname}, имя: {staff.name}, отчество: {staff.middlename}, дата рождения: {staff.birthdate}, серия и номер паспорта: {staff.passport}, должность: {staff.position}, зарплата: {staff.salary}, ID пользователя: {staff.userid}");
                    }
                }
            }
            else if (choice == "3")
            {
                Console.Write("Введите искомую фамилию: ");
                var lastname = StringInput();

                foreach (Staff staff in Staff.staff)
                {
                    if (lastname == staff.lastname)
                    {
                        Console.WriteLine($"ID: {staff.id}, фамилия: {staff.lastname}, имя: {staff.name}, отчество: {staff.middlename}, дата рождения: {staff.birthdate}, серия и номер паспорта: {staff.passport}, должность: {staff.position}, зарплата: {staff.salary}, ID пользователя: {staff.userid}");
                    }
                }
            }
            else if (choice == "4")
            {
                Console.Write("Введите искомое имя: ");
                var name = StringInput();

                foreach (var staff in Staff.staff)
                {
                    if (name == staff.name)
                    {
                        Console.WriteLine($"ID: {staff.id}, фамилия: {staff.lastname}, имя: {staff.name}, отчество: {staff.middlename}, дата рождения: {staff.birthdate}, серия и номер паспорта: {staff.passport}, должность: {staff.position}, зарплата: {staff.salary}, ID пользователя: {staff.userid}");
                    }
                }
            }
            else if (choice == "5")
            {
                Console.Write("Введите искомое отчество: ");
                var middlename = StringInput();

                foreach (var staff in Staff.staff)
                {
                    if (middlename == staff.middlename)
                    {
                        Console.WriteLine($"ID: {staff.id}, фамилия: {staff.lastname}, имя: {staff.name}, отчество: {staff.middlename}, дата рождения: {staff.birthdate}, серия и номер паспорта: {staff.passport}, должность: {staff.position}, зарплата: {staff.salary}, ID пользователя: {staff.userid}");
                    }
                }
            }
            else if (choice == "6")
            {
                Console.Write("Введите искомую дату рождения: ");
                var birthdate = StringInput();

                foreach (var staff in Staff.staff)
                {
                    if (birthdate == staff.birthdate)
                    {
                        Console.WriteLine($"ID: {staff.id}, фамилия: {staff.lastname}, имя: {staff.name}, отчество: {staff.middlename}, дата рождения: {staff.birthdate}, серия и номер паспорта: {staff.passport}, должность: {staff.position}, зарплата: {staff.salary}, ID пользователя: {staff.userid}");
                    }
                }
            }
            else if (choice == "7")
            {
                Console.Write("Введите искомые серию и номер паспорта: ");
                var passport = StringInput();

                foreach (var staff in Staff.staff)
                {
                    if (passport == staff.passport)
                    {
                        Console.WriteLine($"ID: {staff.id}, фамилия: {staff.lastname}, имя: {staff.name}, отчество: {staff.middlename}, дата рождения: {staff.birthdate}, серия и номер паспорта: {staff.passport}, должность: {staff.position}, зарплата: {staff.salary}, ID пользователя: {staff.userid}");
                    }
                }
            }
            else if (choice == "8")
            {
                Console.Write("Введите искомую должность: ");
                var position = StringInput();

                foreach (var staff in Staff.staff)
                {
                    if (position == staff.position)
                    {
                        Console.WriteLine($"ID: {staff.id}, фамилия: {staff.lastname}, имя: {staff.name}, отчество: {staff.middlename}, дата рождения: {staff.birthdate}, серия и номер паспорта: {staff.passport}, должность: {staff.position}, зарплата: {staff.salary}, ID пользователя: {staff.userid}");
                    }
                }
            }
            else if (choice == "9")
            {
                Console.Write("Введите искомую зарплату: ");
                var salary = IntInput();

                foreach (var staff in Staff.staff)
                {
                    if (salary == staff.salary)
                    {
                        Console.WriteLine($"ID: {staff.id}, фамилия: {staff.lastname}, имя: {staff.name}, отчество: {staff.middlename}, дата рождения: {staff.birthdate}, серия и номер паспорта: {staff.passport}, должность: {staff.position}, зарплата: {staff.salary}, ID пользователя: {staff.userid}");
                    }
                }
            }
            else if (choice == "10")
            {
                Console.Write("Введите искомый ID пользователя: ");
                var userid = IntInput();

                foreach (var staff in Staff.staff)
                {
                    if (userid == staff.userid)
                    {
                        Console.WriteLine($"ID: {staff.id}, фамилия: {staff.lastname}, имя: {staff.name}, отчество: {staff.middlename}, дата рождения: {staff.birthdate}, серия и номер паспорта: {staff.passport}, должность: {staff.position}, зарплата: {staff.salary}, ID пользователя: {staff.userid}");
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
                if (index < 0 | index >= Staff.staff.Count) flag = false;

                if (flag) Console.WriteLine($" ID: {Staff.staff[index].id}\n Фамилия: {Staff.staff[index].lastname}\n Имя: {Staff.staff[id].name}\n Отчество: {Staff.staff[id].middlename}\n Дата рождения: {Staff.staff[id].birthdate}\n Серия и номер паспорта: {Staff.staff[id].passport}\n Должность: {Staff.staff[id].position}\n Зарплата: {Staff.staff[id].salary}\n ID пользователя: {Staff.staff[id].userid}");
                else Console.WriteLine("Некорректное значение!");
            }
            else break;
        }
    }
}