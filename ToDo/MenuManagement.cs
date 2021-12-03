using System;
using System.Collections;
using System.Collections.Generic;

namespace ToDo
{
    public class MenuManagement
    {
        public bool continueMenuOrStop = true;
        public string chooseFromLista;
        public int counterForTasks = 0;
        public NormalTask normalTask = new NormalTask();
        public DateTask dateTask = new DateTask();
        public CheckListTask checkListTask = new CheckListTask();
        public void menuAddTaskWithoutTime()
        {
            Console.Clear();
            Console.WriteLine("Skriv in uppgiften här : ");
            normalTask.addTaskToList(++counterForTasks, " ", Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Uppgiften har lagts till dina lista. Tryck på valfri tangent för att gå tillbaka till menyn");
            Console.ReadKey();
            Console.Clear();
        }

        public void menuAddTaskWithDate()
        {
            bool enterCorrect = true;
            int day;
            Console.Clear();
            Console.WriteLine("Skriv in uppgiften här : ");
            string nameForTask = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("När ska uppgiften vara färdig? Ange datum enligt modellen yyyy/mm/dd");
            while (enterCorrect)
            {
                try
                {
                    day = dateTask.getTotalDay(DateTime.Parse(Console.ReadLine()));
                    dateTask.addTaskToList(++counterForTasks, " ", nameForTask, day.ToString());
                    Console.Clear();
                    Console.WriteLine("Uppgiften har lagts till dina lista. Tryck på valfri tangent för att gå tillbaka till menyn");
                    Console.ReadKey();
                    Console.Clear();
                    enterCorrect = false;
                }
                catch (Exception error)
                {
                    Console.WriteLine(error);
                    Console.WriteLine("Please Enter Correct YEAR/MONTH/DAY ex: 2021/12/09");

                }
            }

        }

        public void menuAddTaskWithCheckList()
        {

            Console.Clear();
            Console.WriteLine("Skriv in ett namn för uppgiften : ");
            string nameForMainTask = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Add some sub uppgifter , tryck på Q ");
            string addToCheckLista = "";
            while (addToCheckLista != "q")
            {
                addToCheckLista = Console.ReadLine().ToLower();
                if (addToCheckLista == "q")
                {
                    Console.Clear();
                    checkListTask.addToMainList(nameForMainTask);
                }
                else
                {
                    checkListTask.addTaskToList(++counterForTasks, " ", addToCheckLista);
                }

            }

            Console.Clear();
            Console.WriteLine("Uppgiften har lagts till dina lista. Tryck på valfri tangent för att gå tillbaka till menyn");
            Console.ReadKey();
            Console.Clear();
        }

        public void menuMoveToArchive()
        {
            foreach (NormalTask item in normalTask.TasksDone)
            {
                Console.WriteLine($"[ {item.Status} ] {item.NameOfTask}");
            }
            foreach (DateTask item in dateTask.TasksDone)
            {
                Console.WriteLine($"[ {item.Status} ] {item.NameOfTask}");
            }
            foreach (CheckListTask item in checkListTask.TasksDone)
            {
                Console.WriteLine($"[ {item.Status} ] {item.NameOfTask}");
            }
            Console.WriteLine("Är du säker på att du vill arkivera alla avklarade uppgifter? ");
            Console.WriteLine("[1] JA");
            Console.WriteLine("[2] Nej ");
            chooseFromLista = Console.ReadLine();
            switch (chooseFromLista)
            {
                case "1":
                    foreach (NormalTask item in normalTask.TasksDone)
                    {
                        normalTask.addToArchive(item);
                    }
                    foreach (DateTask item in dateTask.TasksDone)
                    {
                        dateTask.addToArchive(item);
                    }
                    foreach (CheckListTask item in checkListTask.TasksDone)
                    {
                        checkListTask.addToArchive(item);
                    }
                    Console.Clear();
                    normalTask.TasksUnDone.Clear();
                    dateTask.TasksUnDone.Clear();
                    checkListTask.TasksUnDone.Clear();
                    normalTask.TasksDone.Clear();
                    dateTask.TasksDone.Clear();
                    checkListTask.MainList.Clear();
                    checkListTask.TasksDone.Clear();
                    Console.WriteLine("Alla avklarade uppgifter är nu arkiverade. Tryck på valfri tangent för att forsätta");
                    Console.ReadKey();

                    break;
                case "2":
                    Console.Clear();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Ogiltig inmatning. Tryck på valfri tangent för att gå tillbaka till menyn");
                    Console.ReadKey();
                    Console.Clear();

                    break;

            }
        }

        public void updateStatus(string symbol)
        {
            foreach (NormalTask item in normalTask.TasksUnDone)
            {
                if (symbol == item.NumberOfTask.ToString())
                {
                    if (item.Status == "X")
                    {
                        item.Status = " ";
                        normalTask.TasksDone.Remove(item);
                        counterForTasks += 1;
                    }

                    else if (item.Status == " ")
                    {
                        item.Status = "X";
                        normalTask.addToDone(item);
                        counterForTasks -= 1;
                    }
                }
            }
            foreach (DateTask item in dateTask.TasksUnDone)
            {
                if (symbol == item.NumberOfTask.ToString())
                {
                    if (item.Status == "X")
                    {
                        item.Status = " ";
                        dateTask.TasksDone.Remove(item);
                        counterForTasks += 1;
                    }
                    else if (item.Status == " ")
                    {
                        item.Status = "X";
                        dateTask.addToDone(item);
                        counterForTasks -= 1;
                    }
                }
            }
            foreach (CheckListTask item in checkListTask.TasksUnDone)
            {
                if (symbol == item.NumberOfTask.ToString())
                {
                    if (item.Status == "X")
                    {
                        item.Status = " ";
                        counterForTasks += 1;
                    }
                    else if (item.Status == " ")
                    {
                        item.Status = "X";
                        counterForTasks -= 1;
                    }
                }
            }
        }


    }


}
