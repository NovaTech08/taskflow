using System;
using System.Collections.Generic;
using System.Linq;
using TaskFlow.Models; 

namespace TaskFlow.Services
{
    public class TaskService
    {
        private List<TaskItem> _tasks = new List<TaskItem>();
        public TaskItem BuscarPorId(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        // Método principal para listar todo (el que usa el Menú)
        public List<TaskItem> GetAllTasks()
        {
            return _tasks;
        }

        // Método de filtrado (el que pide la consigna)
        public List<TaskItem> GetTasksByStatus(TaskFlow.Models.TaskStatus status)
        {
            return _tasks.Where(t => t.Status == status).ToList();
        }
        public bool ActualizarEstado(int id, TaskFlow.Models.TaskStatus nuevoEstado)
        {
            var tarea = _tasks.FirstOrDefault(t => t.Id == id);
            if (tarea == null) return false;

            tarea.Status = nuevoEstado;
            tarea.UpdatedAt = DateTime.Now;
            return true;
        }
    }
}


    
