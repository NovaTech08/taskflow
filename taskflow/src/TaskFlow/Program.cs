using System;
using TaskFlow.Services;

var service = new TaskService();

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
        case "2":
            var tareas = service.GetAllTasks();
            if (tareas.Count == 0)
            {
                Console.WriteLine("No hay tareas cargadas.");
            }
            else
            {
                foreach (var t in tareas)
                {
                    Console.WriteLine($"ID: {t.Id} | {t.Title} | Estado: {t.Status} | Responsable: {t.Responsible}");
                }
            }
            break;

        case "4":
            return;

        default:
            Console.WriteLine("Opción no disponible aún.");
            break;
    }
}
