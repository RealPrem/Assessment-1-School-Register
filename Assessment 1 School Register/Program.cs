using System;

namespace Assessment_1_School_Register
{
    class Program
    {
        static void Main(string[] args)
        {
            FormGroup YEAR12 = new FormGroup("12FB", "Not Mr David");
            YEAR12.AddStudent("Prem", DateTime.Parse("17/06/2004"), "M");
            YEAR12.TakeRegister(DateTime.Parse("10/10/2020"));
            YEAR12.PrintRegister(DateTime.Parse("10/10/2020"));
            Console.WriteLine(YEAR12.GetStudent(0).GetAttendance(0).GetAttendanceStatus());

            //Student Prem = new Student("Prem", DateTime.Parse("17/06/2004"), "M");
            //Prem.AddAttendance(DateTime.Parse("20/10/2020"), "P");
            //Console.WriteLine(Prem.GetTotalDays("P"));
        }
    }
}
