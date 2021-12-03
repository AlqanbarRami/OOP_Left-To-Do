using System;
using System.Collections;
using System.Collections.Generic;

namespace ToDo
{
    public class MainMenu : MenuManagement
    {

        public MainMenu()
        {

        }
        public void startMainMenu()
        {
            Console.Clear();
            while (continueMenuOrStop)
            {
                Console.WriteLine("LEFT TO DO ");
                Console.WriteLine("Välj vad du vill göra : ");
                Console.WriteLine("[1] Lägga till en ny uppgift");
                Console.WriteLine("[2] Litsa alla dagens uppgifter");
                Console.WriteLine("[3] Lista alla arkiverade uppgifter");
                Console.WriteLine("[4] Arkivera alla avklarade uppgifter");
                Console.WriteLine("[Q] Avsluta programmet");
                chooseFromLista = Console.ReadLine().ToLower();
                switch (chooseFromLista)
                {
                    case "1":
                        Console.Clear();
                        menuAddingPart();
                        break;
                    case "2":
                        Console.Clear();
                        menuShowTasks("day");
                        break;
                    case "3":
                        Console.Clear();
                        menuShowTasks("archive");
                        break;
                    case "4":
                        Console.Clear();
                        menuMoveToArchive();
                        break;
                    case "q":
                        Console.Clear();
                        Console.WriteLine("Tack Så Mycket!");
                        continueMenuOrStop = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Ogiltig inmatning. Tryck på valfri tangent för att gå tillbaka till menyn");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                }
            }
        }

        public void menuAddingPart()
        {
            while (continueMenuOrStop)
            {
                Console.WriteLine("Vilken type av uppgift vill du skapa?");
                Console.WriteLine("[1] Tidlös uppgift");
                Console.WriteLine("[2] Uppgift med deadline");
                Console.WriteLine("[3] Uppgift med checklista");
                Console.WriteLine("[Q] Avbryt");
                chooseFromLista = Console.ReadLine().ToLower();
                switch (chooseFromLista)
                {
                    case "1":
                        menuAddTaskWithoutTime();
                        break;
                    case "2":
                        menuAddTaskWithDate();
                        break;
                    case "3":
                        menuAddTaskWithCheckList();
                        break;
                    case "q":
                        Console.Clear();
                        startMainMenu();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Ogiltig inmatning. Tryck på valfri tangent för att gå tillbaka till menyn");
                        Console.ReadKey();
                        startMainMenu();
                        break;
                }
            }
        }

        public void menuShowTasks(string typeOfTasks)
        {
            switch (typeOfTasks)
            {
                case "day":
                    Console.Clear();
                    string symbol = "";
                    while (symbol != "q")
                    {
                        Console.Clear();
                        getTasksForToday();
                        symbol = Console.ReadLine().ToLower();
                        //Go And Update status and add items to Done List
                        updateStatus(symbol);
                        if (symbol == "q")
                        {
                            //function to check if all items Status = X 
                            checkListTask.addToDoneCheckLista();
                            Console.Clear();
                            startMainMenu();
                            break;
                        }
                    }


                    break;
                case "archive":
                    getItemsFromArchive();
                    startMainMenu();
                    break;
                default:
                    Console.WriteLine("Something Error");
                    break;
            }
            Console.Clear();

        }

        public void getTasksForToday(){
             Console.WriteLine("Här är alla dina uppgifter : \n");
                        foreach (NormalTask item in normalTask.TasksUnDone)
                        {
                            Console.WriteLine("[ Normal Uppgift ]");
                            Console.WriteLine($"( {item.NumberOfTask} ) [ {item.Status} ] {item.NameOfTask.ToUpper()}");
                        }
                        foreach (DateTask item in dateTask.TasksUnDone)
                        {
                            Console.WriteLine("[ Uppgift Med Dagar Kvar ]");
                            Console.WriteLine($"( {item.NumberOfTask} ) [ {item.Status} ] {item.NameOfTask.ToUpper()}, Dagar kvar till deadline {item.DateForDays} ");
                        }
                        int i = 0;
                        foreach (var item1 in checkListTask.MainList)
                        {
                            Console.WriteLine($"[ Uppgift Med Checklista  : {item1.Key.ToUpper()} ]");
                            foreach (CheckListTask item in checkListTask.TasksUnDone)
                            {
                                Console.WriteLine($"( {item.NumberOfTask} ) [ {item.Status} ] {item.NameOfTask}");
                                i++;
                            }
                        }
                        Console.WriteLine("\nVill du markera uppgift som avklarad, tryck på motsvaran siffra och Enter");
                        Console.WriteLine("Annars tryck Q och Enter för att gå tillbaka till menyn \n ");
        }
        public void getItemsFromArchive()
        {
            Console.WriteLine("Här är alla dina arkiverade uppgifter : \n");
            foreach (NormalTask item in normalTask.TasksArchive)
            {
                Console.WriteLine(item.NameOfTask);
            }
            foreach (DateTask item in dateTask.TasksArchive)
            {

                Console.WriteLine(item.NameOfTask);
            }
            foreach (CheckListTask item in checkListTask.TasksArchive)
            {
                Console.WriteLine(item.NameOfTask);
            }
            Console.WriteLine("\nTryck på valfri tangent för att gå tillbaka till menyn");
            Console.ReadKey();
            Console.Clear();
        }

    }
}

