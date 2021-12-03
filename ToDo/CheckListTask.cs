using System;
using System.Collections;
using System.Collections.Generic;

namespace ToDo
{
     public class CheckListTask : NormalTask
    {
        private string nameOfMainTask;
      //  private List<CheckListTask> cheklistItems = new List<CheckListTask>();
        private Dictionary<string , List<Object>> mainList = new Dictionary<string, List<Object>>() ;

        public string NameOfMainTask { get => nameOfMainTask; set => nameOfMainTask = value; }
      //  public List<CheckListTask> CheklistItems { get => cheklistItems; set => cheklistItems = value; }
        public Dictionary<string, List<Object>> MainList { get => mainList; set => mainList = value; }

        public CheckListTask()
        {
        }

          public CheckListTask(int numberOfTask, string status, string nameOfTask ) : base(numberOfTask, status, nameOfTask)
        {
        
        }  

        
        new public void addTaskToList(int numberOfTask, string status,string nameOfTask){  
           //  CheklistItems.Add(new CheckListTask(numberOfTask,status,nameOfTask));
             TasksUnDone.Add(new CheckListTask(numberOfTask,status,nameOfTask));
             
        }
        
        public void addToMainList(string name){
            MainList.Add(name,TasksUnDone);
        }
 
        public bool checkStatus(){
            foreach(CheckListTask item in TasksUnDone){
                if(item.Status != "X"){
                    return false;     
                }
            }
           return true;
        }
        public void addToDoneCheckLista(){
            if(checkStatus() == true){
            foreach(CheckListTask item in TasksUnDone){
                    TasksDone.Add(item);
                }
            }
        }

    }
}