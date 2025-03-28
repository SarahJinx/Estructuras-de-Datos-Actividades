using System;
using System.Collections.Generic;

namespace EstructurasDatos
{
    internal class Ej_4
    {
        static void Main(string[] args)
        {
            // Diccionario con las divisas
            Dictionary<string, string> divisas = new Dictionary<string, string>()
            {
                { "Euro", "€" },
                { "Dollar", "$" },
                { "Yen", "¥" }
            };

            // Solicitar al usuario que ingrese el nombre de una divisa
            Console.Write("Introduce el nombre de una divisa (Euro, Dollar, Yen): ");
            string divisa = Console.ReadLine();

            // Verificar si la divisa está en el diccionario
            if (divisas.ContainsKey(divisa))
            {
                // Mostrar el símbolo de la divisa
                Console.WriteLine($"El símbolo de {divisa} es {divisas[divisa]}.");
            }
            else
            {
                // Si la divisa no está en el diccionario
                Console.WriteLine("La divisa no está en el diccionario.");
            }
        }
    }
}

