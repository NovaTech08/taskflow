using System;
using System.Collections.Generic;
using System.Linq;
using TaskFlow.Models; 

namespace TaskFlow.Services
{
    public class TaskService
    {
        private List<TaskItem> _tasks = new List<TaskItem>();

        // Método principal para listar todo (el que usa el Menú)
        public List<TaskItem> GetAllTasks()
        {
            return _tasks;
        }

        // Método de filtrado (el que pide la consigna)
        public List<TaskItem> GetTasksByStatus(TaskStatus status)
        {
            return _tasks.Where(t => t.Status == status).ToList();
        }
    }
}


    
