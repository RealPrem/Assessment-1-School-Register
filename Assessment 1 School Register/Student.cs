using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment_1_School_Register
{
    class Student
    {
        private string Name;
        private DateTime DoB;
        private string Gender;
        private Attendance[] AttendanceDays = new Attendance[180];
        private int Times = 0;

        public Student(string Name, DateTime DoB, string Gender)
        {
            this.Name = Name;
            this.DoB = DoB;
            this.Gender = Gender;
        }
        public void AddAttendance(DateTime Date, string AttendanceStatus)
        {
            if (AttendanceStatus == "L")
            {
                Console.WriteLine("How Many minutes late");
                string MinutesLateInString = Console.ReadLine();
                int MinutesLateInInt = Convert.ToInt32(MinutesLateInString);
                AttendanceDays[Times] = new Attendance(Date, AttendanceStatus, MinutesLateInInt);
            }
            else
            {
                AttendanceDays[Times] = new Attendance(Date, AttendanceStatus);
            }
            Times += 1;
        }
        public string WasInSchool(DateTime Date)
        {
            for (int i = 0; i < AttendanceDays.Length; i += 1)
            {
                if (AttendanceDays[i] == null)
                {
                    break;
                }
                if (AttendanceDays[i].GetDate() == Date)
                {
                    return AttendanceDays[i].GetAttendanceStatus();
                }
            }
            return ("Attendance at Date " + Date + " Not Found");
        }
        public int GetTotalDays(string Status)
        {
            int Total = 0;
            for (int i = 0; i < AttendanceDays.Length; i += 1)
            {
                if (AttendanceDays[i] == null)
                {
                    break;
                }
                if (AttendanceDays[i].GetAttendanceStatus() == Status)
                {
                    Total += 1;
                }
            }
            return Total;
        }
        public int GetTotalLateHours()
        {
            int Total = 0;
            for (int i = 0; i < AttendanceDays.Length; i += 1)
            {
                if (AttendanceDays[i] == null)
                {
                    break;
                }
                Total += AttendanceDays[i].GetMinutesLate();
            }
            return Total;
        }
        public string GetName()
        {
            return Name;
        }

        public void GetAttendance(DateTime Date)
        {
            bool Found = false;
            for (int i = 0; i < AttendanceDays.Length; i += 1)
            {
                if (AttendanceDays[i] == null)
                {
                    break;
                }
                if (AttendanceDays[i].GetDate() == Date)
                {
                    Console.WriteLine("{0,3} {1,5}",Date.ToString("dd/MM/yyyy"), AttendanceDays[i].GetAttendanceStatus());
                    Found = true;
                }
            }
            if (Found ==  false)
            {
                Console.WriteLine("Date Not Found");
            }
        }
        public string GetGender()
        {
            return Gender;
        }
        public DateTime GetDoB()
        {
            return DoB;
        }
    }
}
