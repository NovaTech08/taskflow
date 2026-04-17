using System;
using TaskFlow.Services;

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
                     foreach (var t in tareas){
                if (t.FechaDeCreacion == t.FechaDeModificacion)
            {
                Console.WriteLine($"ID: {t.Id} | Titulo: {t.Titulo} | Descripcion: {t.Descripcion} | Estado: {t.Estado} | Responsable: {t.Responsable} | Creado: {t.FechaDeCreacion:dd/MM/yyyy HH:mm}");
            }
            else
            {
                Console.WriteLine($"ID: {t.Id} | Titulo: {t.Titulo} | Descripcion: {t.Descripcion} | Estado: {t.Estado} | Responsable: {t.Responsable} | Creado: {t.FechaDeCreacion:dd/MM/yyyy HH:mm} | Modificado: {t.FechaDeModificacion:dd/MM/yyyy HH:mm}");
            }
            Console.WriteLine(new string('-', 40));
        }
    }
    
                        break;

                    case "3":
                        // Acá el Dev 3 va a meter su código
                        Console.WriteLine("Opción en desarrollo...");
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