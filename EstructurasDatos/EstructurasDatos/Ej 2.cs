using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasDatos
{
    internal class Ej_2
    {
        static void Main(string[] args)
        {
            List<string> tareas = new List<string>();
            Random random = new Random();
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("===== Menú de Tareas del NPC =====");
                Console.WriteLine("1. Añadir tarea");
                Console.WriteLine("2. Eliminar tarea");
                Console.WriteLine("3. Intercambiar tareas");
                Console.WriteLine("4. Cumplir tarea");
                Console.WriteLine("5. Salir");
                Console.Write("Selecciona una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AñadirTarea(tareas);
                        break;
                    case "2":
                        EliminarTarea(tareas);
                        break;
                    case "3":
                        IntercambiarTareas(tareas);
                        break;
                    case "4":
                        CumplirTarea(tareas, random);
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida, por favor intente de nuevo.");
                        break;
                }

                if (tareas.Count > 0)
                {
                    Console.WriteLine("\nEstado actual de las tareas:");
                    MostrarTareas(tareas);
                }
                else
                {
                    Console.WriteLine("\nNo hay tareas pendientes.");
                }

                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        static void MostrarTareas(List<string> tareas)
        {
            for (int i = 0; i < tareas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tareas[i]}");
            }
        }

        static void AñadirTarea(List<string> tareas)
        {
            Console.Write("Ingrese el nombre de la tarea a añadir: ");
            string tarea = Console.ReadLine();
            tareas.Add(tarea);
            Console.WriteLine("Tarea añadida correctamente.");
        }

        static void EliminarTarea(List<string> tareas)
        {
            Console.Write("Ingrese el índice de la tarea a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tareas.Count)
            {
                tareas.RemoveAt(index - 1);
                Console.WriteLine("Tarea eliminada correctamente.");
            }
            else
            {
                Console.WriteLine("Índice inválido.");
            }
        }

        static void IntercambiarTareas(List<string> tareas)
        {
            Console.Write("Ingrese el índice de la primera tarea a intercambiar: ");
            if (int.TryParse(Console.ReadLine(), out int index1) && index1 > 0 && index1 <= tareas.Count)
            {
                Console.Write("Ingrese el índice de la segunda tarea a intercambiar: ");
                if (int.TryParse(Console.ReadLine(), out int index2) && index2 > 0 && index2 <= tareas.Count && index1 != index2)
                {
                    string temp = tareas[index1 - 1];
                    tareas[index1 - 1] = tareas[index2 - 1];
                    tareas[index2 - 1] = temp;
                    Console.WriteLine("Tareas intercambiadas correctamente.");
                }
                else
                {
                    Console.WriteLine("Índice de la segunda tarea inválido o mismo índice.");
                }
            }
            else
            {
                Console.WriteLine("Índice inválido.");
            }
        }

        static void CumplirTarea(List<string> tareas, Random random)
        {
            if (tareas.Count > 0)
            {
                int index = random.Next(tareas.Count);
                string tareaCumplida = tareas[index];
                tareas.RemoveAt(index);
                Console.WriteLine($"Tarea cumplida: {tareaCumplida}");
            }
            else
            {
                Console.WriteLine("No hay tareas pendientes para cumplir.");
            }
        }
        
    }
}
