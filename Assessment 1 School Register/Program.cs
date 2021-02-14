using System;

namespace Assessment_1_School_Register
{
    class Program
    {
        static void Main(string[] args)
        {
            FormGroup YEAR12 = new FormGroup("12FB", "Not Mr David");
            YEAR12.AddStudent("Prem", DateTime.Parse("17/06/2004"), "M");
            YEAR12.AddStudent("NotPrem", DateTime.Parse("20/02/2004"), "M");

            SchoolMenu(YEAR12);
        }
        static public void SchoolMenu(FormGroup YEAR12)
        {
            int OptionNumber;
            string UserInput = "";

            while (UserInput != "Exit")
            {
                Console.WriteLine("Press 1 to take the Register");
                Console.WriteLine("Press 2 to print the Register");
                Console.WriteLine("Press 3 to add students");
                Console.WriteLine("Press 4 to get a certain student's Details");
                Console.WriteLine("Press 5 to get the most Present,Late or Absent of a student");
                Console.WriteLine("Press 6 to get a chart of all Status days");
                UserInput = Console.ReadLine();

                if (int.TryParse(UserInput, out OptionNumber))
                {
                    if (OptionNumber == 1)
                    {
                        TakeRegister(YEAR12);
                    }
                    else if (OptionNumber == 2)
                    {
                        PrintRegister(YEAR12);
                    }
                    else if (OptionNumber == 3)
                    {
                        AddStudent(YEAR12);
                    }
                    else if (OptionNumber == 4)
                    {
                        GetStudentDetails(YEAR12);
                    }
                    else if (OptionNumber == 5)
                    {
                        GetMostStatus(YEAR12);
                    }
                    else if (OptionNumber == 6)
                    {
                        GetStatusChart(YEAR12);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Enter a valid option pls");
                        Clear();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Enter a valid option pls");
                    Clear();
                }
            }
        }
        static public void TakeRegister(FormGroup YEAR12)
        {
            Console.Clear();

            DateTime Date;
            Console.WriteLine("{0,3} {1,10}", YEAR12.GetFormName(), "REGISTRATION");
            Console.WriteLine("ENTER DATE");
            string DateInString = Console.ReadLine();
            if (DateTime.TryParse(DateInString, out Date))
            {
                YEAR12.TakeRegister(Date);
                Clear();
            }
            else
            {
                Console.WriteLine("Invalid Date");
            }
        }
        static public void PrintRegister(FormGroup YEAR12)
        {
            Console.Clear();

            DateTime Date;
            Console.WriteLine("{0,3} {1,10}", YEAR12.GetFormName(), "PRINT REGISTER");
            Console.WriteLine("ENTER DATE");
            string DateInString = Console.ReadLine();
            if (DateTime.TryParse(DateInString, out Date))
            {
                YEAR12.PrintRegister(Date);
                Clear();
            }
            else
            {
                Console.WriteLine("Invalid Date");
            }
        }
        static public void AddStudent(FormGroup YEAR12)
        {
            Console.Clear();

            string Name;
            DateTime DoB;
            string Gender;

            Console.WriteLine("{0,3} {1,10}", YEAR12.GetFormName(), "ADD STUDENT");

            Console.WriteLine("Enter Student's Name");
            Name = Console.ReadLine();

            Console.WriteLine("Enter Student's DoB");
            string DateInString = Console.ReadLine();

            while (DateTime.TryParse(DateInString, out DoB) == false)
            {
                Console.WriteLine("Enter Student's DoB");
                DateInString = Console.ReadLine();
            }

            Console.WriteLine("Enter Student's Gender");
            Gender = Console.ReadLine();

            YEAR12.AddStudent(Name, DoB, Gender);

            Console.WriteLine("COMPLETE");
            Clear();

        }
        static public void GetStudentDetails(FormGroup YEAR12)
        {
            string Name;

            Console.Clear();

            Console.WriteLine("Enter Student's Name");
            Name = Console.ReadLine();
            YEAR12.GetStudentDetails(Name);
            Clear();
        }
        static public void Clear()
        {
            int DelayTime = 2000;
            while (true)
            {
                Console.WriteLine("Press Enter to Clear");
                string Clear = Console.ReadLine();
                if (Clear == "" || Clear != "") // || is OR Statement"
                {
                    Console.WriteLine("CLEARING...");
                    System.Threading.Thread.Sleep(DelayTime);
                    Console.Clear();
                    break;
                }
            }
        }
        static public void GetMostStatus(FormGroup YEAR12)
        {
            string Status;

            Console.Clear();

            Console.WriteLine("P - Present, A - Absent, L - Late");
            Status = Console.ReadLine();
            YEAR12.GetMostStudent(Status);
            Clear();
        }
        static public void GetStatusChart(FormGroup YEAR12)
        {
            string Status;

            Console.Clear();

            Console.WriteLine("DRAW STATUS CHART");
            Console.WriteLine("P - Present, A - Absent, L - Late");
            Status = Console.ReadLine();
            YEAR12.GetStudentsStatusChart(Status);
            Clear();

        }
    }
}
