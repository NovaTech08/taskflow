using System;

namespace TaskFlow.Models
{
   public enum TaskStatus
   {
      Pendiente,
      EnProgreso,
      Completada
   }

   public class TaskItem
   {
      public int Id { get; set; }

      public string Titulo { get; set; }

      public string Descripcion { get; set; }

      public string Responsable { get; set; }

      public TaskStatus Estado { get; set; } = TaskStatus.Pendiente;

      public DateTime FechaDeCreacion { get; set; } = DateTime.Now;

      public DateTime? FechaDeModificacion { get; set; }
   }
}