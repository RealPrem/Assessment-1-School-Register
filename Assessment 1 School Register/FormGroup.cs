using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment_1_School_Register
{
    class FormGroup
    {
        private string NameOfForm;
        private string NameOfTeacher;
        private Student[] Students = new Student[20];
        private int TotalStudents = 0;
        private int StudentCount = 0; 

        public FormGroup(string NameOfForm, string NameOfTeacher)
        {
            this.NameOfForm = NameOfForm;
            this.NameOfTeacher = NameOfTeacher;
            TotalStudents += 1;
        }
        public void AddStudent(string Name, DateTime DoB, string Gender)
        {
            Students[StudentCount] = new Student(Name,DoB,Gender);
            StudentCount += 1;
        }
        public void TakeRegister(DateTime Date)
        {
            Console.WriteLine("TAKING REGISTER");
            for (int i = 0; i < Students.Length; i += 1)
            {
                if (Students[i] == null)
                {
                    break;
                }
                Console.WriteLine("{0,3} {1,5} {2,35}", "Student:", Students[i].GetName(), "P - Present, A - Absent, L - Late");
                string AttendanceStatus = Console.ReadLine();
                Students[i].AddAttendance(Date,AttendanceStatus);
            }
            Console.WriteLine("END OF REGISTER");
        }
        public void PrintRegister(DateTime Date)
        {
            Console.WriteLine("{0,29} {1,16} {2,27}" , "NAME", "DoB", "AttendanceStatus");
            for (int i = 0; i < Students.Length; i += 1)
            {
                if (Students[i] == null)
                {
                    break;
                }
                Console.WriteLine("{0,3} {1,20} {2,20} {3,15}", "Student:", Students[i].GetName(), Students[i].GetDoB().ToString("dd/MM/yyyy"),
                    Students[i].WasInSchool(Date));
            }
        }
        public void PrintRegister(DateTime Date,string Name)
        {
            for (int i = 0; i < Students.Length; i += 1)
            {
                if (Students[i] == null)
                {
                    break;
                }
                if (Students[i].GetName() == Name)
                {
                    Console.WriteLine("Student: " + Students[i].GetName());
                    Students[i].GetAttendance(Date);
                }
            }
        }
        public void GetStudentDetails(string Name)
        {
            bool Found = false;
            for (int i = 0; i < Students.Length; i += 1)
            {
                if (Students[i] == null)
                {
                    break;
                }
                if (Students[i].GetName() == Name)
                {
                    Console.Clear();
                    Console.WriteLine("{0,19} {1,16} {2,20} {3,20} {4,20}", "NAME", "DOB", "PRESENT DAYS", "LATE DAYS" , "ABSENT DAYS");
                    Console.WriteLine("{0,3} {1,10} {2,20} {3,10} {4,22} {5,19}", "Student:", Students[i].GetName(), Students[i].GetDoB().ToString("dd/MM/yyyy"),
                        Students[i].GetTotalDays("P"), Students[i].GetTotalDays("L"), Students[i].GetTotalDays("A"));
                  
                    Found = true;
                }
            }
            if (Found == false)
            {
                Console.WriteLine("Student Not Found");
            }
        }
        public void GetMostStudent(string Status)
        {
            Console.Clear();

            string MaxName= Students[0].GetName();
            int max = Students[0].GetTotalDays(Status);

            string MinName = Students[0].GetName();
            int min = Students[0].GetTotalDays(Status);

            for (int i = 0; i < Students.Length; i += 1)
            {
                if (Students[i] == null)
                {
                    break;
                }
                if (Students[i].GetTotalDays(Status) > max)
                {
                    max = Students[i].GetTotalDays(Status);
                    MaxName = Students[i].GetName();
                }
                else if (Students[i].GetTotalDays(Status) < min)
                {
                    min = Students[i].GetTotalDays(Status);
                    MinName = Students[i].GetName();
                }
            }
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("HIGHEST");
            Console.WriteLine("{0,19} {1,13} {2,10}", "Name", "Status", "Amount");
            Console.WriteLine("{0,3} {1,10} {2,10} {3,10}","Student:" , MaxName, Status, max);

            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("LOWEST");
            Console.WriteLine("{0,19} {1,13} {2,10}", "Name", "Status", "Amount");
            Console.WriteLine("{0,3} {1,10} {2,10} {3,10}", "Student:", MinName, Status, min);
            Console.WriteLine("-----------------------------------------------");
        }
        public void GetStudentsStatusChart(string Status)
        {
            Console.Clear();

            if (Status == "P")
            {
                Console.WriteLine(GetFormName() + " PRESENT DAYS");
            }
            else if (Status == "L")
            {
                Console.WriteLine(GetFormName() + " LATE DAYS");
            }
            else if (Status == "A")
            {
                Console.WriteLine(GetFormName() + " ABSENT DAYS");
            }
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("{0,13} {1,4} {2,4} {3,4} {4,4} {5,4} {6,4} {7,4} {8,4} {9,4}", 5 , 10 , 15 , 20 , 25 , 30 , 35 , 40 , 45 , 50);
            for (int i = 0; i < Students.Length; i += 1)
            {
                int Total = 0;
                string StatusLength = "";
                if (Students[i] == null)
                {
                    break;
                }
                Total = Students[i].GetTotalDays(Status);
                for (int y = 0; y < Total; y += 1)
                {
                    StatusLength += "#";
                }
                Console.WriteLine(Students[i].GetName() + "\t" + StatusLength);
            }
            Console.WriteLine("----------------------------------------------------------");
        }
        public string GetFormName()
        {
            return NameOfForm;
        }
    }
}
