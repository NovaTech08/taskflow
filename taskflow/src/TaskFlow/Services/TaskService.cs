using System;
using System.Collections.Generic;
using System.Linq;
using TaskFlow.Models;
using TaskStatus = TaskFlow.Models.TaskStatus;

namespace TaskFlow.Services
{
    public class TaskService
    {
        private List<TaskItem> _tasks = new List<TaskItem>();
        public TaskItem BuscarPorId(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        //(Dev 1): Método que crea una nueva tarea
        public void CrearTarea(string titulo, string descripcion, string responsable)
        {
            int nuevoId = _tasks.Count > 0 ? _tasks.Max(t => t.Id) + 1 : 1;

            var nuevaTarea = new TaskItem
            {
                Id = nuevoId,
                Titulo = titulo,
                Descripcion = descripcion,
                Responsable = responsable,
                Estado = TaskStatus.Pendiente,
                FechaDeCreacion = DateTime.UtcNow
            };

            _tasks.Add(nuevaTarea);
        }

        // Commit 1 (Dev 2): Método que devuelve la lista con todos los datos
        public List<TaskItem> GetAllTasks()
        {
            return _tasks;
        }
        public bool ActualizarEstado(int id, TaskFlow.Models.TaskStatus nuevoEstado)
        {
            var tarea = _tasks.FirstOrDefault(t => t.Id == id);
            if (tarea == null) return false;

            tarea.Estado = nuevoEstado;
            tarea.FechaDeModificacion = DateTime.Now;
            return true;
        }
    }
}


    
