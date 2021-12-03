using System;
using System.Collections.Generic;

namespace ToDo
{
    public class DateTask : NormalTask
    {
        private string dateForDays;
        public string DateForDays { get => dateForDays; set => dateForDays = value; }
        public DateTask()
        {
        }

        public DateTask(int numberOfTask, string status, string nameOfTask, string DateForDays) : base(numberOfTask, status, nameOfTask)
        {
            this.DateForDays = DateForDays;
        }


        public void addTaskToList(int numberOfTask, string status, string nameOfTask, string DateForDays)
        {
            TasksUnDone.Add(new DateTask(numberOfTask, status, nameOfTask, DateForDays));
        }

        public int getTotalDay(DateTime DateFromUser)
        {
            TimeSpan days = DateFromUser - DateTime.Now;
            return Convert.ToInt32(days.TotalDays);
        }
    }
}