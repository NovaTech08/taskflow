using System;
using TaskFlow.Services;
using TaskFlow.Models;

namespace TaskFlow.Utils
{
    public class ConsoleMenu
    {
        // Instanciamos el servicio acá para que viva mientras el menú esté abierto
        private TaskService _service;

        public ConsoleMenu()
        {
            _service = new TaskService();
        }

        public void MostrarMenu()
        {
            while (true)
            {
                Console.WriteLine("\n=== TASKFLOW ===");
                Console.WriteLine("1. Crear tarea");
                Console.WriteLine("2. Listar tareas");
                Console.WriteLine("3. Cambiar estado");
                Console.WriteLine("4. Salir");
                Console.Write("Elegí una opción: ");

                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        // Ahora es instancia, puede usar _service
                        CrearNuevaTarea();
                        break;

                    case "2":
                        // El código que ya hizo Dana
                        var tareas = _service.GetAllTasks();
                        if (tareas.Count == 0)
                        {
                            Console.WriteLine("No hay tareas cargadas.");
                        }
                        else
                        {
                            foreach (var t in tareas)
                            {
                                Console.WriteLine($"ID: {t.Id} | {t.Titulo} | Estado: {t.Estado} | Responsable: {t.Responsable}");
                            }
                        }
                        break;

                    case "3":
                        Console.Write("ID de la tarea: ");
                        if(!int.TryParse(Console.ReadLine(), out int id))
{
                            Console.WriteLine("ID inválido, ingresá solo números.");
                            break;
                        }

                        var tareaEncontrada = _service.BuscarPorId(id);
                        if (tareaEncontrada == null)
                        {
                            Console.WriteLine("Tarea no encontrada.");
                            break;
                        }

                        Console.WriteLine($"Tarea: {tareaEncontrada.Titulo} | Estado actual: {tareaEncontrada.Estado}");
                        Console.WriteLine("1. Pendiente  2. En Progreso  3. Completada");
                        Console.Write("Nuevo estado: ");
                        var op = Console.ReadLine();

                        TaskFlow.Models.TaskStatus estado;
                        if (op == "1") estado = TaskFlow.Models.TaskStatus.Pendiente;
                        else if (op == "2") estado = TaskFlow.Models.TaskStatus.EnProgreso;
                        else if (op == "3") estado = TaskFlow.Models.TaskStatus.Completada;
                        else { Console.WriteLine("Opción inválida."); break; }

                        bool ok = _service.ActualizarEstado(id, estado);
                        Console.WriteLine(ok ? "Estado actualizado." : "No se pudo actualizar.");
                        break;
                    case "4":
                        return; // Sale del bucle y termina el programa

                    default:
                        Console.WriteLine("Opción no disponible aún.");
                        break;
                }
            }
        }
        private void CrearNuevaTarea()
        {
            Console.Clear();
            Console.WriteLine("--- Registro de Nueva Tarea ---");

            Console.Write("Título (obligatorio): ");
            string titulo = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(titulo))
            {
                Console.WriteLine("Error: El título no puede estar vacío.");
                Console.ReadKey();
                return;
            }

            Console.Write("Descripción (opcional): ");
            string descripcion = Console.ReadLine();

            Console.Write("Responsable: ");
            string responsable = Console.ReadLine();

            // Llamada al servicio para crear la tarea
            _service.CrearTarea(titulo, descripcion, responsable);

            Console.WriteLine("\n¡Tarea creada exitosamente! Presione una tecla para volver.");
            Console.ReadKey();
        }
      
    }
}
