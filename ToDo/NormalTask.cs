using System;
using System.Collections;
using System.Collections.Generic;

namespace ToDo
{
    public class NormalTask
    {
        private string nameOfTask;
        private string status;
        private int numberOfTask;
        private List<Object> tasksUnDone = new List<Object>();
        private List<Object> tasksDone = new List<Object>();
        private List<Object> tasksArchive = new List<Object>();

        public string NameOfTask { get => nameOfTask; set => nameOfTask = value; }
        public string Status { get => status; set => status = value; }
        public int NumberOfTask { get => numberOfTask; set => numberOfTask = value; }
        public List<Object> TasksUnDone { get => tasksUnDone; set => tasksUnDone = value; }
        public List<Object> TasksDone { get => tasksDone; set => tasksDone = value; }
        public List<Object> TasksArchive { get => tasksArchive; set => tasksArchive = value; }

        public NormalTask()
        {

        }
        public NormalTask(int numberOfTask, string status, string nameOfTask)
        {
            this.NumberOfTask += numberOfTask;
            this.Status = status;
            this.NameOfTask = nameOfTask;
        }


        public void addTaskToList(int numberOfTask, string status, string nameOfTask)
        {
            TasksUnDone.Add(new NormalTask(numberOfTask, status, nameOfTask));
        }
        public void addToArchive(Object archiveTask)
        {
            TasksArchive.Add(archiveTask);
        }

        public void addToDone(Object doneTask)
        {
            TasksDone.Add(doneTask);
        }



    }
}