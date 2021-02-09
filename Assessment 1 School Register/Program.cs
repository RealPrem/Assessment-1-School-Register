using System;

namespace Assessment_1_School_Register
{
    class Program
    {
        static void Main(string[] args)
        {
            Student Prem = new Student("Prem", DateTime.Parse("17/06/2004"), "M");
            Prem.AddAttendance(DateTime.Parse("20/10/2020"), "P");
            Console.WriteLine(Prem.GetTotalDays("P"));
        }
    }
}
