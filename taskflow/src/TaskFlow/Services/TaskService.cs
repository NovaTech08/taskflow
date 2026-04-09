using System.Collections.Generic;
using TaskFlow.Models;

namespace TaskFlow.Services
{
    public class TaskService
    {
        private List<TaskItem> _tasks = new List<TaskItem>();

        // Commit 1 (Dev 2): Método que devuelve la lista con todos los datos
        public List<TaskItem> GetAllTasks()
        {
            return _tasks;
        }
    }
}


    
