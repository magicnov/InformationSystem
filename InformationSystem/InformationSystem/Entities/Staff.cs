using InformationSystem.Services;

namespace InformationSystem.Entities;

internal class Staff
{
    public static readonly string Path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "staff.csv");
    public static List<Staff> staff = new(FileWorkService.Deserialization<Staff>(Path));

    public Staff(int id, string lastname, string name, string middlename, string birthdate, string passport, string position, int salary, int userid)
    {
        this.id = id;
        this.lastname = lastname;
        this.name = name;
        this.middlename = middlename;
        this.birthdate = birthdate;
        this.passport = passport;
        this.position = position;
        this.salary = salary;
        this.userid = userid;
    }

    public int id { get; set; }
    public string lastname { get; set; }
    public string name { get; set; }
    public string middlename { get; set; }
    public string birthdate { get; set; }
    public string passport { get; set; }
    public string position { get; set; }
    public int salary { get; set; }
    public int userid { get; set; }

}