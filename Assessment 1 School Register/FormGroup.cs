﻿using System;
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
        public Student GetStudent(string Name)
        {
            for (int i = 0; i < Students.Length; i += 1)
            {
                if (Students[i] == null)
                {
                    break;
                }
                if (Students[i].GetName() == Name)
                {
                    return Students[i];
                }
            }
            return null;
        }
        public string GetFormName()
        {
            return NameOfForm;
        }
    }
}
