using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment_1_School_Register
{
    class Attendance
    {
        private DateTime Date;
        private string DayOfTheWeek;
        private string AttendanceStatus;
        private int MinutesLate;

        public Attendance(DateTime Date, string AttendanceStatus)
        {
            this.Date = Date;
            this.AttendanceStatus = AttendanceStatus;
            DayOfTheWeek = Date.ToString("dddd");
        }

        public Attendance(DateTime Date, string AttendanceStatus, int MinutesLate)
        {
            this.Date = Date;
            this.AttendanceStatus = AttendanceStatus;
            DayOfTheWeek = Date.ToString("dddd");
            this.MinutesLate = MinutesLate;

        }
        public DateTime GetDate()
        {
            return Date;
        }
        public string GetDayOfWeek()
        {
            return DayOfTheWeek;
        }
        public string GetAttendanceStatus()
        {
            return AttendanceStatus;
        }
        public int GetMinutesLate()
        {
            return MinutesLate;
        }
    }
}
