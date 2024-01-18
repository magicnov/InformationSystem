namespace InformationSystem
{
    internal class Staff
    {
        public static string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static List<Staff> staff = new(FileWork.Deserialization<Staff>(path));

        public Staff(int id, string surname, string name, string patronymic, string birthdate, string passport, string post, int salary, int userid)
        {
            this.id = id;
            this.surname = surname;
            this.name = name;
            this.patronymic = patronymic;
            this.birthdate = birthdate;
            this.passport = passport;
            this.post = post;
            this.salary = salary;
            this.userid = userid;
        }

        public int id { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }
        public string birthdate { get; set; }
        public string passport { get; set; }
        public string post { get; set; }
        public int salary { get; set; }
        public int userid { get; set; }

    }
}