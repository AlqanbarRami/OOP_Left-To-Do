using System;
using Xunit;

namespace ToDo.Tests
{
    public class ToDoTest
    {
        //<- *Ett enhetstest finns i lösningen för att testa att uppgifter går att lägga till i listan* ->\\
        // Adding multiple types of tasks to the main list of objects.
        // Checklist items (without the name of main task)
        // DateTask Or DeadLine 
        // Task Without DeadLine
        [Fact]
        public void addTasks()
        {
            NormalTask normalTask = new NormalTask();
            normalTask.addTaskToList(1, " ", "FixSomething");
            DateTask dateTask = new DateTask();
            dateTask.addTaskToList(2, " ", "FixSomething", "44");
            CheckListTask checkListTask = new CheckListTask();
            checkListTask.addTaskToList(3, " ", "FixSomething");
            normalTask.addTaskToList(4, " ", "Extra");

            int numberOfObjectNormalTask = normalTask.TasksUnDone.Count;
            int numberOfObjectDateTask = dateTask.TasksUnDone.Count;
            int numberOfObjectCheckListTask = checkListTask.TasksUnDone.Count;
            int numberOfAllObjects = normalTask.TasksUnDone.Count + dateTask.TasksUnDone.Count + checkListTask.TasksUnDone.Count;

            Assert.Equal(4, numberOfAllObjects);
            Assert.Equal(2, numberOfObjectNormalTask);
            Assert.Equal(1, numberOfObjectDateTask);
            Assert.Equal(1, numberOfObjectCheckListTask);

        }


        //<- *Ett enhetstest finns i lösningen för att markera en uppgift som avklarad* ->\\
        [Fact]
        public void addToDoneList()
        {
            NormalTask normalTask = new NormalTask();
            normalTask.addTaskToList(1, "X", "FixSomething");
            normalTask.addToDone(normalTask);

            int numberOfObjUnDone = normalTask.TasksUnDone.Count;
            int numberOfObjDone = normalTask.TasksUnDone.Count;

            Assert.Equal(1, numberOfObjUnDone);
            Assert.Equal(1, numberOfObjDone);

        }

        //<- *Ett enhetstest finns i lösningen för att arkivera alla avklarade uppgifter i listan* ->\\
        [Fact]
        public void moveFromDoneToArchive()
        {
            NormalTask normalTask = new NormalTask();
            normalTask.addTaskToList(1, "X", "FixSomething");
            normalTask.addToDone(normalTask);
            normalTask.addToArchive(normalTask);
            normalTask.TasksDone.Clear();
            normalTask.TasksUnDone.Clear();

            int objDone = normalTask.TasksDone.Count;
            int objUnDone = normalTask.TasksUnDone.Count;
            int obArchive = normalTask.TasksArchive.Count;

            Assert.Equal(0, objDone);
            Assert.Equal(0, objUnDone);
            Assert.Equal(1, obArchive);
        }

        //<- *Lösningen ska innehålla ytterligare 1 eller 2 enhetestester som är lämpliga för de nya typerna av uppgifterna* ->\\

        // Checking if all status in checklist are Done X , get true
        [Fact]
        public void checkingCheckListStatusTrue()
        {
            CheckListTask checkListTask = new CheckListTask();
            checkListTask.addTaskToList(1, "X", "First Element in CheckList");
            checkListTask.addTaskToList(2, "X", "Second Element in CheckList");
            checkListTask.addToMainList("Fix All Of Them");

            bool getTheStatus = checkListTask.checkStatus(); // Get it fro My Method inside the class

            Assert.Equal(getTheStatus, true);
        }

        // Checking if all status in checklist are not Done X , get False
        [Fact]
        public void checkingCheckListStatusFalse()
        {
            CheckListTask checkListTask = new CheckListTask();
            checkListTask.addTaskToList(1, "X", "First Element in CheckList");
            checkListTask.addTaskToList(2, " ", "Second Element in CheckList");
            checkListTask.addToMainList("Fix All Of Them");

            bool getTheStatus = checkListTask.checkStatus();

            Assert.Equal(getTheStatus, false);
        }

        //Checking if I can move the elements from Undone To Doneو Depending on the status of the items
        [Fact]
        public void checkingIfWeNOTDone()
        {
            CheckListTask checkListTask2 = new CheckListTask();
            checkListTask2.addTaskToList(1, "X", "First Element in CheckList");
            checkListTask2.addTaskToList(2, "X", "Second Element in CheckList");
            checkListTask2.addTaskToList(2, " ", "Three Element in CheckList");
            checkListTask2.addToMainList("Fix All Of Them");
            checkListTask2.addToDoneCheckLista();

            int emptyOrNot = checkListTask2.TasksDone.Count;

            Assert.Equal(0, emptyOrNot);  // Should be 0 Cuz I have one element undone
        }

        [Fact]
        public void checkingIfWeDone()
        {
            CheckListTask checkListTask = new CheckListTask();
            checkListTask.addTaskToList(1, "X", "First Element in CheckList");
            checkListTask.addTaskToList(2, "X", "Second Element in CheckList");
            checkListTask.addToMainList("Fix All Of Them");
            checkListTask.addToDoneCheckLista();

            int emptyOrNot = checkListTask.TasksDone.Count;

            Assert.Equal(2, emptyOrNot);  // Should be 2 Object inside
        }
        
        [Fact]
        public void checkingKeyLikeNameOfMainTask(){
            CheckListTask checkListTask = new CheckListTask();
            checkListTask.addTaskToList(1, "X", "First Element in CheckList");
            checkListTask.addToMainList("Fix All Of Them"); // Name Of Main Task
            // Adding Another Object with another Main name
            CheckListTask checkListTask2 = new CheckListTask();
            checkListTask2.addTaskToList(2, "X", "First Element in CheckList");
            checkListTask2.addToMainList("Fix Them Now"); // Name Of Main Task

            bool checkTheFirstKey = checkListTask.MainList.ContainsKey("Fix All Of Them");
            bool checkTheSecondKey = checkListTask2.MainList.ContainsKey("Fix Them Now");

            Assert.Equal(true, checkTheFirstKey);  // Should be true
            Assert.Equal(true,checkTheSecondKey);
        }














    }
}
