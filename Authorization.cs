namespace InformationSystem
{
    internal class Authorization
    {
        public static void Start(string login, string password)
        {
            var found = false;

            foreach (var user in User.Users)
            {
                if (login == user.login & password == user.password)
                {
                    login = HR_manager.Binding(login);

                    if (user.role == "Administrator")
                    {
                        Administrator admin = new(user.id, login, password, user.role);
                    }
                    else if (user.role == "HR_manager")
                    {
                        HR_manager hr = new(user.id, login, password, user.role);
                    }
                    else if (user.role == "Warehouse_Manager")
                    {
                        Warehouse_Manager wh = new(user.id, login, password, user.role);
                    }
                    else if (user.role == "Cashier")
                    {
                        Cashier cs = new(user.id, login, password, user.role);
                    }
                    else if (user.role == "Accountant")
                    {
                        Accountant ac = new(user.id, login, password, user.role);
                    }
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Program.Start("Введён неправильный логин или пароль!");
            }
        }
    }
}